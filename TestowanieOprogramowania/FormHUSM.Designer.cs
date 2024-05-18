namespace TestowanieOprogramowania
{
    partial class FormHUSM
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
            SzukajProdukt = new Button();
            dataGridView1 = new DataGridView();
            dateTimePickerStart1 = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // SzukajProdukt
            // 
            SzukajProdukt.AllowDrop = true;
            SzukajProdukt.BackColor = Color.Indigo;
            SzukajProdukt.Cursor = Cursors.Hand;
            SzukajProdukt.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SzukajProdukt.ForeColor = Color.White;
            SzukajProdukt.Location = new Point(12, 12);
            SzukajProdukt.Name = "SzukajProdukt";
            SzukajProdukt.Size = new Size(123, 34);
            SzukajProdukt.TabIndex = 22;
            SzukajProdukt.Text = "Szukaj";
            SzukajProdukt.UseVisualStyleBackColor = false;
            SzukajProdukt.Click += SzukajProdukt_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 63);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1503, 587);
            dataGridView1.TabIndex = 23;
            // 
            // dateTimePickerStart1
            // 
            dateTimePickerStart1.Location = new Point(649, 19);
            dateTimePickerStart1.Name = "dateTimePickerStart1";
            dateTimePickerStart1.Size = new Size(200, 23);
            dateTimePickerStart1.TabIndex = 27;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(870, 18);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(200, 23);
            dateTimePickerEnd.TabIndex = 28;
            // 
            // FormHUSM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1527, 662);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart1);
            Controls.Add(dataGridView1);
            Controls.Add(SzukajProdukt);
            Name = "FormHUSM";
            Text = "FormHUSM";
            Load += FormHUSM_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button SzukajProdukt;
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePickerStart1;
        private DateTimePicker dateTimePickerEnd;
    }
}