namespace VectorClock
{
    partial class ClockForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
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
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.HrsFontLabel = new System.Windows.Forms.Label();
            this.BMinFontLabel = new System.Windows.Forms.Label();
            this.MinFontLabel = new System.Windows.Forms.Label();
            this.ShowCurrentTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.TimerObject = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // HrsFontLabel
            // 
            this.HrsFontLabel.AutoSize = true;
            this.HrsFontLabel.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HrsFontLabel.Location = new System.Drawing.Point(7, 47);
            this.HrsFontLabel.Name = "HrsFontLabel";
            this.HrsFontLabel.Size = new System.Drawing.Size(219, 46);
            this.HrsFontLabel.TabIndex = 5;
            this.HrsFontLabel.Text = "Font: Hours";
            this.HrsFontLabel.Visible = false;
            // 
            // BMinFontLabel
            // 
            this.BMinFontLabel.AutoSize = true;
            this.BMinFontLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BMinFontLabel.Location = new System.Drawing.Point(11, 26);
            this.BMinFontLabel.Name = "BMinFontLabel";
            this.BMinFontLabel.Size = new System.Drawing.Size(199, 18);
            this.BMinFontLabel.TabIndex = 4;
            this.BMinFontLabel.Text = "Font: Highlighted Minutes";
            this.BMinFontLabel.Visible = false;
            // 
            // MinFontLabel
            // 
            this.MinFontLabel.AutoSize = true;
            this.MinFontLabel.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinFontLabel.ForeColor = System.Drawing.Color.DimGray;
            this.MinFontLabel.Location = new System.Drawing.Point(12, 9);
            this.MinFontLabel.Name = "MinFontLabel";
            this.MinFontLabel.Size = new System.Drawing.Size(138, 17);
            this.MinFontLabel.TabIndex = 3;
            this.MinFontLabel.Text = "Font: Normal Minutes";
            this.MinFontLabel.Visible = false;
            // 
            // ShowCurrentTimeCheckBox
            // 
            this.ShowCurrentTimeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowCurrentTimeCheckBox.AutoSize = true;
            this.ShowCurrentTimeCheckBox.Checked = true;
            this.ShowCurrentTimeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowCurrentTimeCheckBox.Location = new System.Drawing.Point(676, 12);
            this.ShowCurrentTimeCheckBox.Name = "ShowCurrentTimeCheckBox";
            this.ShowCurrentTimeCheckBox.Size = new System.Drawing.Size(112, 21);
            this.ShowCurrentTimeCheckBox.TabIndex = 6;
            this.ShowCurrentTimeCheckBox.Text = "Current Time";
            this.ShowCurrentTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // TimerObject
            // 
            this.TimerObject.Enabled = true;
            this.TimerObject.Interval = 10;
            this.TimerObject.Tick += new System.EventHandler(this.TimerObject_Tick);
            // 
            // ClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 593);
            this.Controls.Add(this.ShowCurrentTimeCheckBox);
            this.Controls.Add(this.HrsFontLabel);
            this.Controls.Add(this.BMinFontLabel);
            this.Controls.Add(this.MinFontLabel);
            this.DoubleBuffered = true;
            this.Name = "ClockForm";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ClockForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HrsFontLabel;
        private System.Windows.Forms.Label BMinFontLabel;
        private System.Windows.Forms.Label MinFontLabel;
        private System.Windows.Forms.CheckBox ShowCurrentTimeCheckBox;
        private System.Windows.Forms.Timer TimerObject;
    }
}

