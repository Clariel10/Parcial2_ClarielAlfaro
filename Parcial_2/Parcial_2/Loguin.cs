using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class Loguin : Form
    {
        public Loguin()
        {
            InitializeComponent();
        }

        private void Loguin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "master" && txtContra.Text == "123")
            {
                VistaBeneficiarios vb = new VistaBeneficiarios();
                vb.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos no Existentes");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }
    }
}
