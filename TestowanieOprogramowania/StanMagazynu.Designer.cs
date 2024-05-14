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
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(-1, 144);
            dataGridView2.Margin = new Padding(4, 5, 4, 5);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(1869, 906);
            dataGridView2.TabIndex = 9;
            // 
            // comboBoxSzukaj
            // 
            comboBoxSzukaj.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSzukaj.FormattingEnabled = true;
            comboBoxSzukaj.Items.AddRange(new object[] { "NazwaTowaru", "RodzajTowaru", "Rejestrujacy" });
            comboBoxSzukaj.Location = new Point(330, 56);
            comboBoxSzukaj.Margin = new Padding(4);
            comboBoxSzukaj.Name = "comboBoxSzukaj";
            comboBoxSzukaj.Size = new Size(195, 33);
            comboBoxSzukaj.TabIndex = 18;
            // 
            // textBoxSzukajProduktu
            // 
            textBoxSzukajProduktu.BackColor = Color.Silver;
            textBoxSzukajProduktu.BorderStyle = BorderStyle.None;
            textBoxSzukajProduktu.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSzukajProduktu.Location = new Point(22, 56);
            textBoxSzukajProduktu.Margin = new Padding(4, 5, 4, 5);
            textBoxSzukajProduktu.Name = "textBoxSzukajProduktu";
            textBoxSzukajProduktu.Size = new Size(259, 39);
            textBoxSzukajProduktu.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 24);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(161, 21);
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
            buttonDodajProdukt.Location = new Point(749, 38);
            buttonDodajProdukt.Margin = new Padding(4, 5, 4, 5);
            buttonDodajProdukt.Name = "buttonDodajProdukt";
            buttonDodajProdukt.Size = new Size(176, 59);
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
            SzukajProdukt.Location = new Point(547, 39);
            SzukajProdukt.Margin = new Padding(4, 5, 4, 5);
            SzukajProdukt.Name = "SzukajProdukt";
            SzukajProdukt.Size = new Size(176, 56);
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
            label1.Location = new Point(330, 24);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(174, 21);
            label1.TabIndex = 22;
            label1.Text = "Kategoria szukania";
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1273, 34);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(176, 76);
            button1.TabIndex = 23;
            button1.Text = "Przegladaj historie akcji";
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
            button2.Location = new Point(944, 38);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(176, 56);
            button2.TabIndex = 24;
            button2.Text = "Usuń";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // StanMagazynu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(1864, 1050);
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
            Margin = new Padding(2, 4, 2, 4);
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
    }
}