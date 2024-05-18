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
            dateTimePickerStart = new DateTimePicker();
            buttonSzukaj = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 59);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1438, 658);
            dataGridView1.TabIndex = 0;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Format = DateTimePickerFormat.Short;
            dateTimePickerStart.Location = new Point(166, 31);
            dateTimePickerStart.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(109, 23);
            dateTimePickerStart.TabIndex = 2;
            dateTimePickerStart.ValueChanged += dateTimePickerStart_ValueChanged;
            // 
            // buttonSzukaj
            // 
            buttonSzukaj.BackColor = Color.Indigo;
            buttonSzukaj.Cursor = Cursors.Hand;
            buttonSzukaj.ForeColor = SystemColors.ButtonFace;
            buttonSzukaj.Location = new Point(12, 12);
            buttonSzukaj.Name = "buttonSzukaj";
            buttonSzukaj.Size = new Size(138, 42);
            buttonSzukaj.TabIndex = 29;
            buttonSzukaj.Text = "Szukaj";
            buttonSzukaj.UseVisualStyleBackColor = false;
            buttonSzukaj.Click += buttonSzukaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(166, 12);
            label1.Name = "label1";
            label1.Size = new Size(38, 17);
            label1.TabIndex = 30;
            label1.Text = "Data";
            // 
            // FormPrzegladajHistorie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1462, 728);
            Controls.Add(label1);
            Controls.Add(buttonSzukaj);
            Controls.Add(dateTimePickerStart);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPrzegladajHistorie";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPrzegladajHistorie";
            Load += FormPrzegladajHistorie_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DateTimePicker dateTimePickerStart;
        private Button buttonSzukaj;
        private Label label1;
    }
}