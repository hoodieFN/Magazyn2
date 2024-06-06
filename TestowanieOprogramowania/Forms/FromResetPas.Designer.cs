namespace TestowanieOprogramowania
{
    partial class FromResetPas
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
            label3 = new Label();
            label2 = new Label();
            textBoxMail = new TextBox();
            textBoxUsername = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(103, 123);
            label3.Name = "label3";
            label3.Size = new Size(43, 17);
            label3.TabIndex = 8;
            label3.Text = "E-mail";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(103, 59);
            label2.Name = "label2";
            label2.Size = new Size(40, 17);
            label2.TabIndex = 7;
            label2.Text = "Login";
            // 
            // textBoxMail
            // 
            textBoxMail.Anchor = AnchorStyles.None;
            textBoxMail.BackColor = Color.LightGray;
            textBoxMail.BorderStyle = BorderStyle.None;
            textBoxMail.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMail.Location = new Point(103, 143);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.Size = new Size(216, 26);
            textBoxMail.TabIndex = 6;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Anchor = AnchorStyles.None;
            textBoxUsername.BackColor = Color.LightGray;
            textBoxUsername.BorderStyle = BorderStyle.None;
            textBoxUsername.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUsername.Location = new Point(103, 79);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(216, 26);
            textBoxUsername.TabIndex = 5;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(103, 201);
            button1.Name = "button1";
            button1.Size = new Size(216, 36);
            button1.TabIndex = 9;
            button1.Text = "ZRESETUJ HASŁO";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FromResetPas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(435, 322);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxMail);
            Controls.Add(textBoxUsername);
            Name = "FromResetPas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resetuj hasło";
            Load += FromResetPas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private TextBox textBoxMail;
        private TextBox textBoxUsername;
        private Button button1;
    }
}