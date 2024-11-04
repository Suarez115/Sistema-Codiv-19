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
using CapaComun;
namespace SeitonRH
{
    public partial class FrmAddEvaluacion : Form
    {
        private Conexion conexion;
        private Evaluacion evaluacion;
        public string loginEvaluacion;
        private int funcion = 0;

        private string evaluacionCons = null;
        public FrmAddEvaluacion()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());

        }

        private void FrmAddEvaluacion_Load(object sender, EventArgs e)
        {
            this.txtLogin.Text = UserLogin.password;
            try
            {


                if (this.funcion == 1)
                {
                    // el valor de 1 representa la funcion modificar
                    this.btnAcciones.Text = "&Modificar";

                    //mostrar el login del usuario a modificar
                    this.txtCedula.Text = this.evaluacionCons;

                    //como estamos modificando el login debe ser solo lectura
                    this.txtCedula.ReadOnly = true;

                    //se llama al metodo consultar para mostrar los datos del usuario a nivel de frontend
                    this.consultarEvaluacion();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void consultarEvaluacion()
        {
            try
            {
                //utilizamos la variable usuario para recibir el obj que devuelve el metodo
                //consultar este recibe como parametro el login a consultar
                this.evaluacion = this.conexion.consultarEvaluacion(Int32.Parse(this.evaluacionCons));

                //se preguna si el objeto tiene datos
                if (this.evaluacion != null)
                {
                    //se rellena el frontend con los datos del objeto
                    this.txtNombreEmpleado.Text = this.evaluacion.nombreEmpleado;
                    this.txtCedula.Text = this.evaluacion.cedula.ToString();
                    this.cmbPuntualidad.Text = this.evaluacion.puntualidad.ToString();
                    this.cmbLogros.Text = this.evaluacion.logros.ToString();
                    this.cmbTrabajoEnEquipo.Text = this.evaluacion.trabajoEnEquipo.ToString();
                    this.cmbDesIndividual.Text = this.evaluacion.desempenoIndividual.ToString();
                    this.cmbTecnicas.Text = this.evaluacion.habilidadesTecnicas.ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void validarCampos()
        {
            try
            {
                if (this.txtNombreEmpleado.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo nombre esté vacío");
                }
                if (this.txtCedula.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo cédula esté vacío");
                }
                if (this.cmbPuntualidad.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo puntualidad esté vacío");
                }
                if (this.cmbLogros.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo logros esté vacío");
                }
                if (this.cmbTrabajoEnEquipo.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo trabajo en equipo esté vacío");
                }
                if (this.cmbDesIndividual.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo desempeño individual esté vacío");
                }
                if (this.cmbTecnicas.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo habilidades técnicas esté vacío");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de validacion de campos

        private void crearEvaluacion()
        {
            int puntualidad = 0;
            int logros = 0;
            int trabajoEnEq = 0;
            int desempeno = 0;
            int habTec = 0;
            int total = 0;
            evaluacion = new Evaluacion();

            evaluacion.login = this.txtLogin.Text;
            evaluacion.nombreEmpleado = this.txtNombreEmpleado.Text.Trim();
            evaluacion.cedula = Int32.Parse(this.txtCedula.Text.Trim().ToString());
            
            puntualidad = evaluacion.puntualidad = Int32.Parse(this.cmbPuntualidad.Text.Trim().ToString());
            logros = evaluacion.logros = Int32.Parse(this.cmbLogros.Text.Trim().ToString());
            trabajoEnEq = evaluacion.trabajoEnEquipo = Int32.Parse(this.cmbTrabajoEnEquipo.Text.Trim().ToString());
            desempeno = evaluacion.desempenoIndividual = Int32.Parse(this.cmbDesIndividual.Text.Trim().ToString());
            habTec = evaluacion.habilidadesTecnicas = Int32.Parse(this.cmbTecnicas.Text.Trim().ToString());
            total = (puntualidad + logros + trabajoEnEq + desempeno + habTec);
            evaluacion.calificacionFinal = total;
        }

        public void setLoginConsultar(string valor)
        {
            this.evaluacionCons = valor;
        }

        public void setFuncion(int valor)
        {
            this.funcion = valor;
        }
        private void agregarEvaluacion()
        {

            this.conexion.agregarEvaluacion(evaluacion);
            MessageBox.Show("El empleado fue agregado correctamente");

        }//fin de metodo agregar empleados

        private void modificarEvaluacion()
        {
            try
            {
                //metodo modificar usuario de la clase conexion
                this.conexion.modificarEvaluacion(this.evaluacion);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnAcciones_Click(object sender, EventArgs e)
        {
            try
            {
                this.validarCampos();
                //utilizamos el metodo encargado de crear la instancia del obj usuario
                this.crearEvaluacion();

                if (this.funcion == 0)
                {
                    this.agregarEvaluacion();
                    MessageBox.Show("La evaluación ha sido registrada correctamente.", "Proceso aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Desea aplicar los cambios", "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.modificarEvaluacion();
                        //aqui se llama al metodo encargado de registrar el usuario a la base de datos
                        MessageBox.Show("Proceso de modificar.", "Proceso aplicado",
                            MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }



                }


                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombreEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreEmpleado_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
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
                MessageBox.Show("Solo se permiten números");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.mostrarFrmconsultarEmp();
        }

        public void mostrarFrmconsultarEmp()
        {
            FrmConsEvaluacion frm = new FrmConsEvaluacion();
            frm.ShowDialog(this);
            frm.Close();
        }
    }
}
