namespace TestowanieOprogramowania
{
    partial class FormZapisDzienny
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
            dateTimePicker1 = new DateTimePicker();
            button6 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(145, 37);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(90, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // button6
            // 
            button6.AllowDrop = true;
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.BackColor = Color.Indigo;
            button6.Cursor = Cursors.Hand;
            button6.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button6.ForeColor = Color.White;
            button6.Location = new Point(145, 66);
            button6.Name = "button6";
            button6.Size = new Size(90, 77);
            button6.TabIndex = 31;
            button6.Text = "Wykonaj zapis dzienny";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(12, 160);
            label1.Name = "label1";
            label1.Size = new Size(362, 20);
            label1.TabIndex = 32;
            label1.Text = "Zapis wykonujemy raz dziennie o jednej godzinie!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(12, 198);
            label2.Name = "label2";
            label2.Size = new Size(254, 21);
            label2.TabIndex = 33;
            label2.Text = "Czy zapis został dzis wykonany?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(272, 198);
            label3.Name = "label3";
            label3.Size = new Size(37, 21);
            label3.TabIndex = 34;
            label3.Text = "Tak";
            // 
            // FormZapisDzienny
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(393, 241);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(dateTimePicker1);
            Name = "FormZapisDzienny";
            Text = "FormZapisDzienny";
            Load += FormZapisDzienny_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Button button6;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}