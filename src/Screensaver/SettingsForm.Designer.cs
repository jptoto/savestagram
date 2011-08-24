namespace ScreenSaver
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboShape = new System.Windows.Forms.ComboBox();
            this.cboSpeed = new System.Windows.Forms.ComboBox();
            this.lblCustomSpeed = new System.Windows.Forms.Label();
            this.mtxtCustomSpeed = new System.Windows.Forms.MaskedTextBox();
            this.chkUseTransparency = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.AccessibleDescription = "";
            this.btnOK.AccessibleName = "";
            this.btnOK.Location = new System.Drawing.Point(251, 168);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = "";
            this.btnCancel.AccessibleName = "";
            this.btnCancel.Location = new System.Drawing.Point(332, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboShape);
            this.groupBox1.Controls.Add(this.cboSpeed);
            this.groupBox1.Controls.Add(this.lblCustomSpeed);
            this.groupBox1.Controls.Add(this.mtxtCustomSpeed);
            this.groupBox1.Controls.Add(this.chkUseTransparency);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Draw speed:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Allowed shapes:";
            // 
            // cboShape
            // 
            this.cboShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShape.FormattingEnabled = true;
            this.cboShape.Items.AddRange(new object[] {
            "All",
            "Circles",
            "Ellipses",
            "Rectangles",
            "Squares"});
            this.cboShape.Location = new System.Drawing.Point(126, 17);
            this.cboShape.Name = "cboShape";
            this.cboShape.Size = new System.Drawing.Size(121, 21);
            this.cboShape.Sorted = true;
            this.cboShape.TabIndex = 1;
            // 
            // cboSpeed
            // 
            this.cboSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpeed.FormattingEnabled = true;
            this.cboSpeed.Items.AddRange(new object[] {
            "Slow",
            "Normal",
            "Fast",
            "Custom"});
            this.cboSpeed.Location = new System.Drawing.Point(126, 44);
            this.cboSpeed.Name = "cboSpeed";
            this.cboSpeed.Size = new System.Drawing.Size(121, 21);
            this.cboSpeed.TabIndex = 3;
            // 
            // lblCustomSpeed
            // 
            this.lblCustomSpeed.AutoSize = true;
            this.lblCustomSpeed.Location = new System.Drawing.Point(16, 74);
            this.lblCustomSpeed.Name = "lblCustomSpeed";
            this.lblCustomSpeed.Size = new System.Drawing.Size(103, 13);
            this.lblCustomSpeed.TabIndex = 4;
            this.lblCustomSpeed.Text = "Custom draw speed:";
            // 
            // mtxtCustomSpeed
            // 
            this.mtxtCustomSpeed.Location = new System.Drawing.Point(125, 71);
            this.mtxtCustomSpeed.Mask = "00000000";
            this.mtxtCustomSpeed.Name = "mtxtCustomSpeed";
            this.mtxtCustomSpeed.Size = new System.Drawing.Size(71, 20);
            this.mtxtCustomSpeed.TabIndex = 5;
            this.mtxtCustomSpeed.ValidatingType = typeof(int);
            // 
            // chkUseTransparency
            // 
            this.chkUseTransparency.AutoSize = true;
            this.chkUseTransparency.Location = new System.Drawing.Point(20, 112);
            this.chkUseTransparency.Name = "chkUseTransparency";
            this.chkUseTransparency.Size = new System.Drawing.Size(113, 17);
            this.chkUseTransparency.TabIndex = 6;
            this.chkUseTransparency.Text = "Use Transparency";
            this.chkUseTransparency.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AccessibleDescription = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 199);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen Saver Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkUseTransparency;
        private System.Windows.Forms.ComboBox cboShape;
        private System.Windows.Forms.ComboBox cboSpeed;
        private System.Windows.Forms.Label lblCustomSpeed;
        private System.Windows.Forms.MaskedTextBox mtxtCustomSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}