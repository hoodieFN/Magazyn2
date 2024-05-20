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
            NowaStawka = new NumericUpDown();
            label3 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVStawka).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NowaStawka).BeginInit();
            SuspendLayout();
            // 
            // DGVStawka
            // 
            DGVStawka.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVStawka.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVStawka.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVStawka.Location = new Point(-2, 143);
            DGVStawka.Margin = new Padding(4, 5, 4, 5);
            DGVStawka.Name = "DGVStawka";
            DGVStawka.RowHeadersWidth = 51;
            DGVStawka.RowTemplate.Height = 25;
            DGVStawka.Size = new Size(1869, 907);
            DGVStawka.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(358, 32);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(174, 21);
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
            SzukajProdukt.Location = new Point(575, 47);
            SzukajProdukt.Margin = new Padding(4, 5, 4, 5);
            SzukajProdukt.Name = "SzukajProdukt";
            SzukajProdukt.Size = new Size(176, 57);
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
            label2.Location = new Point(49, 32);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(161, 21);
            label2.TabIndex = 25;
            label2.Text = "Wyszukaj produkt";
            // 
            // comboBoxSzukaj1
            // 
            comboBoxSzukaj1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSzukaj1.FormattingEnabled = true;
            comboBoxSzukaj1.Items.AddRange(new object[] { "NazwaTowaru", "RodzajTowaru", "Rejestrujacy" });
            comboBoxSzukaj1.Location = new Point(358, 66);
            comboBoxSzukaj1.Margin = new Padding(4, 3, 4, 3);
            comboBoxSzukaj1.Name = "comboBoxSzukaj1";
            comboBoxSzukaj1.Size = new Size(195, 33);
            comboBoxSzukaj1.TabIndex = 24;
            // 
            // textBoxSzukajProduktu
            // 
            textBoxSzukajProduktu.BackColor = Color.Silver;
            textBoxSzukajProduktu.BorderStyle = BorderStyle.None;
            textBoxSzukajProduktu.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSzukajProduktu.Location = new Point(49, 66);
            textBoxSzukajProduktu.Margin = new Padding(4, 5, 4, 5);
            textBoxSzukajProduktu.Name = "textBoxSzukajProduktu";
            textBoxSzukajProduktu.Size = new Size(259, 39);
            textBoxSzukajProduktu.TabIndex = 23;
            // 
            // NowaStawka
            // 
            NowaStawka.Location = new Point(842, 68);
            NowaStawka.Name = "NowaStawka";
            NowaStawka.Size = new Size(180, 31);
            NowaStawka.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(842, 32);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(170, 21);
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
            button1.Location = new Point(1064, 42);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(176, 57);
            button1.TabIndex = 30;
            button1.Text = "Zmień";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FormZmianaVat
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(1924, 1050);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(NowaStawka);
            Controls.Add(label1);
            Controls.Add(SzukajProdukt);
            Controls.Add(label2);
            Controls.Add(comboBoxSzukaj1);
            Controls.Add(textBoxSzukajProduktu);
            Controls.Add(DGVStawka);
            Name = "FormZmianaVat";
            Text = "FormZmianaVat";
            ((System.ComponentModel.ISupportInitialize)DGVStawka).EndInit();
            ((System.ComponentModel.ISupportInitialize)NowaStawka).EndInit();
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
        private NumericUpDown NowaStawka;
        private Label label3;
        private Button button1;
    }
}