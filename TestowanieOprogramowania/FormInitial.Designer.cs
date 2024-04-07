namespace TestowanieOprogramowania
{
    partial class FormInitial
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
            panelslide = new Panel();
            button1 = new Button();
            labelWitajUzytkowniku = new Label();
            buttonListaUprawnien = new Button();
            buttonLogout = new Button();
            buttonZarzadzaj = new Button();
            mainpanel = new Panel();
            panelslide.SuspendLayout();
            SuspendLayout();
            // 
            // panelslide
            // 
            panelslide.BackColor = Color.FromArgb(24, 24, 24);
            panelslide.Controls.Add(button1);
            panelslide.Controls.Add(labelWitajUzytkowniku);
            panelslide.Controls.Add(buttonListaUprawnien);
            panelslide.Controls.Add(buttonLogout);
            panelslide.Controls.Add(buttonZarzadzaj);
            panelslide.Dock = DockStyle.Left;
            panelslide.Location = new Point(0, 0);
            panelslide.Margin = new Padding(4, 5, 4, 5);
            panelslide.Name = "panelslide";
            panelslide.Size = new Size(277, 1050);
            panelslide.TabIndex = 0;
            panelslide.Paint += panelslide_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.Indigo;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(17, 281);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(244, 88);
            button1.TabIndex = 4;
            button1.Text = "Stan magazynu";
            button1.UseVisualStyleBackColor = false;
            // 
            // labelWitajUzytkowniku
            // 
            labelWitajUzytkowniku.AutoSize = true;
            labelWitajUzytkowniku.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelWitajUzytkowniku.ForeColor = SystemColors.ControlLightLight;
            labelWitajUzytkowniku.Location = new Point(17, 32);
            labelWitajUzytkowniku.Margin = new Padding(4, 0, 4, 0);
            labelWitajUzytkowniku.Name = "labelWitajUzytkowniku";
            labelWitajUzytkowniku.Size = new Size(84, 28);
            labelWitajUzytkowniku.TabIndex = 3;
            labelWitajUzytkowniku.Text = "label1";
            // 
            // buttonListaUprawnien
            // 
            buttonListaUprawnien.BackColor = Color.Indigo;
            buttonListaUprawnien.Cursor = Cursors.Hand;
            buttonListaUprawnien.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonListaUprawnien.ForeColor = Color.White;
            buttonListaUprawnien.Location = new Point(17, 183);
            buttonListaUprawnien.Margin = new Padding(4, 5, 4, 5);
            buttonListaUprawnien.Name = "buttonListaUprawnien";
            buttonListaUprawnien.Size = new Size(244, 88);
            buttonListaUprawnien.TabIndex = 2;
            buttonListaUprawnien.Text = "Lista Uprawnien";
            buttonListaUprawnien.UseVisualStyleBackColor = false;
            buttonListaUprawnien.Click += buttonListaUprawnien_Click;
            // 
            // buttonLogout
            // 
            buttonLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonLogout.BackColor = Color.Indigo;
            buttonLogout.Cursor = Cursors.Hand;
            buttonLogout.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(17, 941);
            buttonLogout.Margin = new Padding(4, 5, 4, 5);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(244, 88);
            buttonLogout.TabIndex = 1;
            buttonLogout.Text = "Wyloguj";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // buttonZarzadzaj
            // 
            buttonZarzadzaj.BackColor = Color.Indigo;
            buttonZarzadzaj.Cursor = Cursors.Hand;
            buttonZarzadzaj.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonZarzadzaj.ForeColor = Color.White;
            buttonZarzadzaj.Location = new Point(17, 85);
            buttonZarzadzaj.Margin = new Padding(4, 5, 4, 5);
            buttonZarzadzaj.Name = "buttonZarzadzaj";
            buttonZarzadzaj.Size = new Size(244, 88);
            buttonZarzadzaj.TabIndex = 0;
            buttonZarzadzaj.Text = "Zarządzaj Użytkownikami";
            buttonZarzadzaj.UseVisualStyleBackColor = false;
            buttonZarzadzaj.Click += buttonZarzadzaj_Click;
            // 
            // mainpanel
            // 
            mainpanel.BackColor = Color.FromArgb(24, 24, 24);
            mainpanel.Dock = DockStyle.Fill;
            mainpanel.Location = new Point(277, 0);
            mainpanel.Margin = new Padding(4, 5, 4, 5);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(1459, 1050);
            mainpanel.TabIndex = 1;
            mainpanel.Paint += mainpanel_Paint;
            // 
            // FormInitial
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1736, 1050);
            Controls.Add(mainpanel);
            Controls.Add(panelslide);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormInitial";
            Text = "FormInitial";
            WindowState = FormWindowState.Maximized;
            panelslide.ResumeLayout(false);
            panelslide.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelslide;
        private Button buttonZarzadzaj;
        private Panel mainpanel;
        private Button buttonLogout;
        private Button buttonListaUprawnien;
        private Label labelWitajUzytkowniku;
        private Button button1;
    }
}