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
    public partial class FrmEntrevista : Form
    {
        
        private Conexion conexion;
        private Entrevista entrevista;
        public string loginEntrevista;
        private int funcion = 0;

        private string candidatoConsultar = null;
        public FrmEntrevista()
        {
            InitializeComponent();
            
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());
        }

        public void setFuncion(int valor)
        {
            this.funcion = valor;
        }

        public void setLoginConsultar(string valor)
        {
            this.candidatoConsultar = valor;
        }

        private void eliminarEntrevista()
        {
            try
            {
                if (this.dtgEntrevista.Rows.Count > 0)//se verifica que el datagrid tenga informacion
                {
                    if (this.dtgEntrevista.SelectedCells.Count > 0)//se toma el login del usuario
                    {
                        string cedula = this.dtgEntrevista.Rows[this.dtgEntrevista.SelectedCells[0].RowIndex]
                            .Cells["cedula"].Value.ToString();

                        //se confirma si desea eliminar el usuario seleccionado
                        if (MessageBox.Show("¿Desea eliminar el candidato? " + cedula, "Confirmar acción",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            //se procede a eliminar los datos del estudiante
                            this.conexion.eliminarCandidato(Int32.Parse(cedula));
                        }
                    }
                    else
                    {

                        throw new Exception("Seleccione la celda del suario que desea eliminar");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, consulte nuevamente los datos del empleado a eliminar");


                throw new Exception("Consulte los datos del usuario a eliminar");
            }
        }

        private void FrmEntrevista_Load(object sender, EventArgs e)
        {

        }

        private void buscarCandidato(string pNombreCompleto)
        {
            try
            {
                this.dtgEntrevista.DataSource = this.conexion.buscarCandidatos(pNombreCompleto).Tables[0];
                this.dtgEntrevista.AutoResizeColumns();
                this.dtgEntrevista.ReadOnly = true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void mostrarFrmAgregarEntrevista()
        {
            FrmAddEntrevista frm = new FrmAddEntrevista();
            frm.txtLogin.Text = this.loginEntrevista;
            frm.ShowDialog();
            frm.Close();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAcciones_Click(object sender, EventArgs e)
        {
            this.mostrarFrmAgregarEntrevista();
        }


        private void mostrarAddEntrevista(int funcion)
        {
            try
            {
                //variable de tipo formulario
                FrmAddEntrevista frm = new FrmAddEntrevista();
               

                frm.setFuncion(funcion);

                if (funcion == 1)
                {
                    frm.setLoginConsultar(this.dtgEntrevista.Rows
                        [this.dtgEntrevista.SelectedCells[0].RowIndex]
                        .Cells["cedula"].Value.ToString());
                }

                frm.txtLogin.Text = this.loginEntrevista;
                //mostramos la formula exclusiva de la pantalla
                frm.ShowDialog();
                
                //se liberan los recursos del form
                frm.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgEntrevista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.buscarCandidato(this.textBox1.Text.Trim().ToString());
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarEntrevistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eliminarEntrevista();
            this.buscarCandidato("");
        }

        private void dtgEntrevista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //el valor 1 representa la funcion de modificar usuario
                this.mostrarAddEntrevista(1);

                //actualice la lista de datos
                this.buscarCandidato("");
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
