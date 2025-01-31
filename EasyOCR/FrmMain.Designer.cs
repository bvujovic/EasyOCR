﻿namespace EasyOCR
{
    partial class FrmMain
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
            this.btnTest = new System.Windows.Forms.Button();
            this.lblClipboardImgChanges = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.Timer(this.components);
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(14, 94);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(136, 32);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // lblClipboardImgChanges
            // 
            this.lblClipboardImgChanges.AutoSize = true;
            this.lblClipboardImgChanges.Location = new System.Drawing.Point(13, 137);
            this.lblClipboardImgChanges.Name = "lblClipboardImgChanges";
            this.lblClipboardImgChanges.Size = new System.Drawing.Size(14, 16);
            this.lblClipboardImgChanges.TabIndex = 1;
            this.lblClipboardImgChanges.Text = "0";
            // 
            // tim
            // 
            this.tim.Enabled = true;
            this.tim.Interval = 500;
            this.tim.Tick += new System.EventHandler(this.Tim_Tick);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "English",
            "SerbianLatin",
            "CyrillicAlphabet"});
            this.cmbLanguage.Location = new System.Drawing.Point(14, 12);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(136, 24);
            this.cmbLanguage.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 166);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.lblClipboardImgChanges);
            this.Controls.Add(this.btnTest);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Easy OCR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblClipboardImgChanges;
        private System.Windows.Forms.Timer tim;
        private System.Windows.Forms.ComboBox cmbLanguage;
    }
}

