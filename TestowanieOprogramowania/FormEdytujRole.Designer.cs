﻿namespace TestowanieOprogramowania
{
    partial class FormEdytujRole
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
            comboBoxObsluga = new ComboBox();
            comboBoxZarzadzanie = new ComboBox();
            comboBoxNaprawa = new ComboBox();
            comboBoxPakowanie = new ComboBox();
            comboBoxDostep = new ComboBox();
            buttonAnuluj = new Button();
            buttonZapisz = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBoxNazwa = new TextBox();
            SuspendLayout();
            // 
            // comboBoxObsluga
            // 
            comboBoxObsluga.FormattingEnabled = true;
            comboBoxObsluga.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxObsluga.Location = new Point(554, 260);
            comboBoxObsluga.Name = "comboBoxObsluga";
            comboBoxObsluga.Size = new Size(114, 28);
            comboBoxObsluga.TabIndex = 82;
            // 
            // comboBoxZarzadzanie
            // 
            comboBoxZarzadzanie.FormattingEnabled = true;
            comboBoxZarzadzanie.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxZarzadzanie.Location = new Point(554, 338);
            comboBoxZarzadzanie.Name = "comboBoxZarzadzanie";
            comboBoxZarzadzanie.Size = new Size(114, 28);
            comboBoxZarzadzanie.TabIndex = 81;
            // 
            // comboBoxNaprawa
            // 
            comboBoxNaprawa.FormattingEnabled = true;
            comboBoxNaprawa.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxNaprawa.Location = new Point(554, 403);
            comboBoxNaprawa.Name = "comboBoxNaprawa";
            comboBoxNaprawa.Size = new Size(114, 28);
            comboBoxNaprawa.TabIndex = 80;
            // 
            // comboBoxPakowanie
            // 
            comboBoxPakowanie.FormattingEnabled = true;
            comboBoxPakowanie.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxPakowanie.Location = new Point(554, 475);
            comboBoxPakowanie.Name = "comboBoxPakowanie";
            comboBoxPakowanie.Size = new Size(114, 28);
            comboBoxPakowanie.TabIndex = 79;
            // 
            // comboBoxDostep
            // 
            comboBoxDostep.FormattingEnabled = true;
            comboBoxDostep.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxDostep.Location = new Point(554, 190);
            comboBoxDostep.Name = "comboBoxDostep";
            comboBoxDostep.Size = new Size(114, 28);
            comboBoxDostep.TabIndex = 78;
            // 
            // buttonAnuluj
            // 
            buttonAnuluj.Anchor = AnchorStyles.None;
            buttonAnuluj.BackColor = Color.Indigo;
            buttonAnuluj.Cursor = Cursors.Hand;
            buttonAnuluj.ForeColor = SystemColors.ButtonHighlight;
            buttonAnuluj.Location = new Point(545, 559);
            buttonAnuluj.Margin = new Padding(3, 4, 3, 4);
            buttonAnuluj.Name = "buttonAnuluj";
            buttonAnuluj.Size = new Size(114, 36);
            buttonAnuluj.TabIndex = 77;
            buttonAnuluj.Text = "Anuluj";
            buttonAnuluj.UseVisualStyleBackColor = false;
            buttonAnuluj.Click += buttonAnuluj_Click;
            // 
            // buttonZapisz
            // 
            buttonZapisz.Anchor = AnchorStyles.None;
            buttonZapisz.BackColor = Color.Indigo;
            buttonZapisz.Cursor = Cursors.Hand;
            buttonZapisz.ForeColor = SystemColors.ButtonFace;
            buttonZapisz.Location = new Point(384, 559);
            buttonZapisz.Margin = new Padding(3, 4, 3, 4);
            buttonZapisz.Name = "buttonZapisz";
            buttonZapisz.Size = new Size(110, 36);
            buttonZapisz.TabIndex = 76;
            buttonZapisz.Text = "Zapisz";
            buttonZapisz.UseVisualStyleBackColor = false;
            buttonZapisz.Click += buttonZapisz_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(325, 483);
            label7.Name = "label7";
            label7.Size = new Size(150, 20);
            label7.TabIndex = 75;
            label7.Text = "Pakowanie paczek";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(325, 411);
            label6.Name = "label6";
            label6.Size = new Size(148, 20);
            label6.TabIndex = 74;
            label6.Text = "Naprawa urządzeń";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(325, 338);
            label5.Name = "label5";
            label5.Size = new Size(188, 20);
            label5.TabIndex = 73;
            label5.Text = "Zarządzanie magazynem";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(325, 268);
            label4.Name = "label4";
            label4.Size = new Size(223, 20);
            label4.TabIndex = 72;
            label4.Text = "Obsługa wózków widłowych";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(325, 198);
            label3.Name = "label3";
            label3.Size = new Size(158, 20);
            label3.TabIndex = 71;
            label3.Text = "Dostęp do raportów";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(325, 126);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 70;
            label2.Text = "Nazwa";
            // 
            // textBoxNazwa
            // 
            textBoxNazwa.Anchor = AnchorStyles.None;
            textBoxNazwa.Location = new Point(554, 126);
            textBoxNazwa.Margin = new Padding(3, 4, 3, 4);
            textBoxNazwa.Name = "textBoxNazwa";
            textBoxNazwa.Size = new Size(114, 27);
            textBoxNazwa.TabIndex = 69;
            // 
            // FormEdytujRole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(993, 720);
            Controls.Add(comboBoxObsluga);
            Controls.Add(comboBoxZarzadzanie);
            Controls.Add(comboBoxNaprawa);
            Controls.Add(comboBoxPakowanie);
            Controls.Add(comboBoxDostep);
            Controls.Add(buttonAnuluj);
            Controls.Add(buttonZapisz);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxNazwa);
            ForeColor = SystemColors.Control;
            Name = "FormEdytujRole";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormEdytujRole";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxObsluga;
        private ComboBox comboBoxZarzadzanie;
        private ComboBox comboBoxNaprawa;
        private ComboBox comboBoxPakowanie;
        private ComboBox comboBoxDostep;
        private Button buttonAnuluj;
        private Button buttonZapisz;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBoxNazwa;
    }
}