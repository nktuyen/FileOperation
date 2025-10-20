namespace FileOperation
{
    partial class DeleteOperatorSettingsForm
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
            this.radMoveToTrash = new System.Windows.Forms.RadioButton();
            this.radPermanentDelete = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radMoveToTrash
            // 
            this.radMoveToTrash.AutoSize = true;
            this.radMoveToTrash.Checked = true;
            this.radMoveToTrash.Location = new System.Drawing.Point(32, 23);
            this.radMoveToTrash.Name = "radMoveToTrash";
            this.radMoveToTrash.Size = new System.Drawing.Size(90, 17);
            this.radMoveToTrash.TabIndex = 0;
            this.radMoveToTrash.TabStop = true;
            this.radMoveToTrash.Text = "Move to &trash";
            this.radMoveToTrash.UseVisualStyleBackColor = true;
            // 
            // radPermanentDelete
            // 
            this.radPermanentDelete.AutoSize = true;
            this.radPermanentDelete.Location = new System.Drawing.Point(32, 46);
            this.radPermanentDelete.Name = "radPermanentDelete";
            this.radPermanentDelete.Size = new System.Drawing.Size(108, 17);
            this.radPermanentDelete.TabIndex = 1;
            this.radPermanentDelete.Text = "Permanent delete";
            this.radPermanentDelete.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(172, 23);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 29);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // DeleteOperatorSettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 78);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.radPermanentDelete);
            this.Controls.Add(this.radMoveToTrash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteOperatorSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.DeleteOperatorSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radMoveToTrash;
        private System.Windows.Forms.RadioButton radPermanentDelete;
        private System.Windows.Forms.Button btnOK;
    }
}