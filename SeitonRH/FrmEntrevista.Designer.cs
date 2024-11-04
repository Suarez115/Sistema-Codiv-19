
namespace SeitonRH
{
    partial class FrmEntrevista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgEntrevista = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarEntrevistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdEmpleado = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAcciones = new FontAwesome.Sharp.IconButton();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEntrevista)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.txtIdEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAcciones);
            this.groupBox3.Controls.Add(this.dtgEntrevista);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(180, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(756, 589);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resultados de Entrevistas";
            // 
            // dtgEntrevista
            // 
            this.dtgEntrevista.AllowUserToAddRows = false;
            this.dtgEntrevista.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgEntrevista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEntrevista.ContextMenuStrip = this.contextMenuStrip1;
            this.dtgEntrevista.Location = new System.Drawing.Point(23, 87);
            this.dtgEntrevista.Name = "dtgEntrevista";
            this.dtgEntrevista.RowHeadersWidth = 51;
            this.dtgEntrevista.RowTemplate.Height = 24;
            this.dtgEntrevista.Size = new System.Drawing.Size(710, 395);
            this.dtgEntrevista.TabIndex = 1;
            this.dtgEntrevista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEntrevista_CellContentClick);
            this.dtgEntrevista.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEntrevista_CellContentDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarEntrevistaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 28);
            // 
            // eliminarEntrevistaToolStripMenuItem
            // 
            this.eliminarEntrevistaToolStripMenuItem.Name = "eliminarEntrevistaToolStripMenuItem";
            this.eliminarEntrevistaToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.eliminarEntrevistaToolStripMenuItem.Text = "Eliminar Entrevista";
            this.eliminarEntrevistaToolStripMenuItem.Click += new System.EventHandler(this.eliminarEntrevistaToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(710, 31);
            this.textBox1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBox1, "Ingrese el nombre del candidato que desea visualizar");
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtIdEmpleado);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 846);
            this.panel1.TabIndex = 4;
            // 
            // txtIdEmpleado
            // 
            this.txtIdEmpleado.BackgroundImage = global::SeitonRH.Properties.Resources.Entrevistas;
            this.txtIdEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtIdEmpleado.Controls.Add(this.pictureBox2);
            this.txtIdEmpleado.Location = new System.Drawing.Point(180, 3);
            this.txtIdEmpleado.Name = "txtIdEmpleado";
            this.txtIdEmpleado.Size = new System.Drawing.Size(765, 233);
            this.txtIdEmpleado.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SeitonRH.Properties.Resources.cerrarcuad;
            this.pictureBox2.Location = new System.Drawing.Point(715, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "Haga clic aquí para cerrar el módulo de evaluación");
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnAcciones
            // 
            this.btnAcciones.FlatAppearance.BorderSize = 0;
            this.btnAcciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcciones.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcciones.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnAcciones.IconChar = FontAwesome.Sharp.IconChar.PenAlt;
            this.btnAcciones.IconColor = System.Drawing.Color.CadetBlue;
            this.btnAcciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAcciones.IconSize = 50;
            this.btnAcciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcciones.Location = new System.Drawing.Point(548, 499);
            this.btnAcciones.Name = "btnAcciones";
            this.btnAcciones.Size = new System.Drawing.Size(185, 65);
            this.btnAcciones.TabIndex = 31;
            this.btnAcciones.Text = "Realizar\r\nEntrevista";
            this.btnAcciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAcciones.UseVisualStyleBackColor = true;
            this.btnAcciones.Click += new System.EventHandler(this.btnAcciones_Click);
            // 
            // FrmEntrevista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 852);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEntrevista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEntrevista";
            this.Load += new System.EventHandler(this.FrmEntrevista_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEntrevista)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.txtIdEmpleado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel txtIdEmpleado;
        private System.Windows.Forms.GroupBox groupBox3;
        private FontAwesome.Sharp.IconButton btnAcciones;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dtgEntrevista;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eliminarEntrevistaToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
    }
}