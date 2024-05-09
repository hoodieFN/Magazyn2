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
            buttonNadajRole = new Button();
            SzukajProdukt = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(-1, 103);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(1308, 527);
            dataGridView2.TabIndex = 9;
            // 
            // comboBoxSzukaj
            // 
            comboBoxSzukaj.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSzukaj.FormattingEnabled = true;
            comboBoxSzukaj.Items.AddRange(new object[] { "ProduktID", "NazwaTowaru", "RodzajTowaru", "JednostkaMiary", "Ilosc", "CenaNetto", "StawkaVAT", "Opis", "Dostawca", "DataDostawy", "DataRejestracji", "Rejestrujacy" });
            comboBoxSzukaj.Location = new Point(241, 34);
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
            textBoxSzukajProduktu.Location = new Point(16, 34);
            textBoxSzukajProduktu.Name = "textBoxSzukajProduktu";
            textBoxSzukajProduktu.Size = new Size(181, 26);
            textBoxSzukajProduktu.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Location = new Point(49, 16);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 19;
            label2.Text = "Wyszukaj produkt";
            // 
            // buttonNadajRole
            // 
            buttonNadajRole.AllowDrop = true;
            buttonNadajRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonNadajRole.BackColor = Color.Indigo;
            buttonNadajRole.Cursor = Cursors.Hand;
            buttonNadajRole.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNadajRole.ForeColor = Color.White;
            buttonNadajRole.Location = new Point(961, 21);
            buttonNadajRole.Name = "buttonNadajRole";
            buttonNadajRole.Size = new Size(123, 46);
            buttonNadajRole.TabIndex = 20;
            buttonNadajRole.Text = "Dodaj produkt";
            buttonNadajRole.UseVisualStyleBackColor = false;
            // 
            // SzukajProdukt
            // 
            SzukajProdukt.AllowDrop = true;
            SzukajProdukt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SzukajProdukt.BackColor = Color.Indigo;
            SzukajProdukt.Cursor = Cursors.Hand;
            SzukajProdukt.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SzukajProdukt.ForeColor = Color.White;
            SzukajProdukt.Location = new Point(816, 21);
            SzukajProdukt.Name = "SzukajProdukt";
            SzukajProdukt.Size = new Size(123, 46);
            SzukajProdukt.TabIndex = 21;
            SzukajProdukt.Text = "Szukaj";
            SzukajProdukt.UseVisualStyleBackColor = false;
            SzukajProdukt.Click += SzukajProdukt_Click;
            // 
            // StanMagazynu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1305, 630);
            Controls.Add(SzukajProdukt);
            Controls.Add(buttonNadajRole);
            Controls.Add(label2);
            Controls.Add(comboBoxSzukaj);
            Controls.Add(textBoxSzukajProduktu);
            Controls.Add(dataGridView2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 2, 2, 2);
            Name = "StanMagazynu";
            Text = "StanMagazynu";
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView2;
        private ComboBox comboBoxSzukaj;
        private TextBox textBoxSzukajProduktu;
        private Label label2;
        private Button buttonNadajRole;
        private Button SzukajProdukt;
    }
}