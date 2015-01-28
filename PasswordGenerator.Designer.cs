namespace PasswordVault
{
    partial class PasswordGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordGenerator));
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.upperCheckBox = new System.Windows.Forms.CheckBox();
            this.lowerCheckBox = new System.Windows.Forms.CheckBox();
            this.symbolsCheckBox = new System.Windows.Forms.CheckBox();
            this.numbersCheckBox = new System.Windows.Forms.CheckBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.lengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.optionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.upperCheckBox);
            this.optionsGroupBox.Controls.Add(this.lowerCheckBox);
            this.optionsGroupBox.Controls.Add(this.symbolsCheckBox);
            this.optionsGroupBox.Controls.Add(this.numbersCheckBox);
            this.optionsGroupBox.Controls.Add(this.lengthLabel);
            this.optionsGroupBox.Controls.Add(this.lengthUpDown);
            this.optionsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(216, 75);
            this.optionsGroupBox.TabIndex = 0;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Options";
            // 
            // upperCheckBox
            // 
            this.upperCheckBox.AutoSize = true;
            this.upperCheckBox.Location = new System.Drawing.Point(78, 45);
            this.upperCheckBox.Name = "upperCheckBox";
            this.upperCheckBox.Size = new System.Drawing.Size(76, 17);
            this.upperCheckBox.TabIndex = 9;
            this.upperCheckBox.Text = "uppercase";
            this.upperCheckBox.UseVisualStyleBackColor = true;
            // 
            // lowerCheckBox
            // 
            this.lowerCheckBox.AutoSize = true;
            this.lowerCheckBox.Location = new System.Drawing.Point(78, 21);
            this.lowerCheckBox.Name = "lowerCheckBox";
            this.lowerCheckBox.Size = new System.Drawing.Size(74, 17);
            this.lowerCheckBox.TabIndex = 8;
            this.lowerCheckBox.Text = "lowercase";
            this.lowerCheckBox.UseVisualStyleBackColor = true;
            // 
            // symbolsCheckBox
            // 
            this.symbolsCheckBox.AutoSize = true;
            this.symbolsCheckBox.Location = new System.Drawing.Point(7, 44);
            this.symbolsCheckBox.Name = "symbolsCheckBox";
            this.symbolsCheckBox.Size = new System.Drawing.Size(63, 17);
            this.symbolsCheckBox.TabIndex = 7;
            this.symbolsCheckBox.Text = "symbols";
            this.symbolsCheckBox.UseVisualStyleBackColor = true;
            // 
            // numbersCheckBox
            // 
            this.numbersCheckBox.AutoSize = true;
            this.numbersCheckBox.Location = new System.Drawing.Point(7, 20);
            this.numbersCheckBox.Name = "numbersCheckBox";
            this.numbersCheckBox.Size = new System.Drawing.Size(66, 17);
            this.numbersCheckBox.TabIndex = 6;
            this.numbersCheckBox.Text = "numbers";
            this.numbersCheckBox.UseVisualStyleBackColor = true;
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(158, 22);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(36, 13);
            this.lengthLabel.TabIndex = 5;
            this.lengthLabel.Text = "length";
            // 
            // lengthUpDown
            // 
            this.lengthUpDown.Location = new System.Drawing.Point(157, 43);
            this.lengthUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.lengthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lengthUpDown.Name = "lengthUpDown";
            this.lengthUpDown.Size = new System.Drawing.Size(36, 20);
            this.lengthUpDown.TabIndex = 4;
            this.lengthUpDown.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.passwordTextbox.Location = new System.Drawing.Point(12, 97);
            this.passwordTextbox.MaxLength = 99;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.ReadOnly = true;
            this.passwordTextbox.Size = new System.Drawing.Size(216, 20);
            this.passwordTextbox.TabIndex = 1;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(237, 18);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(65, 69);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(237, 97);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(65, 20);
            this.acceptButton.TabIndex = 3;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // PasswordGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 129);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.optionsGroupBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordGenerator";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Password Generator";
            this.TopMost = true;
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.NumericUpDown lengthUpDown;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.CheckBox upperCheckBox;
        private System.Windows.Forms.CheckBox lowerCheckBox;
        private System.Windows.Forms.CheckBox symbolsCheckBox;
        private System.Windows.Forms.CheckBox numbersCheckBox;
    }
}