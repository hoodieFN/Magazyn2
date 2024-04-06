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
            panelslide.Controls.Add(labelWitajUzytkowniku);
            panelslide.Controls.Add(buttonListaUprawnien);
            panelslide.Controls.Add(buttonLogout);
            panelslide.Controls.Add(buttonZarzadzaj);
            panelslide.Dock = DockStyle.Left;
            panelslide.Location = new Point(0, 0);
            panelslide.Name = "panelslide";
            panelslide.Size = new Size(200, 763);
            panelslide.TabIndex = 0;
            panelslide.Paint += panelslide_Paint;
            // 
            // labelWitajUzytkowniku
            // 
            labelWitajUzytkowniku.AutoSize = true;
            labelWitajUzytkowniku.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelWitajUzytkowniku.ForeColor = SystemColors.ControlLightLight;
            labelWitajUzytkowniku.Location = new Point(12, 19);
            labelWitajUzytkowniku.Name = "labelWitajUzytkowniku";
            labelWitajUzytkowniku.Size = new Size(58, 19);
            labelWitajUzytkowniku.TabIndex = 3;
            labelWitajUzytkowniku.Text = "label1";
            // 
            // buttonListaUprawnien
            // 
            buttonListaUprawnien.BackColor = Color.Indigo;
            buttonListaUprawnien.Cursor = Cursors.Hand;
            buttonListaUprawnien.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonListaUprawnien.ForeColor = Color.White;
            buttonListaUprawnien.Location = new Point(12, 110);
            buttonListaUprawnien.Name = "buttonListaUprawnien";
            buttonListaUprawnien.Size = new Size(171, 53);
            buttonListaUprawnien.TabIndex = 2;
            buttonListaUprawnien.Text = "Lista Uprawnien";
            buttonListaUprawnien.UseVisualStyleBackColor = false;
            // 
            // buttonLogout
            // 
            buttonLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonLogout.BackColor = Color.Indigo;
            buttonLogout.Cursor = Cursors.Hand;
            buttonLogout.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(12, 698);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(171, 53);
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
            buttonZarzadzaj.Location = new Point(12, 51);
            buttonZarzadzaj.Name = "buttonZarzadzaj";
            buttonZarzadzaj.Size = new Size(171, 53);
            buttonZarzadzaj.TabIndex = 0;
            buttonZarzadzaj.Text = "Zarządzaj Użytkownikami";
            buttonZarzadzaj.UseVisualStyleBackColor = false;
            buttonZarzadzaj.Click += buttonZarzadzaj_Click;
            // 
            // mainpanel
            // 
            mainpanel.BackColor = Color.FromArgb(24, 24, 24);
            mainpanel.Dock = DockStyle.Fill;
            mainpanel.Location = new Point(200, 0);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(1015, 763);
            mainpanel.TabIndex = 1;
            mainpanel.Paint += mainpanel_Paint;
            // 
            // FormInitial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1215, 763);
            Controls.Add(mainpanel);
            Controls.Add(panelslide);
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
    }
}