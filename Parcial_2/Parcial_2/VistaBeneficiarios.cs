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
    public partial class VistaBeneficiarios : Form
    {
        public VistaBeneficiarios()
        {
            InitializeComponent();
            txtId.Enabled = false;
            bloquear();
        }

        void limpiar()
        {
            txtDui.Text = "";
            txtId.Text = "";
            txtNombre.Text = "";
        }

        void bloquear()
        {
            txtDui.Enabled = false;
            txtId.Enabled = false;
            txtNombre.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            rbNuevo.Checked = false;
            rbModificar.Checked = false;
        }

        void cargar()
        {
            using (gobEntities bd = new gobEntities())
            {
                var lista = from b in bd.usuarios

                            select new
                            {
                                ID = b.id,
                                NOMBRE = b.nombre,
                                DUI = b.DUI
                            };

                dgvBeneficiarios.DataSource = lista.ToList();
            }

        }

        private void VistaBeneficiarios_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dgvBeneficiarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (gobEntities bd = new gobEntities())
            {
                usuario us = new usuario();
                string id = dgvBeneficiarios.CurrentRow.Cells[0].Value.ToString();
                int id2 = int.Parse(id);
                us = bd.usuarios.Where(verificarId => verificarId.id == id2).First();
                txtId.Text = dgvBeneficiarios.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = us.nombre;
                txtDui.Text = us.DUI;
                bloquear();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDui.Text != "" && txtNombre.Text != "" )
            {
                using (gobEntities bd = new gobEntities())
                {
                    usuario pro = new usuario();
                    pro.DUI = txtDui.Text;
                    pro.nombre = txtNombre.Text;
                    bd.usuarios.Add(pro);
                    bd.SaveChanges();

                }
            }
            else
            {
                MessageBox.Show("No se aceptan valores vacios");
            }

            limpiar();
            bloquear();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtDui.Text != "" && txtNombre.Text != "")
            {
                using (gobEntities bd = new gobEntities())
                {
                    usuario pro = new usuario();
                    string id = dgvBeneficiarios.CurrentRow.Cells[0].Value.ToString();
                    int id2 = int.Parse(id);
                    pro = bd.usuarios.Where(verificarId => verificarId.id == id2).First();
                    bd.Entry(pro).State = System.Data.Entity.EntityState.Deleted;
                    bd.SaveChanges();

                }
            }
            else
            {
                MessageBox.Show("No se eliminan valores vacios");
            }

            limpiar();
            bloquear();
            cargar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtDui.Text != "" && txtNombre.Text != "")
            {
                using (gobEntities bd = new gobEntities())
                {
                    usuario pro = new usuario();
                    string id = dgvBeneficiarios.CurrentRow.Cells[0].Value.ToString();
                    int id2 = int.Parse(id);
                    pro = bd.usuarios.Where(verificarId => verificarId.id == id2).First();
                    pro.DUI = txtDui.Text;
                    pro.nombre = txtNombre.Text;
                    bd.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();

                   
                }
            }
            else
            {
                MessageBox.Show("No se eliminan valores vacios");
            }

            limpiar();
            bloquear();
            cargar();
        }

        private void rbNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNuevo.Checked == true && rbModificar.Checked == true)
            {
                rbModificar.Checked = false;
                txtNombre.Enabled = true;
                txtDui.Enabled = true;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = true;
                btnActualizar.Enabled = false;
               

                limpiar();
                

            }
            else if (rbNuevo.Checked == true && rbModificar.Checked == false)
            {
                txtNombre.Enabled = true;
                txtDui.Enabled = true;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = true;
                btnActualizar.Enabled = false;

               
                limpiar();
                
            }
        }

        private void rbModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbModificar.Checked == true && rbNuevo.Checked == true)
            {
                rbNuevo.Checked = false;
                txtNombre.Enabled = true;
                txtDui.Enabled = true;
                btnEliminar.Enabled = true;
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;

                
                

            }
            else if (rbModificar.Checked == true && rbNuevo.Checked == false)
            {
                txtNombre.Enabled = true;
                txtDui.Enabled = true;
                btnEliminar.Enabled = true;
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;

            }
        }
    }
    
    
}
