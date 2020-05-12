using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial_2.Model;

namespace Parcial_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pbAdvertencia.Visible = false;
            lblNombre.Visible = false;
            lblNoDui.Visible = false;
            lblSiDui.Visible = false;
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Loguin log = new Loguin();
            log.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (gobEntities bd = new gobEntities())
            {


                var buscaru = from b in bd.usuarios
                             where b.DUI == txtDui.Text
                             select b;

                if (buscaru.Count() > 0)
                {

                usuario pr = new usuario();
                string buscar = txtDui.Text;
                pr = bd.usuarios.Where(idBuscar => idBuscar.DUI == buscar).First();
                lblNombre.Visible = true;
                lblNombre.Text = pr.nombre;
                lblSiDui.Visible = true;
                pbAdvertencia.Visible = false;
                lblNoDui.Visible = false;

                }
                else
                {
                    pbAdvertencia.Visible = true;
                    lblNoDui.Visible = true;
                    lblSiDui.Visible = false;
                    lblNombre.Visible = false;
                }
            }
        }
    }
}
