namespace Notepad.Forms
{
    partial class FileSelectForm
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
            this.FilesLSB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // FilesLSB
            // 
            this.FilesLSB.FormattingEnabled = true;
            this.FilesLSB.Location = new System.Drawing.Point(12, 12);
            this.FilesLSB.Name = "FilesLSB";
            this.FilesLSB.Size = new System.Drawing.Size(203, 251);
            this.FilesLSB.TabIndex = 0;
            this.FilesLSB.DoubleClick += new System.EventHandler(this.FilesLSB_DoubleClick);
            // 
            // FileSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 284);
            this.Controls.Add(this.FilesLSB);
            this.Name = "FileSelectForm";
            this.Text = "FileSelectForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox FilesLSB;
    }
}