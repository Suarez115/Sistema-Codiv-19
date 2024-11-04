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

using System.IO;

namespace SeitonRH
{
    public partial class FrmLogin : Form
    {
        private Conexion conexion;
        
        public string login;
        public FrmLogin()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {

                Usuarios temp = new Usuarios();

                temp.login = this.txtLogin.Text.Trim();
                temp.password = this.txtPassword.Text.Trim();
               

                if (this.intentoAutenticacion(temp))
                {
                    this.login = Convert.ToString(this.txtLogin.Text.Trim());
                    FrmPrincipal frmPrincipal = new FrmPrincipal();
                    frmPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    throw new Exception("Parece ser que este usuario no se encuentra registrado. Por favor revise los datos nuevamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Usuario o contraseña incorrectos.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        public bool intentoAutenticacion(Usuarios temp)
        {
            bool autenticado = false;

            //autenticacion con base de datos
           
            if (this.conexion.autenticacion(temp))
            {
                autenticado = true;
            }
            return autenticado;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
