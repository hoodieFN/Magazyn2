namespace TestowanieOprogramowania
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
            buttonSzukaj = new Button();
            buttonDodajUzytkownika = new Button();
            buttonUsunUzytkownika = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(233, 264);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(619, 150);
            dataGridView1.TabIndex = 8;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(233, 245);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 9;
            label1.Text = "Użytkownicy";
            // 
            // textBoxSzukaj
            // 
            textBoxSzukaj.Anchor = AnchorStyles.None;
            textBoxSzukaj.Location = new Point(233, 219);
            textBoxSzukaj.Name = "textBoxSzukaj";
            textBoxSzukaj.Size = new Size(181, 23);
            textBoxSzukaj.TabIndex = 10;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(233, 201);
            label2.Name = "label2";
            label2.Size = new Size(125, 15);
            label2.TabIndex = 11;
            label2.Text = "Wyszukaj użytkownika";
            // 
            // buttonSzukaj
            // 
            buttonSzukaj.Anchor = AnchorStyles.None;
            buttonSzukaj.Location = new Point(420, 219);
            buttonSzukaj.Name = "buttonSzukaj";
            buttonSzukaj.Size = new Size(53, 23);
            buttonSzukaj.TabIndex = 12;
            buttonSzukaj.Text = "Szukaj";
            buttonSzukaj.UseVisualStyleBackColor = true;
            buttonSzukaj.Click += buttonSzukaj_Click;
            // 
            // buttonDodajUzytkownika
            // 
            buttonDodajUzytkownika.Anchor = AnchorStyles.None;
            buttonDodajUzytkownika.Location = new Point(233, 420);
            buttonDodajUzytkownika.Name = "buttonDodajUzytkownika";
            buttonDodajUzytkownika.Size = new Size(90, 47);
            buttonDodajUzytkownika.TabIndex = 13;
            buttonDodajUzytkownika.Text = "Dodaj użytkownika";
            buttonDodajUzytkownika.UseVisualStyleBackColor = true;
            buttonDodajUzytkownika.Click += buttonDodajUzytkownika_Click_1;
            // 
            // buttonUsunUzytkownika
            // 
            buttonUsunUzytkownika.Anchor = AnchorStyles.None;
            buttonUsunUzytkownika.Location = new Point(329, 420);
            buttonUsunUzytkownika.Name = "buttonUsunUzytkownika";
            buttonUsunUzytkownika.Size = new Size(89, 47);
            buttonUsunUzytkownika.TabIndex = 14;
            buttonUsunUzytkownika.Text = "Usuń użytkownika";
            buttonUsunUzytkownika.UseVisualStyleBackColor = true;
            buttonUsunUzytkownika.Click += buttonUsunUzytkownika_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.Location = new Point(424, 420);
            button4.Name = "button4";
            button4.Size = new Size(91, 47);
            button4.TabIndex = 15;
            button4.Text = "Edytuj użytkownika";
            button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1024, 614);
            Controls.Add(button4);
            Controls.Add(buttonUsunUzytkownika);
            Controls.Add(buttonDodajUzytkownika);
            Controls.Add(buttonSzukaj);
            Controls.Add(label2);
            Controls.Add(textBoxSzukaj);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            MinimumSize = new Size(300, 300);
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
        private Button buttonSzukaj;
        private Button buttonDodajUzytkownika;
        private Button buttonUsunUzytkownika;
        private Button button4;
    }
}