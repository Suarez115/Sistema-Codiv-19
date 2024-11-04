using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BLL;
using DAL;

namespace SeitonRH
{
    public partial class FrmAddUser : Form
    {
        private Conexion conexion;
        private Usuarios usuarios;

        //var para controlar la logica de registrar o modificar
        //funcion 0=Registrar 1=Modificar
        private int funcion = 0;

        //variable para almacenar el login del usuario a consultar
        private string loginConsultar = null;
        public FrmAddUser()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());
        }

        private void agregarEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void crearUsuario()
        {
            usuarios = new Usuarios();
            usuarios.idEmpleado = Int32.Parse(this.txtIdEmp.Text.Trim().ToString());
            usuarios.login = this.txtLogin.Text.Trim();
            usuarios.password = this.txtPassword.Text.Trim();
            usuarios.email = this.txtCorreo.Text.Trim();
            usuarios.rol = this.txtRol.Text.Trim();

            if (!this.usuarios.ConfirmarPassword(this.txtConfirm.Text.Trim()))
            {
                throw new Exception("La confirmación de la contraseña ha sido incorrecta. Por favor intentar nuevamente.");
            }
        }



        private void agregarUsuarios()
        {
            //hacer validacion de idEmpleado con el idEmpleado-Usurios
            this.conexion.AgregarUsuario(usuarios);

        }

        private void validarCampos()
        {
            try
            {
                if (this.txtIdEmp.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo id empleado esté vacío");
                }
                if (this.txtLogin.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo nombre de usuario esté vacío");
                }
                if (this.txtPassword.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo contraseña esté vacío");
                }
                if (this.txtConfirm.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo confirmar contraseña esté vacío");
                }
                if (this.txtCorreo.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo correo electrónico esté vacío");
                }
                if (this.txtRol.Text.Trim().Equals(""))
                {
                    throw new Exception("No se permite que el campo rol esté vacío");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void mostrarFrmconsultarEmp()
        {
            FrmConsularEmpleados frm = new FrmConsularEmpleados();
            frm.ShowDialog(this);
            frm.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
        }

        private void FrmAddUser_Load(object sender, EventArgs e)
        {
            try
            {

                if (this.funcion == 1)
                {
                    // el valor de 1 representa la funcion modificar
                    this.btnAcciones.Text = "&Modificar";
                    this.iconButton1.Visible = false;

                    //mostrar el login del usuario a modificar
                    this.txtLogin.Text = this.loginConsultar;

                    //como estamos modificando el login debe ser solo lectura
                    this.txtIdEmp.ReadOnly = true;

                    //se llama al metodo consultar para mostrar los datos del usuario a nivel de frontend
                    this.consultarUsuario();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error. A la hora de leer los datos.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void consultarUsuario()
        {
            try
            {
                //utilizamos la variable usuario para recibir el obj que devuelve el metodo
                //consultar este recibe como parametro el login a consultar
                this.usuarios = this.conexion.consultarUsuario(this.loginConsultar);

                //se preguna si el objeto tiene datos
                if (this.usuarios != null)
                {
                    //se rellena el frontend con los datos del objeto
                    this.txtIdEmp.Text = this.usuarios.idEmpleado.ToString();
                    this.txtLogin.Text = this.usuarios.login;
                    this.txtCorreo.Text = this.usuarios.email;
                    this.txtRol.Text = this.usuarios.rol;

                }
            }
            catch (Exception)  
            {

                throw;
            }
        }

        private void modificarUsuario()
        {
            try
            {
                //metodo modificar usuario de la clase conexion
                this.conexion.modificarUsuario(this.usuarios);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void setFuncion(int valor)
        {
            this.funcion = valor;
        }

        public void setLoginConsultar(string valor)
        {
            this.loginConsultar = valor;
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            
        }//metodo boton agregar

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmAddUser_Load_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAcciones_Click(object sender, EventArgs e)
        {
            try
            {
                this.validarCampos();
                //utilizamos el metodo encargado de crear la instancia del obj usuario
                this.crearUsuario();

                if (this.funcion == 0)
                {
                    this.agregarUsuarios();
                    MessageBox.Show("El usuario ha sido registrado exitosamente.", "Proceso aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Desea aplicar los cambios", "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.modificarUsuario();
                        //aqui se llama al metodo encargado de registrar el usuario a la base de datos
                        MessageBox.Show("Proceso de modificar.", "Proceso aplicado",
                            MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error. Revise los datos.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            this.mostrarFrmconsultarEmp();
        }

        private void txtLogin_KeyPress_1(object sender, KeyPressEventArgs e)
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