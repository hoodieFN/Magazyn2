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
            label2 = new Label();
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
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(764, 15);
            label1.TabIndex = 11;
            label1.Text = "Tu są sprzedaze trzeba dodac filtorwanie i ejszcze trigera ze jak sprzedane zostały 2 produkty to w histori magazynowej jest ze (sprzedano 2 sztuk)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(59, 54);
            label2.Name = "label2";
            label2.Size = new Size(707, 15);
            label2.TabIndex = 12;
            label2.Text = "tutaj wyswietlac najwazniejsze informacje i jak sie kliknie to więcej info zrobic tak ze jet id sprzedazy i produkty do tego i kto zamawial";
            // 
            // FormSprzedaze
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1031, 599);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormSprzedaze";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSprzedaze";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
    }
}