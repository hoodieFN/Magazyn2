namespace TestowanieOprogramowania
{
    partial class FormDodajIlosc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelNazwaTowaru = new Label();
            labelDostawca = new Label();
            labelOpis = new Label();
            labelJednostkaMiary = new Label();
            numericUpDownIlosc = new NumericUpDown();
            buttonDodaj = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIlosc).BeginInit();
            SuspendLayout();
            // 
            // labelNazwaTowaru
            // 
            labelNazwaTowaru.AutoSize = true;
            labelNazwaTowaru.ForeColor = SystemColors.Control;
            labelNazwaTowaru.Location = new Point(14, 10);
            labelNazwaTowaru.Margin = new Padding(4, 0, 4, 0);
            labelNazwaTowaru.Name = "labelNazwaTowaru";
            labelNazwaTowaru.Size = new Size(85, 15);
            labelNazwaTowaru.TabIndex = 0;
            labelNazwaTowaru.Text = "Nazwa towaru:";
            // 
            // labelDostawca
            // 
            labelDostawca.AutoSize = true;
            labelDostawca.ForeColor = SystemColors.Control;
            labelDostawca.Location = new Point(14, 37);
            labelDostawca.Margin = new Padding(4, 0, 4, 0);
            labelDostawca.Name = "labelDostawca";
            labelDostawca.Size = new Size(61, 15);
            labelDostawca.TabIndex = 1;
            labelDostawca.Text = "Dostawca:";
            // 
            // labelOpis
            // 
            labelOpis.AutoSize = true;
            labelOpis.ForeColor = SystemColors.Control;
            labelOpis.Location = new Point(14, 63);
            labelOpis.Margin = new Padding(4, 0, 4, 0);
            labelOpis.Name = "labelOpis";
            labelOpis.Size = new Size(34, 15);
            labelOpis.TabIndex = 2;
            labelOpis.Text = "Opis:";
            // 
            // labelJednostkaMiary
            // 
            labelJednostkaMiary.AutoSize = true;
            labelJednostkaMiary.ForeColor = SystemColors.Control;
            labelJednostkaMiary.Location = new Point(14, 90);
            labelJednostkaMiary.Margin = new Padding(4, 0, 4, 0);
            labelJednostkaMiary.Name = "labelJednostkaMiary";
            labelJednostkaMiary.Size = new Size(95, 15);
            labelJednostkaMiary.TabIndex = 3;
            labelJednostkaMiary.Text = "Jednostka miary:";
            // 
            // numericUpDownIlosc
            // 
            numericUpDownIlosc.Location = new Point(18, 121);
            numericUpDownIlosc.Margin = new Padding(4, 3, 4, 3);
            numericUpDownIlosc.Name = "numericUpDownIlosc";
            numericUpDownIlosc.Size = new Size(140, 23);
            numericUpDownIlosc.TabIndex = 4;
            // 
            // buttonDodaj
            // 
            buttonDodaj.BackColor = Color.Indigo;
            buttonDodaj.ForeColor = SystemColors.Control;
            buttonDodaj.Location = new Point(18, 151);
            buttonDodaj.Margin = new Padding(4, 3, 4, 3);
            buttonDodaj.Name = "buttonDodaj";
            buttonDodaj.Size = new Size(140, 27);
            buttonDodaj.TabIndex = 5;
            buttonDodaj.Text = "Dodaj ilość";
            buttonDodaj.UseVisualStyleBackColor = false;
            buttonDodaj.Click += buttonDodaj_Click;
            // 
            // FormDodajIlosc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(331, 186);
            Controls.Add(buttonDodaj);
            Controls.Add(numericUpDownIlosc);
            Controls.Add(labelJednostkaMiary);
            Controls.Add(labelOpis);
            Controls.Add(labelDostawca);
            Controls.Add(labelNazwaTowaru);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormDodajIlosc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dodaj ilość produktu";
            Load += FormDodajIlosc_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownIlosc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label labelNazwaTowaru;
        private System.Windows.Forms.Label labelDostawca;
        private System.Windows.Forms.Label labelOpis;
        private System.Windows.Forms.Label labelJednostkaMiary;
        private System.Windows.Forms.NumericUpDown numericUpDownIlosc;
        private System.Windows.Forms.Button buttonDodaj;
    }
}
