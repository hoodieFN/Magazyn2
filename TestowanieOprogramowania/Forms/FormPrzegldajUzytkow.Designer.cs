namespace TestowanieOprogramowania
{
    partial class FormPrzegldajUzytkow
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
            comboBoxUprawnienia = new ComboBox();
            dataGridViewUzytkownicy = new DataGridView();
            button1 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUzytkownicy).BeginInit();
            SuspendLayout();
            // 
            // comboBoxUprawnienia
            // 
            comboBoxUprawnienia.FormattingEnabled = true;
            comboBoxUprawnienia.Location = new Point(12, 22);
            comboBoxUprawnienia.Name = "comboBoxUprawnienia";
            comboBoxUprawnienia.Size = new Size(187, 23);
            comboBoxUprawnienia.TabIndex = 0;
            comboBoxUprawnienia.SelectedIndexChanged += comboBoxUprawnienia_SelectedIndexChanged_1;
            // 
            // dataGridViewUzytkownicy
            // 
            dataGridViewUzytkownicy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewUzytkownicy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUzytkownicy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUzytkownicy.Location = new Point(2, 51);
            dataGridViewUzytkownicy.Name = "dataGridViewUzytkownicy";
            dataGridViewUzytkownicy.RowTemplate.Height = 25;
            dataGridViewUzytkownicy.Size = new Size(897, 451);
            dataGridViewUzytkownicy.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(205, 4);
            button1.Name = "button1";
            button1.Size = new Size(133, 43);
            button1.TabIndex = 2;
            button1.Text = "Szukaj";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 4);
            label1.Name = "label1";
            label1.Size = new Size(155, 15);
            label1.TabIndex = 3;
            label1.Text = "Lista dostępnych uprawnien";
            // 
            // FormPrzegldajUzytkow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 37, 37);
            ClientSize = new Size(902, 503);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridViewUzytkownicy);
            Controls.Add(comboBoxUprawnienia);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPrzegldajUzytkow";
            Text = "FormPrzegldajUzytkow";
            Load += FormPrzegldajUzytkow_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUzytkownicy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxUprawnienia;
        private DataGridView dataGridViewUzytkownicy;
        private Button button1;
        private Label label1;
    }
}