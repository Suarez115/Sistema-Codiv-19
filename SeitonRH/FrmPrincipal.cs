using CapaComun;
using SeitonRH.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace SeitonRH
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            this.notifyIcon1.ShowBalloonTip(25);
            //  this.mostrarPantallaLogin();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.ShowBalloonTip(25);
            this.label5.Text = UserLogin.login;


            if (UserLogin.rol == Cargos.Empleado)
            {
                iconButtonEmpleados.Enabled = false;
                iconButtonEvaluacion.Enabled = false;
                iconButtonUsuarios.Enabled = false;
                iconButtonAsistencia.Enabled = false;
                iconButtonEntrevista.Enabled = false;
            }

            if (UserLogin.foto != null)
            {
                //crea una var memory stream para almacenar los bytes de la foto
                MemoryStream memoryStream = new MemoryStream
                 (UserLogin.foto);

                //se crea la foto con la memoria y se asiga al picture box
                this.pictureBox4.Image =
               Image.FromStream(memoryStream);
            }


        }

        public static string ObtenerStringConexion()
        {
            return Settings.Default.stringConexion;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        public void mostrarFrmEmpleados()
        {
            FrmEmpleados frm = new FrmEmpleados();
            frm.ShowDialog();
            frm.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        public void mostrarFrmUsuarios()
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.ShowDialog();
            frm.Close();
        }

        private void mostrarPantallaLogin()
        {
            try
            {
                //variable de tipo formulario
                FrmLogin frm = new FrmLogin();
                this.lbUser.Text = frm.login;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            //this.mostrarFrmUsuarios();
            this.openChildForm(new FrmUsuarios());

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //this.mostrarFrmEmpleados();
            this.openChildForm(new FrmEmpleados());
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            //this.mostrarFrmEntrevistas();
            this.openChildForm(new FrmEntrevista());

        }

        public void mostrarFrmEntrevistas()
        {
            FrmEntrevista frm = new FrmEntrevista();
            frm.loginEntrevista = this.lbUser.Text;

            frm.ShowDialog();
            frm.Close();
        }

        public void mostrarFrmEvaluacion()
        {
            FrmEvaluacion frm = new FrmEvaluacion();
            frm.loginEvaluacion = this.lbUser.Text;

            frm.ShowDialog();
            frm.Close();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            this.Close();
            this.mostrarPantallaLogin();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            //this.mostrarFrmEvaluacion();
            this.openChildForm(new FrmEvaluacion());

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

    }
}
