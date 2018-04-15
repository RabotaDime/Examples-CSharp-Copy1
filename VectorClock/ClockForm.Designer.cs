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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // HrsFontLabel
            // 
            this.HrsFontLabel.AutoSize = true;
            this.HrsFontLabel.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HrsFontLabel.Location = new System.Drawing.Point(11, 275);
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
            this.BMinFontLabel.Location = new System.Drawing.Point(15, 247);
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
            this.MinFontLabel.Location = new System.Drawing.Point(16, 225);
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
            this.ShowCurrentTimeCheckBox.Location = new System.Drawing.Point(486, 8);
            this.ShowCurrentTimeCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShowCurrentTimeCheckBox.Name = "ShowCurrentTimeCheckBox";
            this.ShowCurrentTimeCheckBox.Size = new System.Drawing.Size(129, 25);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.BackColor = System.Drawing.SystemColors.Control;
            this.numericUpDown1.DecimalPlaces = 3;
            this.numericUpDown1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(12, 486);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(90, 32);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericInput_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown2.BackColor = System.Drawing.SystemColors.Control;
            this.numericUpDown2.DecimalPlaces = 3;
            this.numericUpDown2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numericUpDown2.Location = new System.Drawing.Point(12, 517);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(90, 32);
            this.numericUpDown2.TabIndex = 9;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.NumericInput_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown3.BackColor = System.Drawing.SystemColors.Control;
            this.numericUpDown3.DecimalPlaces = 3;
            this.numericUpDown3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numericUpDown3.Location = new System.Drawing.Point(12, 548);
            this.numericUpDown3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(90, 32);
            this.numericUpDown3.TabIndex = 9;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.NumericInput_ValueChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(8, 461);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 21);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Reset";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // ClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 593);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowCurrentTimeCheckBox);
            this.Controls.Add(this.HrsFontLabel);
            this.Controls.Add(this.BMinFontLabel);
            this.Controls.Add(this.MinFontLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ClockForm";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ClockForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HrsFontLabel;
        private System.Windows.Forms.Label BMinFontLabel;
        private System.Windows.Forms.Label MinFontLabel;
        private System.Windows.Forms.CheckBox ShowCurrentTimeCheckBox;
        private System.Windows.Forms.Timer TimerObject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

