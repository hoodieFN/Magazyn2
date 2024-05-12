namespace TestowanieOprogramowania
{
    partial class FormDodajProdukt
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
            textBoxNazwaTowaru = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            comboBoxRodzajTowaru = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            comboBoxJednostkaMiary = new ComboBox();
            label3 = new Label();
            textBoxIlosc = new TextBox();
            label4 = new Label();
            label5 = new Label();
            comboBoxStawkaVat = new ComboBox();
            label6 = new Label();
            textBoxCenaNetto = new TextBox();
            label7 = new Label();
            textBoxOpisTowaru = new TextBox();
            label8 = new Label();
            textBoxDostawca = new TextBox();
            dateTimePickerDataDostawy = new DateTimePicker();
            label9 = new Label();
            buttonDodajProdukt = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBoxNazwaTowaru
            // 
            textBoxNazwaTowaru.BackColor = Color.Silver;
            textBoxNazwaTowaru.BorderStyle = BorderStyle.None;
            textBoxNazwaTowaru.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNazwaTowaru.Location = new Point(181, 87);
            textBoxNazwaTowaru.Name = "textBoxNazwaTowaru";
            textBoxNazwaTowaru.Size = new Size(181, 26);
            textBoxNazwaTowaru.TabIndex = 18;
            // 
            // comboBoxRodzajTowaru
            // 
            comboBoxRodzajTowaru.FormattingEnabled = true;
            comboBoxRodzajTowaru.Items.AddRange(new object[] { "test" });
            comboBoxRodzajTowaru.Location = new Point(181, 151);
            comboBoxRodzajTowaru.Name = "comboBoxRodzajTowaru";
            comboBoxRodzajTowaru.Size = new Size(181, 23);
            comboBoxRodzajTowaru.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(181, 67);
            label2.Name = "label2";
            label2.Size = new Size(93, 17);
            label2.TabIndex = 23;
            label2.Text = "Nazwa towaru";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(181, 131);
            label1.Name = "label1";
            label1.Size = new Size(92, 17);
            label1.TabIndex = 24;
            label1.Text = "Rodzaj towaru";
            // 
            // comboBoxJednostkaMiary
            // 
            comboBoxJednostkaMiary.FormattingEnabled = true;
            comboBoxJednostkaMiary.Items.AddRange(new object[] { "Sztuki", "Kilogramy", "Litry", "Palety" });
            comboBoxJednostkaMiary.Location = new Point(181, 208);
            comboBoxJednostkaMiary.Name = "comboBoxJednostkaMiary";
            comboBoxJednostkaMiary.Size = new Size(181, 23);
            comboBoxJednostkaMiary.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(181, 188);
            label3.Name = "label3";
            label3.Size = new Size(104, 17);
            label3.TabIndex = 26;
            label3.Text = "Jednostka miary";
            // 
            // textBoxIlosc
            // 
            textBoxIlosc.BackColor = Color.Silver;
            textBoxIlosc.BorderStyle = BorderStyle.None;
            textBoxIlosc.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxIlosc.Location = new Point(181, 263);
            textBoxIlosc.Name = "textBoxIlosc";
            textBoxIlosc.Size = new Size(181, 26);
            textBoxIlosc.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(181, 243);
            label4.Name = "label4";
            label4.Size = new Size(35, 17);
            label4.TabIndex = 28;
            label4.Text = "Ilość";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(407, 67);
            label5.Name = "label5";
            label5.Size = new Size(78, 17);
            label5.TabIndex = 30;
            label5.Text = "Stawka VAT";
            // 
            // comboBoxStawkaVat
            // 
            comboBoxStawkaVat.FormattingEnabled = true;
            comboBoxStawkaVat.Items.AddRange(new object[] { "23%", "8%", "5%", "0%", "zw" });
            comboBoxStawkaVat.Location = new Point(407, 87);
            comboBoxStawkaVat.Name = "comboBoxStawkaVat";
            comboBoxStawkaVat.Size = new Size(181, 23);
            comboBoxStawkaVat.TabIndex = 29;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(181, 312);
            label6.Name = "label6";
            label6.Size = new Size(76, 17);
            label6.TabIndex = 32;
            label6.Text = "Cena netto";
            // 
            // textBoxCenaNetto
            // 
            textBoxCenaNetto.BackColor = Color.Silver;
            textBoxCenaNetto.BorderStyle = BorderStyle.None;
            textBoxCenaNetto.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCenaNetto.Location = new Point(181, 332);
            textBoxCenaNetto.Name = "textBoxCenaNetto";
            textBoxCenaNetto.Size = new Size(181, 26);
            textBoxCenaNetto.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(407, 131);
            label7.Name = "label7";
            label7.Size = new Size(79, 17);
            label7.TabIndex = 34;
            label7.Text = "Opis towaru";
            // 
            // textBoxOpisTowaru
            // 
            textBoxOpisTowaru.BackColor = Color.Silver;
            textBoxOpisTowaru.BorderStyle = BorderStyle.None;
            textBoxOpisTowaru.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxOpisTowaru.Location = new Point(407, 151);
            textBoxOpisTowaru.Name = "textBoxOpisTowaru";
            textBoxOpisTowaru.Size = new Size(181, 26);
            textBoxOpisTowaru.TabIndex = 33;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(407, 188);
            label8.Name = "label8";
            label8.Size = new Size(69, 17);
            label8.TabIndex = 36;
            label8.Text = "Dostawca";
            // 
            // textBoxDostawca
            // 
            textBoxDostawca.BackColor = Color.Silver;
            textBoxDostawca.BorderStyle = BorderStyle.None;
            textBoxDostawca.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxDostawca.Location = new Point(407, 208);
            textBoxDostawca.Name = "textBoxDostawca";
            textBoxDostawca.Size = new Size(181, 26);
            textBoxDostawca.TabIndex = 35;
            // 
            // dateTimePickerDataDostawy
            // 
            dateTimePickerDataDostawy.Location = new Point(407, 266);
            dateTimePickerDataDostawy.Name = "dateTimePickerDataDostawy";
            dateTimePickerDataDostawy.Size = new Size(200, 23);
            dateTimePickerDataDostawy.TabIndex = 37;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(407, 246);
            label9.Name = "label9";
            label9.Size = new Size(91, 17);
            label9.TabIndex = 38;
            label9.Text = "Data dostawy";
            // 
            // buttonDodajProdukt
            // 
            buttonDodajProdukt.AllowDrop = true;
            buttonDodajProdukt.BackColor = Color.Indigo;
            buttonDodajProdukt.Cursor = Cursors.Hand;
            buttonDodajProdukt.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDodajProdukt.ForeColor = Color.White;
            buttonDodajProdukt.Location = new Point(316, 403);
            buttonDodajProdukt.Name = "buttonDodajProdukt";
            buttonDodajProdukt.Size = new Size(132, 40);
            buttonDodajProdukt.TabIndex = 41;
            buttonDodajProdukt.Text = "Dodaj produkt";
            buttonDodajProdukt.UseVisualStyleBackColor = false;
            buttonDodajProdukt.Click += buttonDodajProdukt_Click;
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(630, 390);
            button1.Name = "button1";
            button1.Size = new Size(132, 53);
            button1.TabIndex = 42;
            button1.Text = "Edytuj liste rodzajów";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FormDodajProdukt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(800, 478);
            Controls.Add(button1);
            Controls.Add(buttonDodajProdukt);
            Controls.Add(label9);
            Controls.Add(dateTimePickerDataDostawy);
            Controls.Add(label8);
            Controls.Add(textBoxDostawca);
            Controls.Add(label7);
            Controls.Add(textBoxOpisTowaru);
            Controls.Add(label6);
            Controls.Add(textBoxCenaNetto);
            Controls.Add(label5);
            Controls.Add(comboBoxStawkaVat);
            Controls.Add(label4);
            Controls.Add(textBoxIlosc);
            Controls.Add(label3);
            Controls.Add(comboBoxJednostkaMiary);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(comboBoxRodzajTowaru);
            Controls.Add(textBoxNazwaTowaru);
            Name = "FormDodajProdukt";
            Text = "FormDodajProdukt";
            Load += FormDodajProdukt_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNazwaTowaru;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComboBox comboBoxRodzajTowaru;
        private Label label2;
        private Label label1;
        private ComboBox comboBoxJednostkaMiary;
        private Label label3;
        private TextBox textBoxIlosc;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxStawkaVat;
        private Label label6;
        private TextBox textBoxCenaNetto;
        private Label label7;
        private TextBox textBoxOpisTowaru;
        private Label label8;
        private TextBox textBoxDostawca;
        private DateTimePicker dateTimePickerDataDostawy;
        private Label label9;
        private Button buttonDodajProdukt;
        private Button button1;
    }
}