namespace TestowanieOprogramowania
{
    partial class FormZmienHaslo
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
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            textBoxNewPassword = new TextBox();
            textBoxOldPassword = new TextBox();
            label1 = new Label();
            textBoxNewPassword2 = new TextBox();
            label4 = new Label();
            comboBoxUsers = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(336, 515);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(247, 48);
            button1.TabIndex = 14;
            button1.Text = "ZMIEN HASŁO";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(336, 316);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 13;
            label3.Text = "Nowe hasło";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(336, 231);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 12;
            label2.Text = "Stare hasło";
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.Anchor = AnchorStyles.None;
            textBoxNewPassword.BackColor = Color.LightGray;
            textBoxNewPassword.BorderStyle = BorderStyle.None;
            textBoxNewPassword.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNewPassword.Location = new Point(336, 343);
            textBoxNewPassword.Margin = new Padding(3, 4, 3, 4);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.Size = new Size(247, 33);
            textBoxNewPassword.TabIndex = 11;
            textBoxNewPassword.UseSystemPasswordChar = true;
            // 
            // textBoxOldPassword
            // 
            textBoxOldPassword.Anchor = AnchorStyles.None;
            textBoxOldPassword.BackColor = Color.LightGray;
            textBoxOldPassword.BorderStyle = BorderStyle.None;
            textBoxOldPassword.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxOldPassword.Location = new Point(336, 257);
            textBoxOldPassword.Margin = new Padding(3, 4, 3, 4);
            textBoxOldPassword.Name = "textBoxOldPassword";
            textBoxOldPassword.Size = new Size(247, 33);
            textBoxOldPassword.TabIndex = 10;
            textBoxOldPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(336, 405);
            label1.Name = "label1";
            label1.Size = new Size(158, 20);
            label1.TabIndex = 16;
            label1.Text = "Powtórz nowe hasło";
            // 
            // textBoxNewPassword2
            // 
            textBoxNewPassword2.Anchor = AnchorStyles.None;
            textBoxNewPassword2.BackColor = Color.LightGray;
            textBoxNewPassword2.BorderStyle = BorderStyle.None;
            textBoxNewPassword2.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNewPassword2.Location = new Point(336, 432);
            textBoxNewPassword2.Margin = new Padding(3, 4, 3, 4);
            textBoxNewPassword2.Name = "textBoxNewPassword2";
            textBoxNewPassword2.Size = new Size(247, 33);
            textBoxNewPassword2.TabIndex = 15;
            textBoxNewPassword2.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(336, 147);
            label4.Name = "label4";
            label4.Size = new Size(142, 20);
            label4.TabIndex = 18;
            label4.Text = "Login użytkownika";
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.Anchor = AnchorStyles.None;
            comboBoxUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(336, 173);
            comboBoxUsers.Margin = new Padding(3, 4, 3, 4);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(246, 28);
            comboBoxUsers.TabIndex = 19;
            // 
            // FormZmienHaslo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 37, 37);
            ClientSize = new Size(985, 739);
            Controls.Add(comboBoxUsers);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(textBoxNewPassword2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxNewPassword);
            Controls.Add(textBoxOldPassword);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormZmienHaslo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zmień hasło";
            Load += FormZmienHaslo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label3;
        private Label label2;
        private TextBox textBoxNewPassword;
        private TextBox textBoxOldPassword;
        private Label label1;
        private TextBox textBoxNewPassword2;
        private Label label4;
        private ComboBox comboBoxUsers;
    }
}