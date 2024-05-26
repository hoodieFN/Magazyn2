namespace TestowanieOprogramowania
{
    partial class StanMagazynu
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
            dataGridView2 = new DataGridView();
            comboBoxSzukaj = new ComboBox();
            textBoxSzukajProduktu = new TextBox();
            label2 = new Label();
            buttonDodajProdukt = new Button();
            SzukajProdukt = new Button();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            buttonHUSM = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(-1, 114);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(1308, 516);
            dataGridView2.TabIndex = 9;
            // 
            // comboBoxSzukaj
            // 
            comboBoxSzukaj.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSzukaj.FormattingEnabled = true;
            comboBoxSzukaj.Items.AddRange(new object[] { "NazwaTowaru", "RodzajTowaru", "Rejestrujacy" });
            comboBoxSzukaj.Location = new Point(231, 34);
            comboBoxSzukaj.Margin = new Padding(3, 2, 3, 2);
            comboBoxSzukaj.Name = "comboBoxSzukaj";
            comboBoxSzukaj.Size = new Size(138, 23);
            comboBoxSzukaj.TabIndex = 18;
            // 
            // textBoxSzukajProduktu
            // 
            textBoxSzukajProduktu.BackColor = Color.Silver;
            textBoxSzukajProduktu.BorderStyle = BorderStyle.None;
            textBoxSzukajProduktu.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSzukajProduktu.Location = new Point(15, 34);
            textBoxSzukajProduktu.Name = "textBoxSzukajProduktu";
            textBoxSzukajProduktu.Size = new Size(181, 26);
            textBoxSzukajProduktu.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(15, 14);
            label2.Name = "label2";
            label2.Size = new Size(110, 17);
            label2.TabIndex = 19;
            label2.Text = "Wyszukaj produkt";
            // 
            // buttonDodajProdukt
            // 
            buttonDodajProdukt.AllowDrop = true;
            buttonDodajProdukt.BackColor = Color.Indigo;
            buttonDodajProdukt.Cursor = Cursors.Hand;
            buttonDodajProdukt.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDodajProdukt.ForeColor = Color.White;
            buttonDodajProdukt.Location = new Point(519, 10);
            buttonDodajProdukt.Name = "buttonDodajProdukt";
            buttonDodajProdukt.Size = new Size(123, 35);
            buttonDodajProdukt.TabIndex = 20;
            buttonDodajProdukt.Text = "Dodaj produkt";
            buttonDodajProdukt.UseVisualStyleBackColor = false;
            buttonDodajProdukt.Click += buttonDodajProdukt_Click;
            // 
            // SzukajProdukt
            // 
            SzukajProdukt.AllowDrop = true;
            SzukajProdukt.BackColor = Color.Indigo;
            SzukajProdukt.Cursor = Cursors.Hand;
            SzukajProdukt.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SzukajProdukt.ForeColor = Color.White;
            SzukajProdukt.Location = new Point(383, 23);
            SzukajProdukt.Name = "SzukajProdukt";
            SzukajProdukt.Size = new Size(123, 34);
            SzukajProdukt.TabIndex = 21;
            SzukajProdukt.Text = "Szukaj";
            SzukajProdukt.UseVisualStyleBackColor = false;
            SzukajProdukt.Click += SzukajProdukt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(231, 14);
            label1.Name = "label1";
            label1.Size = new Size(119, 17);
            label1.TabIndex = 22;
            label1.Text = "Kategoria szukania";
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1133, 9);
            button1.Name = "button1";
            button1.Size = new Size(160, 62);
            button1.TabIndex = 23;
            button1.Text = "Przegladaj historyczne stany magazynowe na wskazana date";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.AllowDrop = true;
            button2.BackColor = Color.Indigo;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(519, 50);
            button2.Name = "button2";
            button2.Size = new Size(123, 34);
            button2.TabIndex = 24;
            button2.Text = "Usuń";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // buttonHUSM
            // 
            buttonHUSM.AllowDrop = true;
            buttonHUSM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonHUSM.BackColor = Color.Indigo;
            buttonHUSM.Cursor = Cursors.Hand;
            buttonHUSM.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonHUSM.ForeColor = Color.White;
            buttonHUSM.Location = new Point(967, 9);
            buttonHUSM.Name = "buttonHUSM";
            buttonHUSM.Size = new Size(160, 62);
            buttonHUSM.TabIndex = 25;
            buttonHUSM.Text = "Przeglądaj historie uzupełniania stanów magazynowych";
            buttonHUSM.UseVisualStyleBackColor = false;
            buttonHUSM.Click += buttonHUSM_Click;
            // 
            // button3
            // 
            button3.AllowDrop = true;
            button3.BackColor = Color.Indigo;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(777, -3);
            button3.Name = "button3";
            button3.Size = new Size(162, 48);
            button3.TabIndex = 26;
            button3.Text = "Zmień stawkę Vat dla kategorii produktów";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.AllowDrop = true;
            button4.BackColor = Color.Indigo;
            button4.Cursor = Cursors.Hand;
            button4.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(777, 54);
            button4.Name = "button4";
            button4.Size = new Size(162, 54);
            button4.TabIndex = 27;
            button4.Text = "Zmień stawkę Vat dla danego produktu";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.AllowDrop = true;
            button5.BackColor = Color.Indigo;
            button5.Cursor = Cursors.Hand;
            button5.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button5.ForeColor = Color.White;
            button5.Location = new Point(648, 2);
            button5.Name = "button5";
            button5.Size = new Size(123, 50);
            button5.TabIndex = 28;
            button5.Text = "Dodaj ilosc produktu";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // StanMagazynu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(1305, 630);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(buttonHUSM);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(SzukajProdukt);
            Controls.Add(buttonDodajProdukt);
            Controls.Add(label2);
            Controls.Add(comboBoxSzukaj);
            Controls.Add(textBoxSzukajProduktu);
            Controls.Add(dataGridView2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(1, 2, 1, 2);
            Name = "StanMagazynu";
            Text = "StanMagazynu";
            Load += StanMagazynu_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView2;
        private ComboBox comboBoxSzukaj;
        private TextBox textBoxSzukajProduktu;
        private Label label2;
        private Button buttonDodajProdukt;
        private Button SzukajProdukt;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button buttonHUSM;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}