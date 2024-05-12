namespace TestowanieOprogramowania
{
    partial class FormPrzegladajHistorie
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
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            textBoxSearchText = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonSzukaj = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(96, 174);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1055, 389);
            dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.None;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Okres", "Rodzaj towaru", "Nazwa towaru", "Rejestrujacy" });
            comboBox1.Location = new Point(456, 108);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Anchor = AnchorStyles.None;
            dateTimePickerStart.Location = new Point(630, 109);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(250, 27);
            dateTimePickerStart.TabIndex = 2;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Anchor = AnchorStyles.None;
            dateTimePickerEnd.Location = new Point(901, 109);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(250, 27);
            dateTimePickerEnd.TabIndex = 3;
            // 
            // textBoxSearchText
            // 
            textBoxSearchText.Anchor = AnchorStyles.None;
            textBoxSearchText.Location = new Point(271, 109);
            textBoxSearchText.Name = "textBoxSearchText";
            textBoxSearchText.Size = new Size(142, 27);
            textBoxSearchText.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(271, 86);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 5;
            label2.Text = "Wyszukiwarka";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(452, 85);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 6;
            label1.Text = "Kryterium";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(626, 85);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 7;
            label3.Text = "Od";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(897, 85);
            label4.Name = "label4";
            label4.Size = new Size(30, 20);
            label4.TabIndex = 8;
            label4.Text = "Do";
            // 
            // buttonSzukaj
            // 
            buttonSzukaj.Anchor = AnchorStyles.None;
            buttonSzukaj.BackColor = Color.Indigo;
            buttonSzukaj.Cursor = Cursors.Hand;
            buttonSzukaj.ForeColor = SystemColors.ButtonFace;
            buttonSzukaj.Location = new Point(96, 108);
            buttonSzukaj.Margin = new Padding(3, 4, 3, 4);
            buttonSzukaj.Name = "buttonSzukaj";
            buttonSzukaj.Size = new Size(142, 28);
            buttonSzukaj.TabIndex = 29;
            buttonSzukaj.Text = "Szukaj";
            buttonSzukaj.UseVisualStyleBackColor = false;
            buttonSzukaj.Click += buttonSzukaj_Click;
            // 
            // FormPrzegladajHistorie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1255, 688);
            Controls.Add(buttonSzukaj);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textBoxSearchText);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Name = "FormPrzegladajHistorie";
            Text = "FormPrzegladajHistorie";
            Load += FormPrzegladajHistorie_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private TextBox textBoxSearchText;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Button buttonSzukaj;
    }
}