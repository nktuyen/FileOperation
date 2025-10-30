namespace MoveTo
{
    partial class SettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radOverwrite = new System.Windows.Forms.RadioButton();
            this.radAsk = new System.Windows.Forms.RadioButton();
            this.radIgnoreExistFile = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonFolderDialogStyle = new System.Windows.Forms.RadioButton();
            this.radioButtonFileDialogStyle = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radOverwrite);
            this.groupBox1.Controls.Add(this.radAsk);
            this.groupBox1.Controls.Add(this.radIgnoreExistFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File existing action";
            // 
            // radOverwrite
            // 
            this.radOverwrite.AutoSize = true;
            this.radOverwrite.Location = new System.Drawing.Point(58, 66);
            this.radOverwrite.Name = "radOverwrite";
            this.radOverwrite.Size = new System.Drawing.Size(70, 17);
            this.radOverwrite.TabIndex = 0;
            this.radOverwrite.Text = "Overwrite";
            this.radOverwrite.UseVisualStyleBackColor = true;
            // 
            // radAsk
            // 
            this.radAsk.AutoSize = true;
            this.radAsk.Checked = true;
            this.radAsk.Location = new System.Drawing.Point(58, 43);
            this.radAsk.Name = "radAsk";
            this.radAsk.Size = new System.Drawing.Size(101, 17);
            this.radAsk.TabIndex = 0;
            this.radAsk.TabStop = true;
            this.radAsk.Text = "Ask to overwrite";
            this.radAsk.UseVisualStyleBackColor = true;
            // 
            // radIgnoreExistFile
            // 
            this.radIgnoreExistFile.AutoSize = true;
            this.radIgnoreExistFile.Location = new System.Drawing.Point(58, 20);
            this.radIgnoreExistFile.Name = "radIgnoreExistFile";
            this.radIgnoreExistFile.Size = new System.Drawing.Size(55, 17);
            this.radIgnoreExistFile.TabIndex = 0;
            this.radIgnoreExistFile.Text = "Ignore";
            this.radIgnoreExistFile.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(222, 17);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(50, 27);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonFolderDialogStyle);
            this.groupBox2.Controls.Add(this.radioButtonFileDialogStyle);
            this.groupBox2.Location = new System.Drawing.Point(12, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 69);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Folder browser dialog style";
            // 
            // radioButtonFolderDialogStyle
            // 
            this.radioButtonFolderDialogStyle.AutoSize = true;
            this.radioButtonFolderDialogStyle.Location = new System.Drawing.Point(42, 42);
            this.radioButtonFolderDialogStyle.Name = "radioButtonFolderDialogStyle";
            this.radioButtonFolderDialogStyle.Size = new System.Drawing.Size(113, 17);
            this.radioButtonFolderDialogStyle.TabIndex = 0;
            this.radioButtonFolderDialogStyle.Text = "Folder Dialog Style";
            this.radioButtonFolderDialogStyle.UseVisualStyleBackColor = true;
            // 
            // radioButtonFileDialogStyle
            // 
            this.radioButtonFileDialogStyle.AutoSize = true;
            this.radioButtonFileDialogStyle.Checked = true;
            this.radioButtonFileDialogStyle.Location = new System.Drawing.Point(42, 19);
            this.radioButtonFileDialogStyle.Name = "radioButtonFileDialogStyle";
            this.radioButtonFileDialogStyle.Size = new System.Drawing.Size(100, 17);
            this.radioButtonFileDialogStyle.TabIndex = 0;
            this.radioButtonFileDialogStyle.TabStop = true;
            this.radioButtonFileDialogStyle.Text = "File Dialog Style";
            this.radioButtonFileDialogStyle.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 201);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radOverwrite;
        private System.Windows.Forms.RadioButton radAsk;
        private System.Windows.Forms.RadioButton radIgnoreExistFile;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonFolderDialogStyle;
        private System.Windows.Forms.RadioButton radioButtonFileDialogStyle;
    }
}