using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestowanieOprogramowania
{
    public partial class FromResetPas : Form
    {
        public FromResetPas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string mail = textBoxMail.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Proszę wprowadzić nazwę użytkownika.");
                return;
            }

            var odzyskajhaslo = new OdzyskiwanieHasla();
            odzyskajhaslo.ResetPassword(username, mail, (message) =>
            {
                return MessageBox.Show(message, "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                
            });
            
        }
    }
}
