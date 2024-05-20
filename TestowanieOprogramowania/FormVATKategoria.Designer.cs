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
            NowaStawka = new NumericUpDown();
            label1 = new Label();
            KategoriaTowaru = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DGVStawka).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NowaStawka).BeginInit();
            SuspendLayout();
            // 
            // DGVStawka
            // 
            DGVStawka.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVStawka.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVStawka.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVStawka.Location = new Point(-3, 143);
            DGVStawka.Margin = new Padding(4, 5, 4, 5);
            DGVStawka.Name = "DGVStawka";
            DGVStawka.RowHeadersWidth = 51;
            DGVStawka.RowTemplate.Height = 25;
            DGVStawka.Size = new Size(1869, 907);
            DGVStawka.TabIndex = 11;
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(737, 48);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(176, 57);
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
            label3.Location = new Point(515, 38);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(170, 21);
            label3.TabIndex = 35;
            label3.Text = "Nowa stawka VAT";
            // 
            // NowaStawka
            // 
            NowaStawka.Location = new Point(515, 74);
            NowaStawka.Name = "NowaStawka";
            NowaStawka.Size = new Size(180, 31);
            NowaStawka.TabIndex = 34;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(45, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(162, 21);
            label1.TabIndex = 33;
            label1.Text = "Kategoria towaru";
            // 
            // KategoriaTowaru
            // 
            KategoriaTowaru.DropDownStyle = ComboBoxStyle.DropDownList;
            KategoriaTowaru.FormattingEnabled = true;
            KategoriaTowaru.Location = new Point(45, 72);
            KategoriaTowaru.Margin = new Padding(4, 3, 4, 3);
            KategoriaTowaru.Name = "KategoriaTowaru";
            KategoriaTowaru.Size = new Size(195, 33);
            KategoriaTowaru.TabIndex = 31;
            // 
            // FormVATKategoria
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(1924, 1050);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(NowaStawka);
            Controls.Add(label1);
            Controls.Add(KategoriaTowaru);
            Controls.Add(DGVStawka);
            Name = "FormVATKategoria";
            Text = "FormVATKategoria";
            ((System.ComponentModel.ISupportInitialize)DGVStawka).EndInit();
            ((System.ComponentModel.ISupportInitialize)NowaStawka).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVStawka;
        private Button button1;
        private Label label3;
        private NumericUpDown NowaStawka;
        private Label label1;
        private ComboBox KategoriaTowaru;
    }
}