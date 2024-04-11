namespace TestowanieOprogramowania
{
    partial class FormUprawnienia
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
            comboBox1 = new ComboBox();
            buttonEdytujRole = new Button();
            buttonUsunRole = new Button();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            buttonDodajRole = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Imie", "Nazwisko", "Login", "Email", "NumerTelefonu" });
            comboBox1.Location = new Point(10, 31);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(157, 28);
            comboBox1.TabIndex = 24;
            // 
            // buttonEdytujRole
            // 
            buttonEdytujRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEdytujRole.BackColor = Color.Indigo;
            buttonEdytujRole.Cursor = Cursors.Hand;
            buttonEdytujRole.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEdytujRole.ForeColor = Color.White;
            buttonEdytujRole.Location = new Point(1377, 13);
            buttonEdytujRole.Margin = new Padding(3, 4, 3, 4);
            buttonEdytujRole.Name = "buttonEdytujRole";
            buttonEdytujRole.Size = new Size(104, 62);
            buttonEdytujRole.TabIndex = 23;
            buttonEdytujRole.Text = "Edytuj role";
            buttonEdytujRole.UseVisualStyleBackColor = false;
            buttonEdytujRole.Click += buttonEdytujRole_Click;
            // 
            // buttonUsunRole
            // 
            buttonUsunRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonUsunRole.BackColor = Color.Indigo;
            buttonUsunRole.Cursor = Cursors.Hand;
            buttonUsunRole.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonUsunRole.ForeColor = Color.White;
            buttonUsunRole.Location = new Point(1268, 13);
            buttonUsunRole.Margin = new Padding(3, 4, 3, 4);
            buttonUsunRole.Name = "buttonUsunRole";
            buttonUsunRole.Size = new Size(102, 62);
            buttonUsunRole.TabIndex = 22;
            buttonUsunRole.Text = "Usuń role";
            buttonUsunRole.UseVisualStyleBackColor = false;
            buttonUsunRole.Click += buttonUsunRole_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Location = new Point(2, 8);
            label2.Name = "label2";
            label2.Size = new Size(155, 20);
            label2.TabIndex = 20;
            label2.Text = "Wyszukaj uprawnienia";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(2, 66);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 18;
            label1.Text = "Uprawnienia";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 93);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1495, 776);
            dataGridView1.TabIndex = 17;
            // 
            // buttonDodajRole
            // 
            buttonDodajRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDodajRole.BackColor = Color.Indigo;
            buttonDodajRole.Cursor = Cursors.Hand;
            buttonDodajRole.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDodajRole.ForeColor = Color.White;
            buttonDodajRole.Location = new Point(1159, 13);
            buttonDodajRole.Margin = new Padding(3, 4, 3, 4);
            buttonDodajRole.Name = "buttonDodajRole";
            buttonDodajRole.Size = new Size(103, 62);
            buttonDodajRole.TabIndex = 25;
            buttonDodajRole.Text = "Dodaj role";
            buttonDodajRole.UseVisualStyleBackColor = false;
            buttonDodajRole.Click += buttonDodajRole_Click;
            // 
            // FormUprawnienia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1491, 840);
            Controls.Add(buttonDodajRole);
            Controls.Add(comboBox1);
            Controls.Add(buttonEdytujRole);
            Controls.Add(buttonUsunRole);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Margin = new Padding(2);
            Name = "FormUprawnienia";
            Text = "FormUprawnienia";
            Load += FormUprawnienia_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Button buttonEdytujRole;
        private Button buttonUsunRole;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private Button buttonDodajRole;
    }
}