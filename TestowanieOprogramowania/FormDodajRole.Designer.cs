namespace TestowanieOprogramowania
{
    partial class FormDodajRole
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
            buttonAnuluj = new Button();
            buttonZapisz = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBoxNazwa = new TextBox();
            comboBoxListUz = new ComboBox();
            comboBoxEdUs = new ComboBox();
            comboBoxUsUz = new ComboBox();
            comboBoxDodUz = new ComboBox();
            comboBoxListUp = new ComboBox();
            label1 = new Label();
            label8 = new Label();
            label9 = new Label();
            comboBoxDodRol = new ComboBox();
            comboBoxUsRol = new ComboBox();
            comboBoxEdRol = new ComboBox();
            label10 = new Label();
            comboBoxNadUp = new ComboBox();
            label11 = new Label();
            comboRejNowTow = new ComboBox();
            label12 = new Label();
            comboBoxZmHa = new ComboBox();
            label13 = new Label();
            comboBoxPrzStMag = new ComboBox();
            label14 = new Label();
            comboBoxPHSM = new ComboBox();
            label15 = new Label();
            comboBoxPHU = new ComboBox();
            label16 = new Label();
            comboBoxZSV = new ComboBox();
            SuspendLayout();
            // 
            // buttonAnuluj
            // 
            buttonAnuluj.Anchor = AnchorStyles.None;
            buttonAnuluj.BackColor = Color.Indigo;
            buttonAnuluj.Cursor = Cursors.Hand;
            buttonAnuluj.ForeColor = SystemColors.ButtonHighlight;
            buttonAnuluj.Location = new Point(475, 613);
            buttonAnuluj.Name = "buttonAnuluj";
            buttonAnuluj.Size = new Size(100, 27);
            buttonAnuluj.TabIndex = 63;
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
            buttonZapisz.Location = new Point(361, 613);
            buttonZapisz.Name = "buttonZapisz";
            buttonZapisz.Size = new Size(96, 27);
            buttonZapisz.TabIndex = 62;
            buttonZapisz.Text = "Zapisz";
            buttonZapisz.UseVisualStyleBackColor = false;
            buttonZapisz.Click += buttonZapisz_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(97, 319);
            label7.Name = "label7";
            label7.Size = new Size(152, 17);
            label7.TabIndex = 55;
            label7.Text = "Edytowanie Uzytkownika";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(97, 271);
            label6.Name = "label6";
            label6.Size = new Size(139, 17);
            label6.TabIndex = 54;
            label6.Text = "Usuwanie Uzytkownika";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(97, 217);
            label5.Name = "label5";
            label5.Size = new Size(152, 17);
            label5.TabIndex = 53;
            label5.Text = "Dodawanie Uzytkownika";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(97, 164);
            label4.Name = "label4";
            label4.Size = new Size(165, 17);
            label4.TabIndex = 52;
            label4.Text = "Dostęp Do Listy Uprawnien";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(97, 112);
            label3.Name = "label3";
            label3.Size = new Size(183, 17);
            label3.TabIndex = 51;
            label3.Text = "Dostęp do Listy Uzytkownikow";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(97, 64);
            label2.Name = "label2";
            label2.Size = new Size(48, 17);
            label2.TabIndex = 50;
            label2.Text = "Nazwa";
            // 
            // textBoxNazwa
            // 
            textBoxNazwa.Anchor = AnchorStyles.None;
            textBoxNazwa.Location = new Point(298, 58);
            textBoxNazwa.Name = "textBoxNazwa";
            textBoxNazwa.Size = new Size(100, 23);
            textBoxNazwa.TabIndex = 39;
            // 
            // comboBoxListUz
            // 
            comboBoxListUz.Anchor = AnchorStyles.None;
            comboBoxListUz.FormattingEnabled = true;
            comboBoxListUz.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxListUz.Location = new Point(298, 106);
            comboBoxListUz.Margin = new Padding(3, 2, 3, 2);
            comboBoxListUz.Name = "comboBoxListUz";
            comboBoxListUz.Size = new Size(100, 23);
            comboBoxListUz.TabIndex = 64;
            // 
            // comboBoxEdUs
            // 
            comboBoxEdUs.Anchor = AnchorStyles.None;
            comboBoxEdUs.FormattingEnabled = true;
            comboBoxEdUs.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxEdUs.Location = new Point(298, 313);
            comboBoxEdUs.Margin = new Padding(3, 2, 3, 2);
            comboBoxEdUs.Name = "comboBoxEdUs";
            comboBoxEdUs.Size = new Size(100, 23);
            comboBoxEdUs.TabIndex = 65;
            // 
            // comboBoxUsUz
            // 
            comboBoxUsUz.Anchor = AnchorStyles.None;
            comboBoxUsUz.FormattingEnabled = true;
            comboBoxUsUz.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxUsUz.Location = new Point(298, 265);
            comboBoxUsUz.Margin = new Padding(3, 2, 3, 2);
            comboBoxUsUz.Name = "comboBoxUsUz";
            comboBoxUsUz.Size = new Size(100, 23);
            comboBoxUsUz.TabIndex = 66;
            // 
            // comboBoxDodUz
            // 
            comboBoxDodUz.Anchor = AnchorStyles.None;
            comboBoxDodUz.FormattingEnabled = true;
            comboBoxDodUz.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxDodUz.Location = new Point(298, 211);
            comboBoxDodUz.Margin = new Padding(3, 2, 3, 2);
            comboBoxDodUz.Name = "comboBoxDodUz";
            comboBoxDodUz.Size = new Size(100, 23);
            comboBoxDodUz.TabIndex = 67;
            // 
            // comboBoxListUp
            // 
            comboBoxListUp.Anchor = AnchorStyles.None;
            comboBoxListUp.FormattingEnabled = true;
            comboBoxListUp.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxListUp.Location = new Point(298, 158);
            comboBoxListUp.Margin = new Padding(3, 2, 3, 2);
            comboBoxListUp.Name = "comboBoxListUp";
            comboBoxListUp.Size = new Size(100, 23);
            comboBoxListUp.TabIndex = 68;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(97, 371);
            label1.Name = "label1";
            label1.Size = new Size(101, 17);
            label1.TabIndex = 69;
            label1.Text = "Dodawanie Roli";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(97, 417);
            label8.Name = "label8";
            label8.Size = new Size(88, 17);
            label8.TabIndex = 70;
            label8.Text = "Usuwanie Roli";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(97, 461);
            label9.Name = "label9";
            label9.Size = new Size(101, 17);
            label9.TabIndex = 71;
            label9.Text = "Edytowanie Roli";
            // 
            // comboBoxDodRol
            // 
            comboBoxDodRol.Anchor = AnchorStyles.None;
            comboBoxDodRol.FormattingEnabled = true;
            comboBoxDodRol.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxDodRol.Location = new Point(298, 365);
            comboBoxDodRol.Margin = new Padding(3, 2, 3, 2);
            comboBoxDodRol.Name = "comboBoxDodRol";
            comboBoxDodRol.Size = new Size(100, 23);
            comboBoxDodRol.TabIndex = 72;
            // 
            // comboBoxUsRol
            // 
            comboBoxUsRol.Anchor = AnchorStyles.None;
            comboBoxUsRol.FormattingEnabled = true;
            comboBoxUsRol.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxUsRol.Location = new Point(298, 411);
            comboBoxUsRol.Margin = new Padding(3, 2, 3, 2);
            comboBoxUsRol.Name = "comboBoxUsRol";
            comboBoxUsRol.Size = new Size(100, 23);
            comboBoxUsRol.TabIndex = 73;
            // 
            // comboBoxEdRol
            // 
            comboBoxEdRol.Anchor = AnchorStyles.None;
            comboBoxEdRol.FormattingEnabled = true;
            comboBoxEdRol.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxEdRol.Location = new Point(298, 455);
            comboBoxEdRol.Margin = new Padding(3, 2, 3, 2);
            comboBoxEdRol.Name = "comboBoxEdRol";
            comboBoxEdRol.Size = new Size(100, 23);
            comboBoxEdRol.TabIndex = 74;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(97, 508);
            label10.Name = "label10";
            label10.Size = new Size(149, 17);
            label10.TabIndex = 75;
            label10.Text = "Nadawanie/Zmiana Roli";
            // 
            // comboBoxNadUp
            // 
            comboBoxNadUp.Anchor = AnchorStyles.None;
            comboBoxNadUp.FormattingEnabled = true;
            comboBoxNadUp.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxNadUp.Location = new Point(298, 502);
            comboBoxNadUp.Margin = new Padding(3, 2, 3, 2);
            comboBoxNadUp.Name = "comboBoxNadUp";
            comboBoxNadUp.Size = new Size(100, 23);
            comboBoxNadUp.TabIndex = 76;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(97, 552);
            label11.Name = "label11";
            label11.Size = new Size(174, 17);
            label11.TabIndex = 77;
            label11.Text = "Rejestracja Nowego Towaru";
            // 
            // comboRejNowTow
            // 
            comboRejNowTow.Anchor = AnchorStyles.None;
            comboRejNowTow.FormattingEnabled = true;
            comboRejNowTow.Items.AddRange(new object[] { "Tak", "Nie" });
            comboRejNowTow.Location = new Point(298, 550);
            comboRejNowTow.Margin = new Padding(3, 2, 3, 2);
            comboRejNowTow.Name = "comboRejNowTow";
            comboRejNowTow.Size = new Size(100, 23);
            comboRejNowTow.TabIndex = 78;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.None;
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(427, 64);
            label12.Name = "label12";
            label12.Size = new Size(75, 17);
            label12.TabIndex = 79;
            label12.Text = "ZmienHaslo";
            // 
            // comboBoxZmHa
            // 
            comboBoxZmHa.Anchor = AnchorStyles.None;
            comboBoxZmHa.FormattingEnabled = true;
            comboBoxZmHa.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxZmHa.Location = new Point(711, 58);
            comboBoxZmHa.Margin = new Padding(3, 2, 3, 2);
            comboBoxZmHa.Name = "comboBoxZmHa";
            comboBoxZmHa.Size = new Size(100, 23);
            comboBoxZmHa.TabIndex = 80;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.None;
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(427, 112);
            label13.Name = "label13";
            label13.Size = new Size(194, 17);
            label13.TabIndex = 81;
            label13.Text = "Przeglad Stanu Magazynowego";
            // 
            // comboBoxPrzStMag
            // 
            comboBoxPrzStMag.Anchor = AnchorStyles.None;
            comboBoxPrzStMag.FormattingEnabled = true;
            comboBoxPrzStMag.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxPrzStMag.Location = new Point(711, 106);
            comboBoxPrzStMag.Margin = new Padding(3, 2, 3, 2);
            comboBoxPrzStMag.Name = "comboBoxPrzStMag";
            comboBoxPrzStMag.Size = new Size(100, 23);
            comboBoxPrzStMag.TabIndex = 82;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.None;
            label14.AutoSize = true;
            label14.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(427, 160);
            label14.Name = "label14";
            label14.Size = new Size(262, 17);
            label14.TabIndex = 83;
            label14.Text = "Przegladanie Historii Stanu Magazynowego";
            // 
            // comboBoxPHSM
            // 
            comboBoxPHSM.Anchor = AnchorStyles.None;
            comboBoxPHSM.FormattingEnabled = true;
            comboBoxPHSM.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxPHSM.Location = new Point(711, 158);
            comboBoxPHSM.Margin = new Padding(3, 2, 3, 2);
            comboBoxPHSM.Name = "comboBoxPHSM";
            comboBoxPHSM.Size = new Size(100, 23);
            comboBoxPHSM.TabIndex = 84;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.None;
            label15.AutoSize = true;
            label15.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(427, 211);
            label15.Name = "label15";
            label15.Size = new Size(179, 17);
            label15.TabIndex = 85;
            label15.Text = "Przeglad Historii Uzupelniania";
            // 
            // comboBoxPHU
            // 
            comboBoxPHU.Anchor = AnchorStyles.None;
            comboBoxPHU.FormattingEnabled = true;
            comboBoxPHU.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxPHU.Location = new Point(711, 205);
            comboBoxPHU.Margin = new Padding(3, 2, 3, 2);
            comboBoxPHU.Name = "comboBoxPHU";
            comboBoxPHU.Size = new Size(100, 23);
            comboBoxPHU.TabIndex = 86;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.None;
            label16.AutoSize = true;
            label16.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(427, 267);
            label16.Name = "label16";
            label16.Size = new Size(118, 17);
            label16.TabIndex = 87;
            label16.Text = "Zmiana Stawki Vat";
            // 
            // comboBoxZSV
            // 
            comboBoxZSV.Anchor = AnchorStyles.None;
            comboBoxZSV.FormattingEnabled = true;
            comboBoxZSV.Items.AddRange(new object[] { "Tak", "Nie" });
            comboBoxZSV.Location = new Point(711, 261);
            comboBoxZSV.Margin = new Padding(3, 2, 3, 2);
            comboBoxZSV.Name = "comboBoxZSV";
            comboBoxZSV.Size = new Size(100, 23);
            comboBoxZSV.TabIndex = 88;
            // 
            // FormDodajRole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(885, 674);
            Controls.Add(comboBoxZSV);
            Controls.Add(label16);
            Controls.Add(comboBoxPHU);
            Controls.Add(label15);
            Controls.Add(comboBoxPHSM);
            Controls.Add(label14);
            Controls.Add(comboBoxPrzStMag);
            Controls.Add(label13);
            Controls.Add(comboBoxZmHa);
            Controls.Add(label12);
            Controls.Add(comboRejNowTow);
            Controls.Add(label11);
            Controls.Add(comboBoxNadUp);
            Controls.Add(label10);
            Controls.Add(comboBoxEdRol);
            Controls.Add(comboBoxUsRol);
            Controls.Add(comboBoxDodRol);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(comboBoxListUp);
            Controls.Add(comboBoxDodUz);
            Controls.Add(comboBoxUsUz);
            Controls.Add(comboBoxEdUs);
            Controls.Add(comboBoxListUz);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormDodajRole";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dodaj rolę";
            Load += FormDodajRole_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonAnuluj;
        private Button buttonZapisz;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBoxUlica;
        private TextBox textBoxKodPocztowy;
        private TextBox textBoxMiejscowosc;
        private TextBox textBoxNazwisko;
        private TextBox textBoxImie;
        private TextBox textBoxNazwa;
        private ComboBox comboBoxListUz;
        private ComboBox comboBoxEdUs;
        private ComboBox comboBoxUsUz;
        private ComboBox comboBoxDodUz;
        private ComboBox comboBoxListUp;
        private Label label1;
        private Label label8;
        private Label label9;
        private ComboBox comboBoxDodRol;
        private ComboBox comboBoxUsRol;
        private ComboBox comboBoxEdRol;
        private Label label10;
        private ComboBox comboBoxNadUp;
        private Label label11;
        private ComboBox comboRejNowTow;
        private Label label12;
        private ComboBox comboBoxZmHa;
        private Label label13;
        private ComboBox comboBoxPrzStMag;
        private Label label14;
        private ComboBox comboBoxPHSM;
        private Label label15;
        private ComboBox comboBoxPHU;
        private Label label16;
        private ComboBox comboBoxZSV;
    }
}