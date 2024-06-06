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
            buttonEdytujRole = new Button();
            buttonUsunRole = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            buttonDodajRole = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonEdytujRole
            // 
            buttonEdytujRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEdytujRole.BackColor = Color.Indigo;
            buttonEdytujRole.Cursor = Cursors.Hand;
            buttonEdytujRole.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEdytujRole.ForeColor = Color.White;
            buttonEdytujRole.Location = new Point(1107, 12);
            buttonEdytujRole.Name = "buttonEdytujRole";
            buttonEdytujRole.Size = new Size(91, 46);
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
            buttonUsunRole.Location = new Point(1204, 12);
            buttonUsunRole.Name = "buttonUsunRole";
            buttonUsunRole.Size = new Size(89, 46);
            buttonUsunRole.TabIndex = 22;
            buttonUsunRole.Text = "Usuń role";
            buttonUsunRole.UseVisualStyleBackColor = false;
            buttonUsunRole.Click += buttonUsunRole_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 18;
            label1.Text = "Role";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1303, 569);
            dataGridView1.TabIndex = 17;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // buttonDodajRole
            // 
            buttonDodajRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDodajRole.BackColor = Color.Indigo;
            buttonDodajRole.Cursor = Cursors.Hand;
            buttonDodajRole.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDodajRole.ForeColor = Color.White;
            buttonDodajRole.Location = new Point(1011, 12);
            buttonDodajRole.Name = "buttonDodajRole";
            buttonDodajRole.Size = new Size(90, 46);
            buttonDodajRole.TabIndex = 25;
            buttonDodajRole.Text = "Dodaj role";
            buttonDodajRole.UseVisualStyleBackColor = false;
            buttonDodajRole.Click += buttonDodajRole_Click;
            // 
            // FormUprawnienia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 37, 37);
            ClientSize = new Size(1305, 630);
            Controls.Add(buttonDodajRole);
            Controls.Add(buttonEdytujRole);
            Controls.Add(buttonUsunRole);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "FormUprawnienia";
            Text = "FormUprawnienia";
            Load += FormUprawnienia_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonEdytujRole;
        private Button buttonUsunRole;
        private Label label1;
        private DataGridView dataGridView1;
        private Button buttonDodajRole;
    }
}