
namespace Win7_Plus_StackBy
{
    partial class StackbyGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StackbyGen));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSelectedFolder = new System.Windows.Forms.TextBox();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPropertys = new System.Windows.Forms.ComboBox();
            this.buttonGenerateSearchMS = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder";
            // 
            // textBoxSelectedFolder
            // 
            this.textBoxSelectedFolder.Location = new System.Drawing.Point(72, 17);
            this.textBoxSelectedFolder.Name = "textBoxSelectedFolder";
            this.textBoxSelectedFolder.Size = new System.Drawing.Size(520, 26);
            this.textBoxSelectedFolder.TabIndex = 1;
            this.textBoxSelectedFolder.TextChanged += new System.EventHandler(this.textBoxSelectedFolder_TextChanged);
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectFolder.Location = new System.Drawing.Point(598, 16);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(66, 32);
            this.buttonSelectFolder.TabIndex = 2;
            this.buttonSelectFolder.Text = "Select";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Property";
            // 
            // comboBoxPropertys
            // 
            this.comboBoxPropertys.FormattingEnabled = true;
            this.comboBoxPropertys.Location = new System.Drawing.Point(72, 54);
            this.comboBoxPropertys.Name = "comboBoxPropertys";
            this.comboBoxPropertys.Size = new System.Drawing.Size(591, 28);
            this.comboBoxPropertys.TabIndex = 4;
            // 
            // buttonGenerateSearchMS
            // 
            this.buttonGenerateSearchMS.Location = new System.Drawing.Point(72, 88);
            this.buttonGenerateSearchMS.Name = "buttonGenerateSearchMS";
            this.buttonGenerateSearchMS.Size = new System.Drawing.Size(107, 34);
            this.buttonGenerateSearchMS.TabIndex = 5;
            this.buttonGenerateSearchMS.Text = "Generate";
            this.buttonGenerateSearchMS.UseVisualStyleBackColor = true;
            this.buttonGenerateSearchMS.Click += new System.EventHandler(this.buttonGenerateSearchMS_Click);
            // 
            // StackbyGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 134);
            this.Controls.Add(this.buttonGenerateSearchMS);
            this.Controls.Add(this.comboBoxPropertys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.textBoxSelectedFolder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StackbyGen";
            this.Text = "Stack by";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSelectedFolder;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPropertys;
        private System.Windows.Forms.Button buttonGenerateSearchMS;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}