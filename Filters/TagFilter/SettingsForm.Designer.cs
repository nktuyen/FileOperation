namespace TagFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.lvwMediaTypes = new System.Windows.Forms.ListView();
            this.colAttributes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.upDownSecondMax = new System.Windows.Forms.NumericUpDown();
            this.upDownMinuteMax = new System.Windows.Forms.NumericUpDown();
            this.upDownSecondMin = new System.Windows.Forms.NumericUpDown();
            this.upDownHourMax = new System.Windows.Forms.NumericUpDown();
            this.upDownMinuteMin = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.upDownHourMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSecondMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMinuteMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSecondMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownHourMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMinuteMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownHourMin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(468, 295);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lvwMediaTypes
            // 
            this.lvwMediaTypes.CheckBoxes = true;
            this.lvwMediaTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAttributes});
            this.lvwMediaTypes.GridLines = true;
            this.lvwMediaTypes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwMediaTypes.HideSelection = false;
            this.lvwMediaTypes.Location = new System.Drawing.Point(12, 23);
            this.lvwMediaTypes.MultiSelect = false;
            this.lvwMediaTypes.Name = "lvwMediaTypes";
            this.lvwMediaTypes.ShowGroups = false;
            this.lvwMediaTypes.ShowItemToolTips = true;
            this.lvwMediaTypes.Size = new System.Drawing.Size(165, 88);
            this.lvwMediaTypes.TabIndex = 3;
            this.lvwMediaTypes.UseCompatibleStateImageBehavior = false;
            this.lvwMediaTypes.View = System.Windows.Forms.View.Details;
            // 
            // colAttributes
            // 
            this.colAttributes.Text = "Attribute";
            this.colAttributes.Width = 160;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Media Types:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.upDownSecondMax);
            this.groupBox1.Controls.Add(this.upDownMinuteMax);
            this.groupBox1.Controls.Add(this.upDownSecondMin);
            this.groupBox1.Controls.Add(this.upDownHourMax);
            this.groupBox1.Controls.Add(this.upDownMinuteMin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.upDownHourMin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(183, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 62);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Duration";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(307, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Second";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(136, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Second";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(266, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Minute";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(95, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Minute";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(234, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Hour";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hour";
            // 
            // upDownSecondMax
            // 
            this.upDownSecondMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upDownSecondMax.Location = new System.Drawing.Point(314, 32);
            this.upDownSecondMax.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.upDownSecondMax.Name = "upDownSecondMax";
            this.upDownSecondMax.Size = new System.Drawing.Size(40, 20);
            this.upDownSecondMax.TabIndex = 1;
            // 
            // upDownMinuteMax
            // 
            this.upDownMinuteMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upDownMinuteMax.Location = new System.Drawing.Point(274, 32);
            this.upDownMinuteMax.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.upDownMinuteMax.Name = "upDownMinuteMax";
            this.upDownMinuteMax.Size = new System.Drawing.Size(40, 20);
            this.upDownMinuteMax.TabIndex = 1;
            // 
            // upDownSecondMin
            // 
            this.upDownSecondMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upDownSecondMin.Location = new System.Drawing.Point(143, 32);
            this.upDownSecondMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.upDownSecondMin.Name = "upDownSecondMin";
            this.upDownSecondMin.Size = new System.Drawing.Size(40, 20);
            this.upDownSecondMin.TabIndex = 1;
            // 
            // upDownHourMax
            // 
            this.upDownHourMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upDownHourMax.Location = new System.Drawing.Point(234, 32);
            this.upDownHourMax.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.upDownHourMax.Name = "upDownHourMax";
            this.upDownHourMax.Size = new System.Drawing.Size(40, 20);
            this.upDownHourMax.TabIndex = 1;
            this.upDownHourMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // upDownMinuteMin
            // 
            this.upDownMinuteMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upDownMinuteMin.Location = new System.Drawing.Point(103, 32);
            this.upDownMinuteMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.upDownMinuteMin.Name = "upDownMinuteMin";
            this.upDownMinuteMin.Size = new System.Drawing.Size(40, 20);
            this.upDownMinuteMin.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(208, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "To:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // upDownHourMin
            // 
            this.upDownHourMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upDownHourMin.Location = new System.Drawing.Point(63, 32);
            this.upDownHourMin.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.upDownHourMin.Name = "upDownHourMin";
            this.upDownHourMin.Size = new System.Drawing.Size(40, 20);
            this.upDownHourMin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "From:";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 330);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwMediaTypes);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSecondMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMinuteMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSecondMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownHourMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMinuteMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownHourMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView lvwMediaTypes;
        private System.Windows.Forms.ColumnHeader colAttributes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown upDownHourMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown upDownSecondMin;
        private System.Windows.Forms.NumericUpDown upDownMinuteMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown upDownSecondMax;
        private System.Windows.Forms.NumericUpDown upDownMinuteMax;
        private System.Windows.Forms.NumericUpDown upDownHourMax;
        private System.Windows.Forms.Label label6;
    }
}