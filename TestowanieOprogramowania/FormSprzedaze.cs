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
    public partial class FormSprzedaze : Form
    {
        public FormSprzedaze()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormRejestrujSprzedaz formRejestrujSprzedaz = new FormRejestrujSprzedaz();
            formRejestrujSprzedaz.Show();
        }
    }
}
