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
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            textBoxSzukaj = new TextBox();
            label2 = new Label();
            buttonNadajRole = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 140);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1869, 878);
            dataGridView1.TabIndex = 9;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Imie", "Nazwisko", "Login", "Email", "NumerTelefonu", "Nazwa_stanowiska" });
            comboBox1.Location = new Point(344, 57);
            comboBox1.Margin = new Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(195, 33);
            comboBox1.TabIndex = 18;
            // 
            // textBoxSzukaj
            // 
            textBoxSzukaj.BackColor = Color.Silver;
            textBoxSzukaj.BorderStyle = BorderStyle.None;
            textBoxSzukaj.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSzukaj.Location = new Point(23, 57);
            textBoxSzukaj.Margin = new Padding(4, 5, 4, 5);
            textBoxSzukaj.Name = "textBoxSzukaj";
            textBoxSzukaj.Size = new Size(259, 39);
            textBoxSzukaj.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Location = new Point(70, 27);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(155, 25);
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
            buttonNadajRole.Location = new Point(1352, 35);
            buttonNadajRole.Margin = new Padding(4, 5, 4, 5);
            buttonNadajRole.Name = "buttonNadajRole";
            buttonNadajRole.Size = new Size(176, 77);
            buttonNadajRole.TabIndex = 20;
            buttonNadajRole.Text = "Dodaj produkt";
            buttonNadajRole.UseVisualStyleBackColor = false;
            // 
            // StanMagazynu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1864, 1050);
            Controls.Add(buttonNadajRole);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(textBoxSzukaj);
            Controls.Add(dataGridView1);
            Name = "StanMagazynu";
            Text = "StanMagazynu";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private TextBox textBoxSzukaj;
        private Label label2;
        private Button buttonNadajRole;
    }
}