using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaComun;

using DAL;
using BLL;

namespace SeitonRH
{
    public partial class FrmAddEntrevista : Form
    {
        private Conexion conexion;
        private Entrevista entrevista;
        public string loginEntrevista;
        private int funcion = 0;

        private string candidatoConsultar = null;
        public FrmAddEntrevista()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());

        }

        private void btnAcciones_Click(object sender, EventArgs e)
        {
            try
            {
                this.validarCampos();
                //utilizamos el metodo encargado de crear la instancia del obj usuario
                this.crearCandidato();
               

                if (this.funcion == 0)
                {
                    this.agregarEntrevista();
                    MessageBox.Show("La entrevista fue registrada exitosamente.", "Proceso aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Desea aplicar los cambios", "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.modificarEntrevista();
                        
                        
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

        private void modificarEntrevista()
        {
            try
            {
                //metodo modificar usuario de la clase conexion
                this.conexion.modificarEntrevista(this.entrevista);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void agregarEntrevista()
        {

            this.conexion.AgregarEntrevista(entrevista);
            //  MessageBox.Show("La entrevista fue agregada de manera exitosa.");

        }//fin de metodo agregar entrevista

        private void validarCampos()
        {
            try
            {
                if (this.txtNombreCandidato.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo nombre esté vacío");
                }
                if (this.txtCedula.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo cédula esté vacío");
                }
                if (this.txtTelefono.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo teléfono esté vacío");
                }
                if (this.txtCorreo.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo correo electrónico esté vacío");
                }
                if (this.txtDireccion.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo dirección esté vacío");
                }
                if (this.cmbPresentacion.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo presentación esté vacío");
                }

                if (this.cmbBlandas.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo habilidades blandas esté vacío");
                }
                if (this.cmbComportamiento.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo comportamiento esté vacío");
                }
                if (this.cmbSituacionales.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo habilidades situacionales esté vacío");
                }
                if (this.cmbDuras.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo habilidades duras esté vacío");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de validacion de campos

        private void consultarCandidato()
        {
            try
            {
                //utilizamos la variable usuario para recibir el obj que devuelve el metodo
                //consultar este recibe como parametro el login a consultar
                this.entrevista = this.conexion.consultarCandidato(Int32.Parse(this.candidatoConsultar));

                //se preguna si el objeto tiene datos
                if (this.entrevista != null)
                {
                    //se rellena el frontend con los datos del objeto
                    this.txtNombreCandidato.Text = this.entrevista.nombreCompleto;
                    this.txtCedula.Text = this.entrevista.cedula.ToString();
                    this.txtTelefono.Text = this.entrevista.telefono;
                    this.txtCorreo.Text = this.entrevista.email;
                    this.txtDireccion.Text = this.entrevista.direccion;
                    this.cmbPresentacion.Text = this.entrevista.rubroPresentacion.ToString();
                    this.cmbBlandas.Text = this.entrevista.rubroHabilidadesBlandas.ToString();
                    this.cmbComportamiento.Text = this.entrevista.rubroHabilidadesComportamiento.ToString();
                    this.cmbSituacionales.Text = this.entrevista.rubroPresentacion.ToString();
                    this.cmbDuras.Text = this.entrevista.rubroHabilidadesDuras.ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void crearCandidato()
        {
            int presentacion = 0;
            int blandas = 0;
            int comportamiento = 0;
            int situacional = 0;
            int duras = 0;
            int total = 0;
            entrevista = new Entrevista();

            entrevista.login = this.txtLogin.Text;
            entrevista.nombreCompleto = this.txtNombreCandidato.Text.Trim();
            entrevista.cedula = Int32.Parse(this.txtCedula.Text.Trim().ToString());
            entrevista.telefono = this.txtTelefono.Text.Trim();
            entrevista.email = this.txtCorreo.Text.Trim();
            entrevista.direccion = this.txtDireccion.Text.Trim();

            presentacion = entrevista.rubroPresentacion = Int32.Parse(this.cmbPresentacion.Text.Trim().ToString());
            blandas = entrevista.rubroHabilidadesBlandas = Int32.Parse(this.cmbBlandas.Text.Trim().ToString());
            comportamiento = entrevista.rubroHabilidadesComportamiento = Int32.Parse(this.cmbComportamiento.Text.Trim().ToString());
            situacional = entrevista.rubroHabilidadesSituacionales = Int32.Parse(this.cmbSituacionales.Text.Trim().ToString());
            duras = entrevista.rubroHabilidadesDuras = Int32.Parse(this.cmbDuras.Text.Trim().ToString());
            total = (presentacion + blandas + comportamiento + situacional + duras);
            entrevista.calificacionFinal = total;
        }


        public void setLoginConsultar(string valor)
        {
            this.candidatoConsultar = valor;
        }

        public void setFuncion(int valor)
        {
            this.funcion = valor;
        }


        private void AddEntrevista_Load(object sender, EventArgs e)
        {
            this.txtLogin.Text = UserLogin.password;

            try
            {


                if (this.funcion == 1)
                {
                    // el valor de 1 representa la funcion modificar
                    this.btnAcciones.Text = "&Modificar";

                    //mostrar el login del usuario a modificar
                    this.txtCedula.Text = this.candidatoConsultar;

                    //como estamos modificando el login debe ser solo lectura
                    this.txtCedula.ReadOnly = true;

                    //se llama al metodo consultar para mostrar los datos del usuario a nivel de frontend
                    this.consultarCandidato();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtNombreCandidato_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
