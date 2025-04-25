namespace TrunksCommander
{
    partial class BeallitasokForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TemaComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TallozButton = new System.Windows.Forms.Button();
            this.MentesButton = new System.Windows.Forms.Button();
            this.KonyvtarTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Téma";
            // 
            // TemaComboBox
            // 
            this.TemaComboBox.FormattingEnabled = true;
            this.TemaComboBox.Location = new System.Drawing.Point(222, 69);
            this.TemaComboBox.Name = "TemaComboBox";
            this.TemaComboBox.Size = new System.Drawing.Size(137, 21);
            this.TemaComboBox.TabIndex = 2;
            this.TemaComboBox.SelectedIndexChanged += new System.EventHandler(this.TemaComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Indítási könyvtár:";
            // 
            // TallozButton
            // 
            this.TallozButton.Location = new System.Drawing.Point(399, 136);
            this.TallozButton.Name = "TallozButton";
            this.TallozButton.Size = new System.Drawing.Size(86, 22);
            this.TallozButton.TabIndex = 6;
            this.TallozButton.Text = "Tallózás";
            this.TallozButton.UseVisualStyleBackColor = true;
            this.TallozButton.Click += new System.EventHandler(this.TallozButton_Click);
            // 
            // MentesButton
            // 
            this.MentesButton.Location = new System.Drawing.Point(124, 210);
            this.MentesButton.Name = "MentesButton";
            this.MentesButton.Size = new System.Drawing.Size(269, 23);
            this.MentesButton.TabIndex = 7;
            this.MentesButton.Text = "Mentés és alkalmazás";
            this.MentesButton.UseVisualStyleBackColor = true;
            this.MentesButton.Click += new System.EventHandler(this.MentesButton_Click);
            // 
            // KonyvtarTextBox
            // 
            this.KonyvtarTextBox.Location = new System.Drawing.Point(124, 136);
            this.KonyvtarTextBox.Name = "KonyvtarTextBox";
            this.KonyvtarTextBox.Size = new System.Drawing.Size(269, 20);
            this.KonyvtarTextBox.TabIndex = 8;
            // 
            // BeallitasokForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 316);
            this.Controls.Add(this.KonyvtarTextBox);
            this.Controls.Add(this.MentesButton);
            this.Controls.Add(this.TallozButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TemaComboBox);
            this.Controls.Add(this.label1);
            this.Name = "BeallitasokForm";
            this.Text = "Beállítások";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TemaComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button TallozButton;
        private System.Windows.Forms.Button MentesButton;
        private System.Windows.Forms.TextBox KonyvtarTextBox;
    }
}