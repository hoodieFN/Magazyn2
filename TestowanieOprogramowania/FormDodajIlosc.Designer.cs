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
            label123 = new Label();
            label1 = new Label();
            label2 = new Label();
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
            // label123
            // 
            label123.AutoSize = true;
            label123.ForeColor = SystemColors.Control;
            label123.Location = new Point(18, 191);
            label123.Margin = new Padding(4, 0, 4, 0);
            label123.Name = "label123";
            label123.Size = new Size(371, 15);
            label123.TabIndex = 6;
            label123.Text = "Dla wartości powyżej 100 system przyjmuje wartość maksymalną 100.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(18, 219);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(332, 15);
            label1.TabIndex = 7;
            label1.Text = "Dla wartości poniżej 0 system przyjmuje wartość minimalną 0.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(18, 271);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 8;
            label2.Text = "Dodac data dostawy";
            // 
            // FormDodajIlosc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(407, 307);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label123);
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
        private Label label123;
        private Label label1;
        private Label label2;
    }
}
