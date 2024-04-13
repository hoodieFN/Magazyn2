namespace TestowanieOprogramowania
{
    partial class FormNadajRole
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
            comboBoxRole = new ComboBox();
            buttonNadajRole = new Button();
            SuspendLayout();
            // 
            // comboBoxRole
            // 
            comboBoxRole.Anchor = AnchorStyles.None;
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Location = new Point(123, 91);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(121, 23);
            comboBoxRole.TabIndex = 0;
            // 
            // buttonNadajRole
            // 
            buttonNadajRole.Anchor = AnchorStyles.None;
            buttonNadajRole.BackColor = Color.Indigo;
            buttonNadajRole.ForeColor = SystemColors.ControlLightLight;
            buttonNadajRole.Location = new Point(146, 143);
            buttonNadajRole.Name = "buttonNadajRole";
            buttonNadajRole.Size = new Size(75, 23);
            buttonNadajRole.TabIndex = 1;
            buttonNadajRole.Text = "Zapisz";
            buttonNadajRole.UseVisualStyleBackColor = false;
            buttonNadajRole.Click += buttonNadajRole_Click;
            // 
            // FormNadajRole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(371, 252);
            Controls.Add(buttonNadajRole);
            Controls.Add(comboBoxRole);
            Name = "FormNadajRole";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormNadajRole";
            Load += FormNadajRole_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxRole;
        private Button buttonNadajRole;
    }
}