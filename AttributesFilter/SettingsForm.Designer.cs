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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radEquality = new System.Windows.Forms.RadioButton();
            this.radContains = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Attributes:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radContains);
            this.groupBox1.Controls.Add(this.radEquality);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 42);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matching mode";
            // 
            // radEquality
            // 
            this.radEquality.AutoSize = true;
            this.radEquality.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radEquality.Location = new System.Drawing.Point(25, 19);
            this.radEquality.Name = "radEquality";
            this.radEquality.Size = new System.Drawing.Size(52, 17);
            this.radEquality.TabIndex = 0;
            this.radEquality.Text = "Exact";
            this.radEquality.UseVisualStyleBackColor = true;
            this.radEquality.CheckedChanged += new System.EventHandler(this.radEquality_CheckedChanged);
            // 
            // radContains
            // 
            this.radContains.AutoSize = true;
            this.radContains.Checked = true;
            this.radContains.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radContains.Location = new System.Drawing.Point(83, 19);
            this.radContains.Name = "radContains";
            this.radContains.Size = new System.Drawing.Size(66, 17);
            this.radContains.TabIndex = 0;
            this.radContains.TabStop = true;
            this.radContains.Text = "Contains";
            this.radContains.UseVisualStyleBackColor = true;
            this.radContains.CheckedChanged += new System.EventHandler(this.radContains_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 247);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwFIleAttributes;
        private System.Windows.Forms.ColumnHeader colAttribute;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radEquality;
        private System.Windows.Forms.RadioButton radContains;
    }
}