﻿namespace TestowanieOprogramowania
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            label1 = new Label();
            textBoxSzukaj = new TextBox();
            label2 = new Label();
            buttonDodajUzytkownika = new Button();
            buttonUsunUzytkownika = new Button();
            buttonEdytujUzytkownika = new Button();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 95);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1481, 991);
            dataGridView1.TabIndex = 8;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 69);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 9;
            label1.Text = "Użytkownicy";
            // 
            // textBoxSzukaj
            // 
            textBoxSzukaj.BackColor = Color.Silver;
            textBoxSzukaj.BorderStyle = BorderStyle.None;
            textBoxSzukaj.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSzukaj.Location = new Point(14, 33);
            textBoxSzukaj.Margin = new Padding(3, 4, 3, 4);
            textBoxSzukaj.Name = "textBoxSzukaj";
            textBoxSzukaj.Size = new Size(207, 33);
            textBoxSzukaj.TabIndex = 10;
            textBoxSzukaj.TextChanged += buttonSzukaj_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 11);
            label2.Name = "label2";
            label2.Size = new Size(155, 20);
            label2.TabIndex = 11;
            label2.Text = "Wyszukaj użytkownika";
            // 
            // buttonDodajUzytkownika
            // 
            buttonDodajUzytkownika.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDodajUzytkownika.BackColor = Color.Indigo;
            buttonDodajUzytkownika.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDodajUzytkownika.ForeColor = Color.White;
            buttonDodajUzytkownika.Location = new Point(1179, 4);
            buttonDodajUzytkownika.Margin = new Padding(3, 4, 3, 4);
            buttonDodajUzytkownika.Name = "buttonDodajUzytkownika";
            buttonDodajUzytkownika.Size = new Size(103, 63);
            buttonDodajUzytkownika.TabIndex = 13;
            buttonDodajUzytkownika.Text = "Dodaj użytkownika";
            buttonDodajUzytkownika.UseVisualStyleBackColor = false;
            buttonDodajUzytkownika.Click += buttonDodajUzytkownika_Click_1;
            // 
            // buttonUsunUzytkownika
            // 
            buttonUsunUzytkownika.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonUsunUzytkownika.BackColor = Color.Indigo;
            buttonUsunUzytkownika.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonUsunUzytkownika.ForeColor = Color.White;
            buttonUsunUzytkownika.Location = new Point(1289, 4);
            buttonUsunUzytkownika.Margin = new Padding(3, 4, 3, 4);
            buttonUsunUzytkownika.Name = "buttonUsunUzytkownika";
            buttonUsunUzytkownika.Size = new Size(102, 63);
            buttonUsunUzytkownika.TabIndex = 14;
            buttonUsunUzytkownika.Text = "Usuń użytkownika";
            buttonUsunUzytkownika.UseVisualStyleBackColor = false;
            buttonUsunUzytkownika.Click += buttonUsunUzytkownika_Click;
            // 
            // buttonEdytujUzytkownika
            // 
            buttonEdytujUzytkownika.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEdytujUzytkownika.BackColor = Color.Indigo;
            buttonEdytujUzytkownika.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEdytujUzytkownika.ForeColor = Color.White;
            buttonEdytujUzytkownika.Location = new Point(1398, 4);
            buttonEdytujUzytkownika.Margin = new Padding(3, 4, 3, 4);
            buttonEdytujUzytkownika.Name = "buttonEdytujUzytkownika";
            buttonEdytujUzytkownika.Size = new Size(104, 63);
            buttonEdytujUzytkownika.TabIndex = 15;
            buttonEdytujUzytkownika.Text = "Edytuj użytkownika";
            buttonEdytujUzytkownika.UseVisualStyleBackColor = false;
            buttonEdytujUzytkownika.Click += buttonEdytujUzytkownika_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Imie", "Nazwisko", "Login", "Email", "NumerTelefonu" });
            comboBox1.Location = new Point(271, 33);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(157, 28);
            comboBox1.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1509, 1102);
            Controls.Add(comboBox1);
            Controls.Add(buttonEdytujUzytkownika);
            Controls.Add(buttonUsunUzytkownika);
            Controls.Add(buttonDodajUzytkownika);
            Controls.Add(label2);
            Controls.Add(textBoxSzukaj);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(343, 397);
            Name = "Form1";
            Text = "Lagerlokal";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBoxSzukaj;
        private Label label2;
        private Button buttonDodajUzytkownika;
        private Button buttonUsunUzytkownika;
        private Button buttonEdytujUzytkownika;
        private ComboBox comboBox1;
    }
}