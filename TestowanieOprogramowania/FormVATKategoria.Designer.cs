namespace TestowanieOprogramowania
{
    partial class FormVATKategoria
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
            button1 = new Button();
            label3 = new Label();
            label1 = new Label();
            KategoriaTowaru = new ComboBox();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DGVStawka).BeginInit();
            SuspendLayout();
            // 
            // DGVStawka
            // 
            DGVStawka.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVStawka.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVStawka.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVStawka.Location = new Point(-2, 86);
            DGVStawka.Name = "DGVStawka";
            DGVStawka.RowHeadersWidth = 51;
            DGVStawka.RowTemplate.Height = 25;
            DGVStawka.Size = new Size(1269, 544);
            DGVStawka.TabIndex = 11;
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(331, 32);
            button1.Name = "button1";
            button1.Size = new Size(123, 34);
            button1.TabIndex = 36;
            button1.Text = "Zmień";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(191, 23);
            label3.Name = "label3";
            label3.Size = new Size(114, 17);
            label3.TabIndex = 35;
            label3.Text = "Nowa stawka VAT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(32, 23);
            label1.Name = "label1";
            label1.Size = new Size(112, 17);
            label1.TabIndex = 33;
            label1.Text = "Kategoria towaru";
            // 
            // KategoriaTowaru
            // 
            KategoriaTowaru.DropDownStyle = ComboBoxStyle.DropDownList;
            KategoriaTowaru.FormattingEnabled = true;
            KategoriaTowaru.Location = new Point(32, 43);
            KategoriaTowaru.Margin = new Padding(3, 2, 3, 2);
            KategoriaTowaru.Name = "KategoriaTowaru";
            KategoriaTowaru.Size = new Size(138, 23);
            KategoriaTowaru.TabIndex = 31;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "23%", "8%", "5%", "0%", "zw" });
            comboBox1.Location = new Point(191, 43);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 37;
            // 
            // FormVATKategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(1265, 630);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(KategoriaTowaru);
            Controls.Add(DGVStawka);
            Margin = new Padding(2);
            Name = "FormVATKategoria";
            Text = "FormVATKategoria";
            Load += FormVATKategoria_Load;
            ((System.ComponentModel.ISupportInitialize)DGVStawka).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVStawka;
        private Button button1;
        private Label label3;
        private Label label1;
        private ComboBox KategoriaTowaru;
        private ComboBox comboBox1;
    }
}