namespace TestowanieOprogramowania
{
    partial class FormSprzedaze
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
            button4 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            textBoxFilter = new TextBox();
            comboBoxColumns = new ComboBox();
            button1 = new Button();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            labelOd = new Label();
            labelDo = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.BackColor = Color.Indigo;
            button4.Cursor = Cursors.Hand;
            button4.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.ControlLightLight;
            button4.Location = new Point(869, 12);
            button4.Name = "button4";
            button4.Size = new Size(150, 49);
            button4.TabIndex = 9;
            button4.Text = "Rejestracja sprzedaży";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1029, 525);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(29, 452);
            label1.Name = "label1";
            label1.Size = new Size(383, 15);
            label1.TabIndex = 11;
            label1.Text = "Dodac trigera aktualizujacego historei magazynow | Zrobic uprawnienia";
            // 
            // textBoxFilter
            // 
            textBoxFilter.Location = new Point(12, 27);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(104, 23);
            textBoxFilter.TabIndex = 13;
            // 
            // comboBoxColumns
            // 
            comboBoxColumns.FormattingEnabled = true;
            comboBoxColumns.Items.AddRange(new object[] { "Nabywca", "Sprzedawca", "Towary", "DataSprzedazy" });
            comboBoxColumns.Location = new Point(127, 27);
            comboBoxColumns.Name = "comboBoxColumns";
            comboBoxColumns.Size = new Size(121, 23);
            comboBoxColumns.TabIndex = 14;
            // 
            // button1
            // 
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(264, 27);
            button1.Name = "button1";
            button1.Size = new Size(111, 25);
            button1.TabIndex = 15;
            button1.Text = "Szukaj";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(392, 27);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(200, 23);
            dateTimePickerStart.TabIndex = 16;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(598, 27);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(200, 23);
            dateTimePickerEnd.TabIndex = 17;
            // 
            // labelOd
            // 
            labelOd.AutoSize = true;
            labelOd.ForeColor = SystemColors.Control;
            labelOd.Location = new Point(392, 9);
            labelOd.Name = "labelOd";
            labelOd.Size = new Size(23, 15);
            labelOd.TabIndex = 18;
            labelOd.Text = "Od";
            // 
            // labelDo
            // 
            labelDo.AutoSize = true;
            labelDo.ForeColor = SystemColors.Control;
            labelDo.Location = new Point(598, 12);
            labelDo.Name = "labelDo";
            labelDo.Size = new Size(22, 15);
            labelDo.TabIndex = 19;
            labelDo.Text = "Do";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 20;
            label3.Text = "Wyszukaj sprzedaż";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(127, 9);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 21;
            label4.Text = "Kategoria szukania";
            // 
            // FormSprzedaze
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1031, 599);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(labelDo);
            Controls.Add(labelOd);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(button1);
            Controls.Add(comboBoxColumns);
            Controls.Add(textBoxFilter);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormSprzedaze";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSprzedaze";
            Load += FormSprzedaze_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBoxFilter;
        private ComboBox comboBoxColumns;
        private Button button1;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Label labelOd;
        private Label labelDo;
        private Label label3;
        private Label label4;
    }
}