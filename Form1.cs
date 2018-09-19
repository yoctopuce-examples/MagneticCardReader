using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace MagneticCardReader
{

    public partial class Form1 : Form
    {
        YSpiPort spiPort = null;

        const bool DEBUG = false;

        public Form1()
        {
            string errmsg = "";

            InitializeComponent();
            card_exp.Text = "";
            card_extra.Text = "";

            // Setup Yoctopuce API
            YAPI.DisableExceptions();
            if (DEBUG) YAPI.RegisterLogFunction(this.Log);
            if (YAPI.RegisterHub("usb", ref errmsg) != YAPI.SUCCESS)
            {
                Log("Cannot connect to USB devices:");
                Log(errmsg);
            }
            YAPI.RegisterDeviceArrivalCallback(this.ArrivalCallback);
        }

        public void Log(string msg)
        {
            logBox.AppendText(msg + "\r\n");
        }

        public void ArrivalCallback(YModule module)
        {
            // Check if the device features a SPI Port
            for(int i = 0; i < module.functionCount(); i++)
            {
                if (module.functionType(i) == "SpiPort")
                {
                    // SPI Port found, use it
                    string identifier = module.get_serialNumber() + "." + module.functionId(i);
                    Log("Using " + identifier);
                    spiPort = YSpiPort.FindSpiPort(identifier);
                    spiPort.set_spiMode("0,0,lsb");
                    spiPort.reset();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string errmsg = "";
            timer1.Stop();

            // Handle device plug/unplug events
            YAPI.UpdateDeviceList(ref errmsg);
            YAPI.HandleEvents(ref errmsg);
            if(spiPort != null)
            {
                // Yocto-SPI connected, check if a card swipe message was received
                List<string> msgs = spiPort.readMessages("", 1);
                if (DEBUG) for (int i = 0; i < msgs.Count; i++) Log("Read: " + msgs[i]);
                if (msgs.Count > 0)
                {
                    // Decode ABA Track 2 data from magnetic card
                    string track2 = this.DecodeTrack2(msgs[0]);
                    string firstChar = track2.Substring(0, 1);
                    string lastChar = track2.Substring(track2.Length - 1);
                    Log("Track 2: " + track2);
                    if(firstChar == "!")
                    {
                        card_id.Text = "Error !";
                        card_exp.Text = "";
                        card_extra.Text = track2.Substring(2);
                    } else if(firstChar == ";" && lastChar == "?")
                    {
                        int separator = track2.IndexOf("=");
                        string ident = track2.Substring(1, separator - 1);
                        for (int i = 4; i < ident.Length; i += 5) ident = ident.Insert(i, " ");
                        card_id.Text = ident;
                        card_exp.Text = track2.Substring(separator+3, 2) + "/" + track2.Substring(separator + 1, 2);
                        card_extra.Text = track2.Substring(separator+8, track2.Length - separator - 9);
                    }
                    else
                    {
                        card_id.Text = "Error !";
                        card_exp.Text = "";
                        card_extra.Text = "Bad format, may be a reverse swipe ?";
                    }

                    // Clear read buffer to catch next swipe
                    spiPort.reset();
                }
            }

            timer1.Start();
        }

        private string DecodeTrack2(string msg)
        {
            bool started = false;
            int currVal = 0;
            int currBits = 0;
            int lrc = 0;
            string result = "";

            for (int i = 0; i < msg.Length; i += 2)
            {
                int newByte = int.Parse(msg.Substring(i, 2), NumberStyles.HexNumber);
                int bitAvail = 8;

                // data bits are inverted (^5V = 0, 0V = 1)
                newByte ^= 0xff;

                // at the beginning of message, skip over zero bits
                if (!started && newByte != 0)
                {
                    while((newByte & 1) == 0)
                    {
                        newByte >>= 1;
                        bitAvail -= 1;
                    }
                    started = true;
                }

                if (started)
                {
                    currVal += newByte << currBits;
                    currBits += bitAvail;
                    while (currBits >= 5)
                    {
                        // Extract lowest 5-bit word and compute parity
                        int nextDigit = currVal & 0x1f;
                        uint parity = (0x96696996 >> (int)nextDigit) & 1;

                        // A full 0 word is the end of the message
                        if (nextDigit == 0)
                        {
                            // Check Longitudinal redundancy code
                            if (lrc != 0) return "! Read error (LRC)";
                            // Return result (without LRC)
                            return result.Substring(0, result.Length-1);
                        }

                        // Signal any parity error
                        if (parity != 1) return "! Read error (parity)";

                        // Store decoded character, update longitudinal redundancy check word
                        nextDigit &= 0xf;
                        result += (char)(48 + nextDigit);
                        lrc ^= nextDigit;

                        // Keep remaining bits only
                        currBits -= 5;
                        currVal >>= 5;
                    }
                }
            }
            // Check Longitudinal redundancy code
            if (lrc != 0) return "! Read error (LRC)";
            // Return result (without LRC)
            return result.Substring(0, result.Length - 1);
        }
    }
}
