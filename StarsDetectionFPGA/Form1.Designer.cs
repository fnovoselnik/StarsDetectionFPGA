namespace StarsDetectionFPGA
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ports = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUARTInit = new System.Windows.Forms.Button();
            this.buttonUARTSend = new System.Windows.Forms.Button();
            this.btn_DetectStars = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(40, 41);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(101, 36);
            this.buttonOpenFile.TabIndex = 2;
            this.buttonOpenFile.Text = "Open image";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ports:";
            // 
            // ports
            // 
            this.ports.FormattingEnabled = true;
            this.ports.Location = new System.Drawing.Point(280, 48);
            this.ports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ports.Name = "ports";
            this.ports.Size = new System.Drawing.Size(121, 24);
            this.ports.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(40, 112);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(481, 372);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnUARTInit
            // 
            this.btnUARTInit.Location = new System.Drawing.Point(573, 112);
            this.btnUARTInit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUARTInit.Name = "btnUARTInit";
            this.btnUARTInit.Size = new System.Drawing.Size(109, 23);
            this.btnUARTInit.TabIndex = 10;
            this.btnUARTInit.Text = "UART init";
            this.btnUARTInit.UseVisualStyleBackColor = true;
            this.btnUARTInit.Click += new System.EventHandler(this.btnUARTInit_Click);
            // 
            // buttonUARTSend
            // 
            this.buttonUARTSend.Location = new System.Drawing.Point(573, 162);
            this.buttonUARTSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUARTSend.Name = "buttonUARTSend";
            this.buttonUARTSend.Size = new System.Drawing.Size(109, 23);
            this.buttonUARTSend.TabIndex = 11;
            this.buttonUARTSend.Text = "UART send";
            this.buttonUARTSend.UseVisualStyleBackColor = true;
            this.buttonUARTSend.Click += new System.EventHandler(this.buttonUARTSend_Click);
            // 
            // btn_DetectStars
            // 
            this.btn_DetectStars.Location = new System.Drawing.Point(573, 212);
            this.btn_DetectStars.Margin = new System.Windows.Forms.Padding(4);
            this.btn_DetectStars.Name = "btn_DetectStars";
            this.btn_DetectStars.Size = new System.Drawing.Size(109, 28);
            this.btn_DetectStars.TabIndex = 12;
            this.btn_DetectStars.Text = "Mark Stars";
            this.btn_DetectStars.UseVisualStyleBackColor = true;
            this.btn_DetectStars.Click += new System.EventHandler(this.btn_DetectStars_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(200, 504);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(133, 28);
            this.progressBar1.TabIndex = 13;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(582, 504);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 28);
            this.buttonExit.TabIndex = 14;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 510);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Sending image:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 577);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_DetectStars);
            this.Controls.Add(this.buttonUARTSend);
            this.Controls.Add(this.btnUARTInit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ports);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpenFile);
            this.Name = "Form1";
            this.Text = "StarsDetectionFPGA";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ports;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUARTInit;
        private System.Windows.Forms.Button buttonUARTSend;
        private System.Windows.Forms.Button btn_DetectStars;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label2;
    }
}

