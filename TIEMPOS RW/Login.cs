using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIEMPOS_RW
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "172106")
            {
                ConexServ frm = new ConexServ();


                frm.Show(this);
                this.Hide();

            }
            else {

                MessageBox.Show("Verifica tu Contraseña", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();


            frm.Show(this);
            this.Hide();

        }
    }
}
