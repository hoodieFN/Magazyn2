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
            button1 = new Button();
            textBoxProduktID = new TextBox();
            ProduktID = new Label();
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
            dateTimePickerStart.Location = new Point(156, 31);
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
            buttonSzukaj.Text = "Szukaj po dacie";
            buttonSzukaj.UseVisualStyleBackColor = false;
            buttonSzukaj.Click += buttonSzukaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(156, 12);
            label1.Name = "label1";
            label1.Size = new Size(38, 17);
            label1.TabIndex = 30;
            label1.Text = "Data";
            // 
            // button1
            // 
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(271, 12);
            button1.Name = "button1";
            button1.Size = new Size(138, 42);
            button1.TabIndex = 31;
            button1.Text = "Szukaj po ProduktID";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBoxProduktID
            // 
            textBoxProduktID.Location = new Point(415, 31);
            textBoxProduktID.Name = "textBoxProduktID";
            textBoxProduktID.Size = new Size(100, 23);
            textBoxProduktID.TabIndex = 32;
            // 
            // ProduktID
            // 
            ProduktID.AutoSize = true;
            ProduktID.BackColor = Color.Transparent;
            ProduktID.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ProduktID.ForeColor = Color.White;
            ProduktID.Location = new Point(415, 9);
            ProduktID.Name = "ProduktID";
            ProduktID.Size = new Size(65, 17);
            ProduktID.TabIndex = 33;
            ProduktID.Text = "ProduktID";
            // 
            // FormPrzegladajHistorie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1462, 728);
            Controls.Add(ProduktID);
            Controls.Add(textBoxProduktID);
            Controls.Add(button1);
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
        private Button button1;
        private TextBox textBoxProduktID;
        private Label ProduktID;
    }
}