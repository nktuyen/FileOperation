namespace AttributesFilter
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
            this.lvwFIleAttributes = new System.Windows.Forms.ListView();
            this.colAttribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwFIleAttributes
            // 
            this.lvwFIleAttributes.CheckBoxes = true;
            this.lvwFIleAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAttribute});
            this.lvwFIleAttributes.FullRowSelect = true;
            this.lvwFIleAttributes.GridLines = true;
            this.lvwFIleAttributes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwFIleAttributes.Location = new System.Drawing.Point(12, 28);
            this.lvwFIleAttributes.MultiSelect = false;
            this.lvwFIleAttributes.Name = "lvwFIleAttributes";
            this.lvwFIleAttributes.ShowItemToolTips = true;
            this.lvwFIleAttributes.Size = new System.Drawing.Size(164, 158);
            this.lvwFIleAttributes.TabIndex = 0;
            this.lvwFIleAttributes.UseCompatibleStateImageBehavior = false;
            this.lvwFIleAttributes.View = System.Windows.Forms.View.Details;
            this.lvwFIleAttributes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwFIleAttributes_ItemChecked);
            // 
            // colAttribute
            // 
            this.colAttribute.Text = "Attribute";
            this.colAttribute.Width = 160;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(184, 28);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(44, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Attributes:";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 201);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lvwFIleAttributes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwFIleAttributes;
        private System.Windows.Forms.ColumnHeader colAttribute;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
    }
}