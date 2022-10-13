using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_DB
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        public void capturardatos(string datos)
        {
            label1.Text = datos;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
