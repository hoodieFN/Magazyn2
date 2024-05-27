namespace TestowanieOprogramowania
{
    partial class FormZmianaVat
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
            DGVStawka = new DataGridView();
            label1 = new Label();
            SzukajProdukt = new Button();
            label2 = new Label();
            comboBoxSzukaj1 = new ComboBox();
            textBoxSzukajProduktu = new TextBox();
            label3 = new Label();
            button1 = new Button();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DGVStawka).BeginInit();
            SuspendLayout();
            // 
            // DGVStawka
            // 
            DGVStawka.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVStawka.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVStawka.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVStawka.Location = new Point(-1, 86);
            DGVStawka.Name = "DGVStawka";
            DGVStawka.RowHeadersWidth = 51;
            DGVStawka.RowTemplate.Height = 25;
            DGVStawka.Size = new Size(1164, 544);
            DGVStawka.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(230, 22);
            label1.Name = "label1";
            label1.Size = new Size(119, 17);
            label1.TabIndex = 27;
            label1.Text = "Kategoria szukania";
            // 
            // SzukajProdukt
            // 
            SzukajProdukt.AllowDrop = true;
            SzukajProdukt.BackColor = Color.Indigo;
            SzukajProdukt.Cursor = Cursors.Hand;
            SzukajProdukt.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SzukajProdukt.ForeColor = Color.White;
            SzukajProdukt.Location = new Point(391, 31);
            SzukajProdukt.Name = "SzukajProdukt";
            SzukajProdukt.Size = new Size(123, 34);
            SzukajProdukt.TabIndex = 26;
            SzukajProdukt.Text = "Szukaj";
            SzukajProdukt.UseVisualStyleBackColor = false;
            SzukajProdukt.Click += SzukajProdukt_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(34, 19);
            label2.Name = "label2";
            label2.Size = new Size(110, 17);
            label2.TabIndex = 25;
            label2.Text = "Wyszukaj produkt";
            // 
            // comboBoxSzukaj1
            // 
            comboBoxSzukaj1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSzukaj1.FormattingEnabled = true;
            comboBoxSzukaj1.Items.AddRange(new object[] { "NazwaTowaru", "RodzajTowaru", "Rejestrujacy" });
            comboBoxSzukaj1.Location = new Point(230, 43);
            comboBoxSzukaj1.Margin = new Padding(3, 2, 3, 2);
            comboBoxSzukaj1.Name = "comboBoxSzukaj1";
            comboBoxSzukaj1.Size = new Size(138, 23);
            comboBoxSzukaj1.TabIndex = 24;
            // 
            // textBoxSzukajProduktu
            // 
            textBoxSzukajProduktu.BackColor = Color.Silver;
            textBoxSzukajProduktu.BorderStyle = BorderStyle.None;
            textBoxSzukajProduktu.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSzukajProduktu.Location = new Point(34, 40);
            textBoxSzukajProduktu.Name = "textBoxSzukajProduktu";
            textBoxSzukajProduktu.Size = new Size(181, 26);
            textBoxSzukajProduktu.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(542, 22);
            label3.Name = "label3";
            label3.Size = new Size(114, 17);
            label3.TabIndex = 29;
            label3.Text = "Nowa stawka VAT";
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(681, 31);
            button1.Name = "button1";
            button1.Size = new Size(301, 34);
            button1.TabIndex = 30;
            button1.Text = "Zmień stawkę VAT dla zaznaczonego produktu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "23%", "8%", "5%", "0%", "zw" });
            comboBox1.Location = new Point(542, 42);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 31;
            // 
            // FormZmianaVat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(1159, 630);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(SzukajProdukt);
            Controls.Add(label2);
            Controls.Add(comboBoxSzukaj1);
            Controls.Add(textBoxSzukajProduktu);
            Controls.Add(DGVStawka);
            Margin = new Padding(2);
            Name = "FormZmianaVat";
            Text = "FormZmianaVat";
            Load += FormZmianaVat_Load;
            ((System.ComponentModel.ISupportInitialize)DGVStawka).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVStawka;
        private Label label1;
        private Button SzukajProdukt;
        private Label label2;
        private ComboBox comboBoxSzukaj1;
        private TextBox textBoxSzukajProduktu;
        private Label label3;
        private Button button1;
        private ComboBox comboBox1;
    }
}