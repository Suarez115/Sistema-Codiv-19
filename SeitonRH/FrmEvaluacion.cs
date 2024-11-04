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
    public partial class FrmEvaluacion : Form
    {
        private Conexion conexion;
        private Evaluacion evaluacion;
        public string loginEvaluacion;
        private int funcion = 0;

        private string evaluacionCons = null;
        public FrmEvaluacion()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());
        }

        private void FrmEvaluacion_Load(object sender, EventArgs e)
        {

        }
        public void setFuncion(int valor)
        {
            this.funcion = valor;
        }

        public void setLoginConsultar(string valor)
        {
            this.evaluacionCons = valor;
        }

        public void mostrarFrmAgregarEvaluacion()
        {
            FrmAddEvaluacion frm = new FrmAddEvaluacion();
            frm.txtLogin.Text = this.loginEvaluacion;
            frm.ShowDialog();
            frm.Close();
        }

        private void buscarEvaluacion(string nombreEmpleado)
        {
            try
            {
                this.dtgEvaluacion.DataSource = this.conexion.BuscarEvaluacion(nombreEmpleado).Tables[0];
                this.dtgEvaluacion.AutoResizeColumns();
                this.dtgEvaluacion.ReadOnly = true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAcciones_Click(object sender, EventArgs e)
        {
            this.mostrarFrmAgregarEvaluacion();
        }

        private void dtgEvaluacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtEvaluacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.buscarEvaluacion(this.txtEvaluacion.Text.Trim().ToString());
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarEvaluacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eliminarEvaluacion();
            this.buscarEvaluacion("");
        }

        private void eliminarEvaluacion()
        {
            try
            {
                if (this.dtgEvaluacion.Rows.Count > 0)//se verifica que el datagrid tenga informacion
                {
                    if (this.dtgEvaluacion.SelectedCells.Count > 0)//se toma el login del usuario
                    {
                        string cedula = this.dtgEvaluacion.Rows[this.dtgEvaluacion.SelectedCells[0].RowIndex]
                            .Cells["cedula"].Value.ToString();

                        //se confirma si desea eliminar el usuario seleccionado
                        if (MessageBox.Show("Desea eliminar la evaluacion del empleado cédula: " + cedula, "Confirmar acción",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                        {

                            //se procede a eliminar los datos del estudiante
                            this.conexion.eliminarEvaluacion(Int32.Parse(cedula));
                            MessageBox.Show("Se ha eliminado correctamente.", "Proceso aplicado.",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void mostrarPantallaEvaluacion(int funcion)
        {
            //declara la variable de tipo formulario y se asigna una instancia
            FrmAddEvaluacion frm = new FrmAddEvaluacion();
            //mostrarFormulario


            frm.setFuncion(funcion);

            if (funcion == 1)
            {
                frm.setLoginConsultar(this.dtgEvaluacion.Rows
                    [this.dtgEvaluacion.SelectedCells[0].RowIndex]
                    .Cells["cedula"].Value.ToString());
            }

            frm.txtLogin.Text = this.loginEvaluacion;
            // frm.loginEvaluacion = this.
            frm.ShowDialog();
            //liberar los recursos d memoria
            frm.Dispose();
        }

        private void dtgEvaluacion_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //el valor 1 representa la funcion de modificar usuario
                this.mostrarPantallaEvaluacion(1);

                //actualice la lista de datos
                this.buscarEvaluacion("");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtEvaluacion_KeyPress(object sender, KeyPressEventArgs e)
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
