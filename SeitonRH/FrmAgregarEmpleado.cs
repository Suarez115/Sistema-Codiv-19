using BLL;
using DAL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SeitonRH
{
    public partial class FrmAgregarEmpleado : Form
    {
        private Conexion conexion;
        private Empleados empleados;

        //var para controlar la logica de registrar o modificar
        //funcion 0=Registrar 1=Modificar
        private int funcion = 0;

        //variable para almacenar el login del usuario a consultar
        private string loginConsultar = null;
        public FrmAgregarEmpleado()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                this.cargarFoto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void agregarEmpleado_Click(object sender, EventArgs e)
        {
            
        }

        private void crearEmpleado()
        {
            empleados = new Empleados();
            empleados.cedula = Int32.Parse(this.txtCedula.Text.Trim().ToString());
            empleados.nombreCompleto = this.txtNombreEmpleado.Text.Trim();
            empleados.fechaNaciemiento = DateTime.Parse(this.txtFechaNac.Text.Trim().ToString());
            empleados.direccion = this.txtDireccion.Text.Trim();
            empleados.telefono = this.txtTelefono.Text.Trim();
            empleados.email = this.txtCorreo.Text.Trim();
            empleados.cargo = this.cmbCargo.Text.Trim();

            byte[] foto;
            //objeto para almacenar el string memory de la foto
            MemoryStream memoryStream = new MemoryStream();

            //guardamos el string memory de la foto
            this.picFoto.Image.Save(memoryStream, this.picFoto.Image.RawFormat);

            //extraemos el vector de byte[]
            foto = memoryStream.GetBuffer();

            //asignmos los bytes al objeto
            this.empleados.foto = foto;
        }

        private void agregarEmpleados()
        {

            this.conexion.AgregarEmpleado(empleados);

        }//fin de metodo agregar empleados
        private void cargarFoto()
        {
            try
            {
                //instancia para mostrar la ventana de dialogo de busqueda de archivos
                OpenFileDialog openFileDialog = new OpenFileDialog();

                //mostrar la ventana de dialogo y preguntamos si el usuario clic en ok
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //asigna la foto que selecciono el usuario al pictureBox
                    this.picFoto.ImageLocation = openFileDialog.FileName;
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
                if (this.txtCedula.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo cédula esté vacío");
                }
                if (this.txtNombreEmpleado.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo nombre esté vacío");
                }
                if (this.txtFechaNac.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo fecha esté vacío");
                }
                if (this.txtDireccion.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo dirección esté vacío");
                }
                if (this.txtTelefono.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo teléfono esté vacío");
                }
                if (this.txtCorreo.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo correo electrónico esté vacío");
                }
                if (this.cmbCargo.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo cargo esté vacío");
                }
                //if (this.picFoto.Text.Trim().Equals(0))
                //{
                //    throw new Exception("No se permite que el campo foto esté vacío");
                //}

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de validacion de campos
        public void setFuncion(int valor)
        {
            this.funcion = valor;
        }
        public void setLoginConsultar(string valor)
        {
            this.loginConsultar = valor;
        }

        private void FrmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            try
            {

                //logica de negocio
                //cuando la 
                if (this.funcion == 1)
                {
                    // el valor de 1 representa la funcion modificar
                    this.btnAcciones.Text = "&Modificar";

                    //mostrar el login del usuario a modificar
                    this.txtCedula.Text = this.loginConsultar;

                    //como estamos modificando el login debe ser solo lectura
                    this.txtCedula.ReadOnly = true;

                    //se llama al metodo consultar para mostrar los datos del usuario a nivel de frontend
                    this.consultarEmpleado();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void consultarEmpleado()
        {
            try
            {
                //utilizamos la variable usuario para recibir el obj que devuelve el metodo
                //consultar este recibe como parametro el login a consultar
                this.empleados = this.conexion.consultarEmpleado(this.loginConsultar);
                //se preguna si el objeto tiene datos
                if (this.empleados != null)
                {
                    //se rellena el frontend con los datos del objeto
                    this.txtCedula.Text = this.empleados.cedula.ToString();
                    this.txtNombreEmpleado.Text = this.empleados.nombreCompleto;
                    this.txtFechaNac.Text = this.empleados.fechaNaciemiento.ToString();
                    this.txtDireccion.Text = this.empleados.direccion;
                    this.txtCorreo.Text = this.empleados.email;
                    this.txtTelefono.Text = this.empleados.telefono;
                    this.cmbCargo.Text = this.empleados.cargo;

                    //preguntamos si el user tiene fotos
                    if (this.empleados.foto != null)
                    {
                        //crea una var memory stream para almacenar los bytes de la foto
                        MemoryStream memoryStream = new MemoryStream
                            (this.empleados.foto);

                        //se crea la foto con la memoria y se asiga al picture box
                        this.picFoto.Image =
                            Image.FromStream(memoryStream);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void modificarEmpleado()
        {
            try
            {
                //metodo modificar usuario de la clase conexion
                this.conexion.modificarEmpleado(this.empleados);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void txtFechaNac_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fecha = dateTimePicker1.Value;

            this.txtFechaNac.Text = fecha.ToString();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.validarCampos();
                //utilizamos el metodo encargado de crear la instancia del obj usuario
                this.crearEmpleado();

                if (this.funcion == 0)
                {
                    this.agregarEmpleados();
                    MessageBox.Show("El empleado ha sido registrado correctamente.", "Proceso aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea aplicar los cambios?", "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.modificarEmpleado();
                        //aqui se llama al metodo encargado de registrar el usuario a la base de datos
                        MessageBox.Show("Proceso de modificar.", "El proceso ha sido aplicado correctamente",
                            MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }


                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ha ocurrido un error. Revise los datos.",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (Char.IsLetter(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsSeparator(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //    MessageBox.Show("Solo se permiten letras");
            //}
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

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
