namespace TestowanieOprogramowania
{
    partial class FormSprzedazDetails
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
            label1 = new Label();
            labelNazwaKlienta = new Label();
            labelNazwaSprzedawcy = new Label();
            labelIDSprzedazy = new Label();
            labelDataSprzedazy = new Label();
            label2 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-5, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1148, 347);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(287, 33);
            label1.TabIndex = 1;
            label1.Text = "Szczegóły sprzedaży:";
            // 
            // labelNazwaKlienta
            // 
            labelNazwaKlienta.AutoSize = true;
            labelNazwaKlienta.ForeColor = SystemColors.Control;
            labelNazwaKlienta.Location = new Point(306, 35);
            labelNazwaKlienta.Name = "labelNazwaKlienta";
            labelNazwaKlienta.Size = new Size(38, 15);
            labelNazwaKlienta.TabIndex = 2;
            labelNazwaKlienta.Text = "label2";
            // 
            // labelNazwaSprzedawcy
            // 
            labelNazwaSprzedawcy.AutoSize = true;
            labelNazwaSprzedawcy.ForeColor = SystemColors.Control;
            labelNazwaSprzedawcy.Location = new Point(439, 35);
            labelNazwaSprzedawcy.Name = "labelNazwaSprzedawcy";
            labelNazwaSprzedawcy.Size = new Size(38, 15);
            labelNazwaSprzedawcy.TabIndex = 3;
            labelNazwaSprzedawcy.Text = "label2";
            // 
            // labelIDSprzedazy
            // 
            labelIDSprzedazy.AutoSize = true;
            labelIDSprzedazy.ForeColor = SystemColors.Control;
            labelIDSprzedazy.Location = new Point(561, 35);
            labelIDSprzedazy.Name = "labelIDSprzedazy";
            labelIDSprzedazy.Size = new Size(38, 15);
            labelIDSprzedazy.TabIndex = 4;
            labelIDSprzedazy.Text = "label2";
            // 
            // labelDataSprzedazy
            // 
            labelDataSprzedazy.AutoSize = true;
            labelDataSprzedazy.ForeColor = SystemColors.Control;
            labelDataSprzedazy.Location = new Point(684, 35);
            labelDataSprzedazy.Name = "labelDataSprzedazy";
            labelDataSprzedazy.Size = new Size(38, 15);
            labelDataSprzedazy.TabIndex = 5;
            labelDataSprzedazy.Text = "label2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(204, 21);
            label2.TabIndex = 6;
            label2.Text = "Produkty w tej sprzedazy:";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(306, 9);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 7;
            label3.Text = "Nazwa Klienta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(439, 9);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 8;
            label4.Text = "Nazwa Sprzedawcy";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(561, 9);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 9;
            label5.Text = "IDSprzedazy";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(684, 9);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 10;
            label6.Text = "DataSprzedazy";
            // 
            // FormSprzedazDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1142, 446);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(labelDataSprzedazy);
            Controls.Add(labelIDSprzedazy);
            Controls.Add(labelNazwaSprzedawcy);
            Controls.Add(labelNazwaKlienta);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "FormSprzedazDetails";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormSprzedazDetails";
            Load += FormSprzedazDetails_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label labelNazwaKlienta;
        private Label labelNazwaSprzedawcy;
        private Label labelIDSprzedazy;
        private Label labelDataSprzedazy;
        private Label label2;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}