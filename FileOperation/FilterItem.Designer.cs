namespace FileOperation
{
    partial class FilterItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbFilterEnabled = new System.Windows.Forms.CheckBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnFilterSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbFilterEnabled
            // 
            this.cbFilterEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFilterEnabled.AutoSize = true;
            this.cbFilterEnabled.Location = new System.Drawing.Point(0, 15);
            this.cbFilterEnabled.Name = "cbFilterEnabled";
            this.cbFilterEnabled.Size = new System.Drawing.Size(94, 17);
            this.cbFilterEnabled.TabIndex = 0;
            this.cbFilterEnabled.Text = "FIlter by Name";
            this.cbFilterEnabled.UseVisualStyleBackColor = true;
            this.cbFilterEnabled.CheckedChanged += new System.EventHandler(this.cbFilterEnabled_CheckedChanged);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAbout.Image = global::FileOperation.Properties.Resources.Information;
            this.btnAbout.Location = new System.Drawing.Point(313, 9);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(36, 36);
            this.btnAbout.TabIndex = 1;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnFilterSettings
            // 
            this.btnFilterSettings.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnFilterSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFilterSettings.Image = global::FileOperation.Properties.Resources.Settings;
            this.btnFilterSettings.Location = new System.Drawing.Point(346, 9);
            this.btnFilterSettings.Name = "btnFilterSettings";
            this.btnFilterSettings.Size = new System.Drawing.Size(36, 36);
            this.btnFilterSettings.TabIndex = 1;
            this.btnFilterSettings.UseVisualStyleBackColor = true;
            this.btnFilterSettings.Click += new System.EventHandler(this.btnFilterSettings_Click);
            // 
            // FilterItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnFilterSettings);
            this.Controls.Add(this.cbFilterEnabled);
            this.Name = "FilterItem";
            this.Size = new System.Drawing.Size(382, 55);
            this.Load += new System.EventHandler(this.FilterItem_Load);
            this.SizeChanged += new System.EventHandler(this.FilterItem_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbFilterEnabled;
        private System.Windows.Forms.Button btnFilterSettings;
        private System.Windows.Forms.Button btnAbout;
    }
}
