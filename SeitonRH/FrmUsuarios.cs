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
using BLL;

namespace SeitonRH
{
    public partial class FrmUsuarios : Form
    {
        private Conexion conexion;
        public FrmUsuarios()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());

        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            this.mostrarFrmAddUser();
        }
        public void mostrarFrmAddUser()
        {
            FrmAddUser frm = new FrmAddUser();
            frm.ShowDialog();
            frm.Close();
        }

        public void mostrarPantallaUser(int funcion)
        {
            //declara la variable de tipo formulario y se asigna una instancia
            FrmAddUser frm = new FrmAddUser();
            //mostrarFormulario


            frm.setFuncion(funcion);

            if (funcion == 1)
            {
                frm.setLoginConsultar(this.dtgDatosUsuario.Rows
                    [this.dtgDatosUsuario.SelectedCells[0].RowIndex]
                    .Cells["login"].Value.ToString());
            }

            frm.ShowDialog();
            //liberar los recursos d memoria
            frm.Dispose();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.BuscarUsuarioPorNombre(this.textBox1.Text.Trim());
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarUsuarioPorNombre(string pLogin)
        {
            try
            {
                this.dtgDatosUsuario.DataSource = this.conexion.BuscarUsuarios(pLogin).Tables[0];
                this.dtgDatosUsuario.AutoResizeColumns();
                this.dtgDatosUsuario.ReadOnly = true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dtgDatosUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eliminarUsuario();
            this.BuscarUsuarioPorNombre("");
        }

        private void eliminarUsuario()
        {
            try
            {
                if (this.dtgDatosUsuario.Rows.Count > 0)//se verifica que el datagrid tenga informacion
                {
                    if (this.dtgDatosUsuario.SelectedCells.Count > 0)//se toma el login del usuario
                    {
                        string login = this.dtgDatosUsuario.Rows[this.dtgDatosUsuario.SelectedCells[0].RowIndex]
                            .Cells["login"].Value.ToString();

                        //se confirma si desea eliminar el usuario seleccionado
                        if (MessageBox.Show("Desea eliminar el usuario " + login, "Confirmar acción",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            //se procede a eliminar los datos del usuario
                            this.conexion.eliminarUsuario((login));
                        }
                    }
                    else
                    {
                        throw new Exception("Seleccione la celda del usuario que desea eliminar");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario no se ha podido eliminar. Por favor, consulte nuevamente los datos del usuario a eliminar");
                //throw new Exception("Consulte los datos del usuario a eliminar");
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dtgDatosUsuario_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //el valor 1 representa la funcion de modificar usuario
                this.mostrarPantallaUser(1);

                //actualice la lista de datos
                this.BuscarUsuarioPorNombre("");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
    }
}
