using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace SeitonRH
{
    public partial class FrmConsularEmpleados : Form
    {
        private Conexion conexion;

        public FrmConsularEmpleados()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.BuscarIdEmpleado(this.textBox1.Text.Trim().ToString());
            }
            catch (Exception exc)
            {
               
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BuscarIdEmpleado(string pNombreCompleto)
        {
            try
            {
                this.dataGridView1.DataSource = this.conexion.BuscarIdEmpleadoFrmUsuario(pNombreCompleto).Tables[0];
                this.dataGridView1.AutoResizeColumns();
                this.dataGridView1.ReadOnly = true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmAddUser frmAddUser = this.Owner as FrmAddUser;
            frmAddUser.txtIdEmp.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frmAddUser.txtCorreo.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();

            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConsularEmpleados_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
