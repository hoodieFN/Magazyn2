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
            ((System.ComponentModel.ISupportInitialize)dataGridViewUzytkownicy).BeginInit();
            SuspendLayout();
            // 
            // comboBoxUprawnienia
            // 
            comboBoxUprawnienia.Anchor = AnchorStyles.None;
            comboBoxUprawnienia.FormattingEnabled = true;
            comboBoxUprawnienia.Location = new Point(265, 24);
            comboBoxUprawnienia.Name = "comboBoxUprawnienia";
            comboBoxUprawnienia.Size = new Size(187, 23);
            comboBoxUprawnienia.TabIndex = 0;
            comboBoxUprawnienia.SelectedIndexChanged += comboBoxUprawnienia_SelectedIndexChanged_1;
            // 
            // dataGridViewUzytkownicy
            // 
            dataGridViewUzytkownicy.Anchor = AnchorStyles.None;
            dataGridViewUzytkownicy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUzytkownicy.Location = new Point(138, 89);
            dataGridViewUzytkownicy.Name = "dataGridViewUzytkownicy";
            dataGridViewUzytkownicy.RowTemplate.Height = 25;
            dataGridViewUzytkownicy.Size = new Size(618, 306);
            dataGridViewUzytkownicy.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(474, 17);
            button1.Name = "button1";
            button1.Size = new Size(133, 35);
            button1.TabIndex = 2;
            button1.Text = "Szukaj";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // FormPrzegldajUzytkow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 37, 37);
            ClientSize = new Size(902, 503);
            Controls.Add(button1);
            Controls.Add(dataGridViewUzytkownicy);
            Controls.Add(comboBoxUprawnienia);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPrzegldajUzytkow";
            Text = "FormPrzegldajUzytkow";
            Load += FormPrzegldajUzytkow_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUzytkownicy).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxUprawnienia;
        private DataGridView dataGridViewUzytkownicy;
        private Button button1;
    }
}