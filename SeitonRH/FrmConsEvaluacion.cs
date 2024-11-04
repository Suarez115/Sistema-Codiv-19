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
    public partial class FrmConsEvaluacion : Form
    {
        Conexion conexion;
        public FrmConsEvaluacion()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgBusqueda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmAddEvaluacion frmAddEvaluacion = this.Owner as FrmAddEvaluacion;
            frmAddEvaluacion.txtNombreEmpleado.Text = this.dtgBusqueda.CurrentRow.Cells[2].Value.ToString();
            frmAddEvaluacion.txtCedula.Text = this.dtgBusqueda.CurrentRow.Cells[1].Value.ToString();

            this.Close();
        }

        private void txtNombreCons_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.BuscarIdEmpleado(this.txtNombreCons.Text.Trim().ToString());
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
                this.dtgBusqueda.DataSource = this.conexion.BuscarIdEmpleadoFrmUsuario(pNombreCompleto).Tables[0];
                this.dtgBusqueda.AutoResizeColumns();
                this.dtgBusqueda.ReadOnly = true;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
