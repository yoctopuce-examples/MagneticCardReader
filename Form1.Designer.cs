namespace MagneticCardReader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.logBox = new System.Windows.Forms.TextBox();
            this.errorMessage = new System.Windows.Forms.Label();
            this.dialogTitle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.card_id = new System.Windows.Forms.Label();
            this.card_extra = new System.Windows.Forms.Label();
            this.card_exp = new System.Windows.Forms.Label();
            this.dialogPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.dialogPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBox.Location = new System.Drawing.Point(12, 12);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(770, 154);
            this.logBox.TabIndex = 14;
            // 
            // errorMessage
            // 
            this.errorMessage.Location = new System.Drawing.Point(0, 0);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(100, 23);
            this.errorMessage.TabIndex = 0;
            // 
            // dialogTitle
            // 
            this.dialogTitle.Location = new System.Drawing.Point(0, 0);
            this.dialogTitle.Name = "dialogTitle";
            this.dialogTitle.Size = new System.Drawing.Size(100, 23);
            this.dialogTitle.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(767, 460);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // card_id
            // 
            this.card_id.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.card_id.AutoSize = true;
            this.card_id.BackColor = System.Drawing.Color.Transparent;
            this.card_id.Font = new System.Drawing.Font("BR-OCRB", 20F, System.Drawing.FontStyle.Bold);
            this.card_id.Location = new System.Drawing.Point(35, 242);
            this.card_id.Name = "card_id";
            this.card_id.Size = new System.Drawing.Size(435, 36);
            this.card_id.TabIndex = 4;
            this.card_id.Text = "<swipe card to read>";
            // 
            // card_extra
            // 
            this.card_extra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.card_extra.AutoSize = true;
            this.card_extra.BackColor = System.Drawing.Color.Transparent;
            this.card_extra.Font = new System.Drawing.Font("BR-OCRB", 16F, System.Drawing.FontStyle.Bold);
            this.card_extra.Location = new System.Drawing.Point(36, 401);
            this.card_extra.Name = "card_extra";
            this.card_extra.Size = new System.Drawing.Size(98, 29);
            this.card_extra.TabIndex = 5;
            this.card_extra.Text = "extra";
            // 
            // card_exp
            // 
            this.card_exp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.card_exp.AutoSize = true;
            this.card_exp.BackColor = System.Drawing.Color.Transparent;
            this.card_exp.Font = new System.Drawing.Font("BR-OCRB", 16F, System.Drawing.FontStyle.Bold);
            this.card_exp.Location = new System.Drawing.Point(624, 336);
            this.card_exp.Name = "card_exp";
            this.card_exp.Size = new System.Drawing.Size(98, 29);
            this.card_exp.TabIndex = 6;
            this.card_exp.Text = "04/20";
            // 
            // dialogPanel
            // 
            this.dialogPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dialogPanel.Controls.Add(this.card_exp);
            this.dialogPanel.Controls.Add(this.card_extra);
            this.dialogPanel.Controls.Add(this.card_id);
            this.dialogPanel.Controls.Add(this.pictureBox1);
            this.dialogPanel.Location = new System.Drawing.Point(12, 172);
            this.dialogPanel.Name = "dialogPanel";
            this.dialogPanel.Size = new System.Drawing.Size(770, 463);
            this.dialogPanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 647);
            this.Controls.Add(this.dialogPanel);
            this.Controls.Add(this.logBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Magnetic Card Reader demo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.dialogPanel.ResumeLayout(false);
            this.dialogPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Label errorMessage;
        private System.Windows.Forms.Label dialogTitle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label card_id;
        private System.Windows.Forms.Label card_extra;
        private System.Windows.Forms.Label card_exp;
        private System.Windows.Forms.Panel dialogPanel;
    }
}

