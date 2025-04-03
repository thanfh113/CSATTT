
namespace ReceiveFile
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
            this.btnStartListening = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnUploadAndDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartListening
            // 
            this.btnStartListening.Location = new System.Drawing.Point(18, 18);
            this.btnStartListening.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartListening.Name = "btnStartListening";
            this.btnStartListening.Size = new System.Drawing.Size(180, 35);
            this.btnStartListening.TabIndex = 0;
            this.btnStartListening.Text = "Start Listening";
            this.btnStartListening.UseVisualStyleBackColor = true;
            this.btnStartListening.Click += new System.EventHandler(this.btnStartListening_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(207, 26);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 20);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Ready";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(18, 63);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(373, 26);
            this.txtFilePath.TabIndex = 2;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(402, 60);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(112, 35);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnUploadAndEncrypt
            // 
            this.btnUploadAndDecrypt.Location = new System.Drawing.Point(18, 103);
            this.btnUploadAndDecrypt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUploadAndDecrypt.Name = "btnUploadAndEncrypt";
            this.btnUploadAndDecrypt.Size = new System.Drawing.Size(240, 35);
            this.btnUploadAndDecrypt.TabIndex = 4;
            this.btnUploadAndDecrypt.Text = "Upload and Decrypt";
            this.btnUploadAndDecrypt.UseVisualStyleBackColor = true;
            this.btnUploadAndDecrypt.Click += new System.EventHandler(this.btnUploadAndDecrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 157);
            this.Controls.Add(this.btnUploadAndDecrypt);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStartListening);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Receive File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnUploadAndDecrypt;
        //private System.Windows.Forms.Button btnDownloadDecrypted;

    }
}

