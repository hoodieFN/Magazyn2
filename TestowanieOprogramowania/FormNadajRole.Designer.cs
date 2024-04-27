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
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBoxRole
            // 
            comboBoxRole.Anchor = AnchorStyles.None;
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Location = new Point(126, 85);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(121, 23);
            comboBoxRole.TabIndex = 0;
            // 
            // buttonNadajRole
            // 
            buttonNadajRole.Anchor = AnchorStyles.None;
            buttonNadajRole.BackColor = Color.Indigo;
            buttonNadajRole.Cursor = Cursors.Hand;
            buttonNadajRole.ForeColor = SystemColors.ControlLightLight;
            buttonNadajRole.Location = new Point(87, 151);
            buttonNadajRole.Name = "buttonNadajRole";
            buttonNadajRole.Size = new Size(88, 30);
            buttonNadajRole.TabIndex = 1;
            buttonNadajRole.Text = "Zapisz";
            buttonNadajRole.UseVisualStyleBackColor = false;
            buttonNadajRole.Click += buttonNadajRole_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(192, 151);
            button1.Name = "button1";
            button1.Size = new Size(88, 30);
            button1.TabIndex = 2;
            button1.Text = "Anuluj";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FormNadajRole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(376, 241);
            Controls.Add(button1);
            Controls.Add(buttonNadajRole);
            Controls.Add(comboBoxRole);
            Name = "FormNadajRole";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nadaj rolę";
            Load += FormNadajRole_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxRole;
        private Button buttonNadajRole;
        private Button button1;
    }
}