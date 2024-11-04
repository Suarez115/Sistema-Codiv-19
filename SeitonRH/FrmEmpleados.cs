using DAL;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SeitonRH
{
    public partial class FrmEmpleados : Form
    {
        private Conexion conexion;
        public FrmEmpleados()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.mostrarFrmAgregarEmpleado();
        }

        public void mostrarFrmAgregarEmpleado()
        {
            FrmAgregarEmpleado frm = new FrmAgregarEmpleado();
            frm.ShowDialog();
            frm.Close();
        }
        private void BuscarEmpleado(string pNombreCompleto)
        {
            try
            {
                this.dataGridView1.DataSource = this.conexion.BuscarEmpleados(pNombreCompleto).Tables[0];
                this.dataGridView1.AutoResizeColumns();
                this.dataGridView1.ReadOnly = true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.BuscarEmpleado(this.textBox1.Text.Trim().ToString());
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            this.mostrarFrmAgregarEmpleado();

        }

       
        private void EliminartoolStrip_Click(object sender, EventArgs e)
        {
        }
        private void eliminarEmpleado()
        {
            try
            {
                if (this.dataGridView1.Rows.Count > 0)//se verifica que el datagrid tenga informacion
                {
                    if (this.dataGridView1.SelectedCells.Count > 0)//se toma el login del usuario
                    {
                        string idEmpleado = this.dataGridView1.Rows[this.dataGridView1.SelectedCells[0].RowIndex].Cells["idEmpleado"].Value.ToString();

                        //se confirma si desea eliminar el usuario seleccionado
                        if (MessageBox.Show("Desea eliminar el empleado " + idEmpleado, "Confirmar acción",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                
                        {

                            //se procede a eliminar los datos del estudiante
                            this.conexion.eliminarEmpleado(Int32.Parse(idEmpleado));
                            
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


                throw new Exception("Consulte los datos del empleado a eliminar");
            }
        }

        private void contextMenuStripEliminar_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eliminarEmpleado();
            this.BuscarEmpleado("");
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void mostrarPantallaEmpleados(int funcion)
        {
            //declara la variable de tipo formulario y se asigna una instancia
            FrmAgregarEmpleado frm = new FrmAgregarEmpleado();
            //mostrarFormulario


            frm.setFuncion(funcion);

            if (funcion == 1)
            {
                frm.setLoginConsultar(this.dataGridView1.Rows
                    [this.dataGridView1.SelectedCells[0].RowIndex]
                    .Cells["idEmpleado"].Value.ToString());
            }

            frm.ShowDialog();
            //liberar los recursos d memoria
            frm.Dispose();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //el valor 1 representa la funcion de modificar usuario
                this.mostrarPantallaEmpleados(1);

                //actualice la lista de datos
                this.BuscarEmpleado("");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
