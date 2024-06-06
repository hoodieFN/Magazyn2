namespace TestowanieOprogramowania
{
    partial class FormZmianaPoResecie
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
            label1 = new Label();
            textBoxNewPassword2 = new TextBox();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            textBoxNewPassword = new TextBox();
            textBoxHasloZMaila = new TextBox();
            label4 = new Label();
            textBoxLogin = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(294, 252);
            label1.Name = "label1";
            label1.Size = new Size(126, 17);
            label1.TabIndex = 23;
            label1.Text = "Powtórz nowe hasło";
            // 
            // textBoxNewPassword2
            // 
            textBoxNewPassword2.Anchor = AnchorStyles.None;
            textBoxNewPassword2.BackColor = Color.LightGray;
            textBoxNewPassword2.BorderStyle = BorderStyle.None;
            textBoxNewPassword2.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNewPassword2.Location = new Point(294, 272);
            textBoxNewPassword2.Name = "textBoxNewPassword2";
            textBoxNewPassword2.Size = new Size(216, 26);
            textBoxNewPassword2.TabIndex = 22;
            textBoxNewPassword2.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(294, 334);
            button1.Name = "button1";
            button1.Size = new Size(216, 36);
            button1.TabIndex = 21;
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
            label3.Location = new Point(294, 185);
            label3.Name = "label3";
            label3.Size = new Size(78, 17);
            label3.TabIndex = 20;
            label3.Text = "Nowe hasło";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(294, 121);
            label2.Name = "label2";
            label2.Size = new Size(85, 17);
            label2.TabIndex = 19;
            label2.Text = "Hasło z maila";
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.Anchor = AnchorStyles.None;
            textBoxNewPassword.BackColor = Color.LightGray;
            textBoxNewPassword.BorderStyle = BorderStyle.None;
            textBoxNewPassword.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNewPassword.Location = new Point(294, 205);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.Size = new Size(216, 26);
            textBoxNewPassword.TabIndex = 18;
            textBoxNewPassword.UseSystemPasswordChar = true;
            // 
            // textBoxHasloZMaila
            // 
            textBoxHasloZMaila.Anchor = AnchorStyles.None;
            textBoxHasloZMaila.BackColor = Color.LightGray;
            textBoxHasloZMaila.BorderStyle = BorderStyle.None;
            textBoxHasloZMaila.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxHasloZMaila.Location = new Point(294, 141);
            textBoxHasloZMaila.Name = "textBoxHasloZMaila";
            textBoxHasloZMaila.Size = new Size(216, 26);
            textBoxHasloZMaila.TabIndex = 17;
            textBoxHasloZMaila.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(294, 60);
            label4.Name = "label4";
            label4.Size = new Size(40, 17);
            label4.TabIndex = 25;
            label4.Text = "Login";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Anchor = AnchorStyles.None;
            textBoxLogin.BackColor = Color.LightGray;
            textBoxLogin.BorderStyle = BorderStyle.None;
            textBoxLogin.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLogin.Location = new Point(294, 80);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(216, 26);
            textBoxLogin.TabIndex = 24;
            // 
            // FormZmianaPoResecie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(textBoxLogin);
            Controls.Add(label1);
            Controls.Add(textBoxNewPassword2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxNewPassword);
            Controls.Add(textBoxHasloZMaila);
            Name = "FormZmianaPoResecie";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormZmianaPoResecie";
            Load += FormZmianaPoResecie_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxNewPassword2;
        private Button button1;
        private Label label3;
        private Label label2;
        private TextBox textBoxNewPassword;
        private TextBox textBoxHasloZMaila;
        private Label label4;
        private TextBox textBoxLogin;
    }
}