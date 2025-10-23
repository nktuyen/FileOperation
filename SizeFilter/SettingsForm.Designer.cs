namespace SizeFilter
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
            this.components = new System.ComponentModel.Container();
            this.cbUnitFrom = new System.Windows.Forms.ComboBox();
            this.cbUnitTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSizeFrom = new System.Windows.Forms.TextBox();
            this.contextMenuStripFrom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtSizeTo = new System.Windows.Forms.TextBox();
            this.contextMenuStripTo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chkSizeTo = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbUnitFrom
            // 
            this.cbUnitFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnitFrom.FormattingEnabled = true;
            this.cbUnitFrom.Items.AddRange(new object[] {
            "byte(s)",
            "KB",
            "MB",
            "GB",
            "TB",
            "PB"});
            this.cbUnitFrom.Location = new System.Drawing.Point(148, 30);
            this.cbUnitFrom.Name = "cbUnitFrom";
            this.cbUnitFrom.Size = new System.Drawing.Size(60, 21);
            this.cbUnitFrom.TabIndex = 0;
            this.cbUnitFrom.SelectedIndexChanged += new System.EventHandler(this.cbUnitFrom_SelectedIndexChanged);
            // 
            // cbUnitTo
            // 
            this.cbUnitTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnitTo.Enabled = false;
            this.cbUnitTo.FormattingEnabled = true;
            this.cbUnitTo.Items.AddRange(new object[] {
            "byte(s)",
            "KB",
            "MB",
            "GB",
            "TB",
            "PB"});
            this.cbUnitTo.Location = new System.Drawing.Point(369, 30);
            this.cbUnitTo.Name = "cbUnitTo";
            this.cbUnitTo.Size = new System.Drawing.Size(60, 21);
            this.cbUnitTo.TabIndex = 0;
            this.cbUnitTo.SelectedIndexChanged += new System.EventHandler(this.cbUnitTo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From:";
            // 
            // txtSizeFrom
            // 
            this.txtSizeFrom.ContextMenuStrip = this.contextMenuStripFrom;
            this.txtSizeFrom.Location = new System.Drawing.Point(47, 30);
            this.txtSizeFrom.MaxLength = 20;
            this.txtSizeFrom.Name = "txtSizeFrom";
            this.txtSizeFrom.Size = new System.Drawing.Size(100, 20);
            this.txtSizeFrom.TabIndex = 2;
            this.txtSizeFrom.Text = "0";
            this.txtSizeFrom.TextChanged += new System.EventHandler(this.txtSizeFrom_TextChanged);
            this.txtSizeFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSizeFrom_KeyPress);
            // 
            // contextMenuStripFrom
            // 
            this.contextMenuStripFrom.Name = "contextMenuStripFrom";
            this.contextMenuStripFrom.Size = new System.Drawing.Size(61, 4);
            // 
            // txtSizeTo
            // 
            this.txtSizeTo.ContextMenuStrip = this.contextMenuStripTo;
            this.txtSizeTo.Enabled = false;
            this.txtSizeTo.Location = new System.Drawing.Point(268, 30);
            this.txtSizeTo.MaxLength = 20;
            this.txtSizeTo.Name = "txtSizeTo";
            this.txtSizeTo.Size = new System.Drawing.Size(100, 20);
            this.txtSizeTo.TabIndex = 4;
            this.txtSizeTo.TextChanged += new System.EventHandler(this.txtSizeTo_TextChanged);
            this.txtSizeTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSizeTo_KeyPress);
            // 
            // contextMenuStripTo
            // 
            this.contextMenuStripTo.Name = "contextMenuStripTo";
            this.contextMenuStripTo.Size = new System.Drawing.Size(61, 4);
            // 
            // chkSizeTo
            // 
            this.chkSizeTo.AutoSize = true;
            this.chkSizeTo.Location = new System.Drawing.Point(224, 32);
            this.chkSizeTo.Name = "chkSizeTo";
            this.chkSizeTo.Size = new System.Drawing.Size(42, 17);
            this.chkSizeTo.TabIndex = 5;
            this.chkSizeTo.Text = "To:";
            this.chkSizeTo.UseVisualStyleBackColor = true;
            this.chkSizeTo.CheckedChanged += new System.EventHandler(this.chkSizeTo_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(185, 68);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 30);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 106);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkSizeTo);
            this.Controls.Add(this.txtSizeTo);
            this.Controls.Add(this.txtSizeFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUnitTo);
            this.Controls.Add(this.cbUnitFrom);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUnitFrom;
        private System.Windows.Forms.ComboBox cbUnitTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSizeFrom;
        private System.Windows.Forms.TextBox txtSizeTo;
        private System.Windows.Forms.CheckBox chkSizeTo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFrom;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTo;
    }
}