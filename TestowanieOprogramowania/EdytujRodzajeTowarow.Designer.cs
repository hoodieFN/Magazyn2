namespace TestowanieOprogramowania
{
    partial class EdytujRodzajeTowarow
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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            textBoxNazwaTowaru = new TextBox();
            label1 = new Label();
            listBoxStawkaVAT = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(366, 67);
            button1.Name = "button1";
            button1.Size = new Size(132, 53);
            button1.TabIndex = 43;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(147, 150);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(506, 226);
            dataGridView1.TabIndex = 44;
            // 
            // button2
            // 
            button2.AllowDrop = true;
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.Indigo;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(521, 67);
            button2.Name = "button2";
            button2.Size = new Size(132, 53);
            button2.TabIndex = 45;
            button2.Text = "Usun zaznaczone";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBoxNazwaTowaru
            // 
            textBoxNazwaTowaru.Anchor = AnchorStyles.None;
            textBoxNazwaTowaru.BackColor = Color.Silver;
            textBoxNazwaTowaru.BorderStyle = BorderStyle.None;
            textBoxNazwaTowaru.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNazwaTowaru.Location = new Point(147, 42);
            textBoxNazwaTowaru.Name = "textBoxNazwaTowaru";
            textBoxNazwaTowaru.Size = new Size(181, 26);
            textBoxNazwaTowaru.TabIndex = 46;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(147, 24);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 47;
            label1.Text = "Nazwa Rodazju";
            // 
            // listBoxStawkaVAT
            // 
            listBoxStawkaVAT.FormattingEnabled = true;
            listBoxStawkaVAT.Items.AddRange(new object[] { "23%", "8%", "5%", "0%", "zw" });
            listBoxStawkaVAT.Location = new Point(147, 97);
            listBoxStawkaVAT.Name = "listBoxStawkaVAT";
            listBoxStawkaVAT.Size = new Size(181, 23);
            listBoxStawkaVAT.TabIndex = 48;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(147, 79);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 49;
            label2.Text = "Stawka VAT";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(379, 24);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 50;
            label3.Text = "Dorobic walidacje";
            // 
            // EdytujRodzajeTowarow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBoxStawkaVAT);
            Controls.Add(label1);
            Controls.Add(textBoxNazwaTowaru);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "EdytujRodzajeTowarow";
            Text = "EdytujRodzajeTowarow";
            Load += EdytujRodzajeTowarow_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private TextBox textBoxNazwaTowaru;
        private Label label1;
        private ComboBox listBoxStawkaVAT;
        private Label label2;
        private Label label3;
    }
}