namespace TestowanieOprogramowania
{
    partial class FormUprawnienia
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
            comboBox1 = new ComboBox();
            buttonEdytujUzytkownika = new Button();
            buttonUsunUzytkownika = new Button();
            buttonDodajUzytkownika = new Button();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Imie", "Nazwisko", "Login", "Email", "NumerTelefonu" });
            comboBox1.Location = new Point(13, 39);
            comboBox1.Margin = new Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(195, 33);
            comboBox1.TabIndex = 24;
            // 
            // buttonEdytujUzytkownika
            // 
            buttonEdytujUzytkownika.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEdytujUzytkownika.BackColor = Color.Indigo;
            buttonEdytujUzytkownika.Cursor = Cursors.Hand;
            buttonEdytujUzytkownika.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEdytujUzytkownika.ForeColor = Color.White;
            buttonEdytujUzytkownika.Location = new Point(1721, 16);
            buttonEdytujUzytkownika.Margin = new Padding(4, 5, 4, 5);
            buttonEdytujUzytkownika.Name = "buttonEdytujUzytkownika";
            buttonEdytujUzytkownika.Size = new Size(130, 78);
            buttonEdytujUzytkownika.TabIndex = 23;
            buttonEdytujUzytkownika.Text = "Edytuj użytkownika";
            buttonEdytujUzytkownika.UseVisualStyleBackColor = false;
            // 
            // buttonUsunUzytkownika
            // 
            buttonUsunUzytkownika.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonUsunUzytkownika.BackColor = Color.Indigo;
            buttonUsunUzytkownika.Cursor = Cursors.Hand;
            buttonUsunUzytkownika.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonUsunUzytkownika.ForeColor = Color.White;
            buttonUsunUzytkownika.Location = new Point(1585, 16);
            buttonUsunUzytkownika.Margin = new Padding(4, 5, 4, 5);
            buttonUsunUzytkownika.Name = "buttonUsunUzytkownika";
            buttonUsunUzytkownika.Size = new Size(127, 78);
            buttonUsunUzytkownika.TabIndex = 22;
            buttonUsunUzytkownika.Text = "Usuń użytkownika";
            buttonUsunUzytkownika.UseVisualStyleBackColor = false;
            // 
            // buttonDodajUzytkownika
            // 
            buttonDodajUzytkownika.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDodajUzytkownika.BackColor = Color.Indigo;
            buttonDodajUzytkownika.Cursor = Cursors.Hand;
            buttonDodajUzytkownika.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDodajUzytkownika.ForeColor = Color.White;
            buttonDodajUzytkownika.Location = new Point(1448, 16);
            buttonDodajUzytkownika.Margin = new Padding(4, 5, 4, 5);
            buttonDodajUzytkownika.Name = "buttonDodajUzytkownika";
            buttonDodajUzytkownika.Size = new Size(129, 78);
            buttonDodajUzytkownika.TabIndex = 21;
            buttonDodajUzytkownika.Text = "Dodaj użytkownika";
            buttonDodajUzytkownika.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Location = new Point(2, 10);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(186, 25);
            label2.TabIndex = 20;
            label2.Text = "Wyszukaj uprawnienia";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(2, 83);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(109, 25);
            label1.TabIndex = 18;
            label1.Text = "Uprawnienia";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 116);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1869, 970);
            dataGridView1.TabIndex = 17;
            // 
            // FormUprawnienia
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1864, 1050);
            Controls.Add(comboBox1);
            Controls.Add(buttonEdytujUzytkownika);
            Controls.Add(buttonUsunUzytkownika);
            Controls.Add(buttonDodajUzytkownika);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "FormUprawnienia";
            Text = "FormUprawnienia";
            Load += FormUprawnienia_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Button buttonEdytujUzytkownika;
        private Button buttonUsunUzytkownika;
        private Button buttonDodajUzytkownika;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
    }
}