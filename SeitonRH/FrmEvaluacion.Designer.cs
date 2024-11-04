
namespace SeitonRH
{
    partial class FrmEvaluacion
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
            this.dtgEvaluacion = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarEvaluacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAcciones = new FontAwesome.Sharp.IconButton();
            this.txtEvaluacion = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtIdEmpleado = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaluacion)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.txtIdEmpleado.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgEvaluacion
            // 
            this.dtgEvaluacion.AllowUserToAddRows = false;
            this.dtgEvaluacion.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgEvaluacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvaluacion.ContextMenuStrip = this.contextMenuStrip1;
            this.dtgEvaluacion.Location = new System.Drawing.Point(23, 87);
            this.dtgEvaluacion.Name = "dtgEvaluacion";
            this.dtgEvaluacion.RowHeadersWidth = 51;
            this.dtgEvaluacion.RowTemplate.Height = 24;
            this.dtgEvaluacion.Size = new System.Drawing.Size(710, 395);
            this.dtgEvaluacion.TabIndex = 1;
            this.dtgEvaluacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEvaluacion_CellContentClick);
            this.dtgEvaluacion.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEvaluacion_CellContentDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarEvaluacionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(208, 28);
            // 
            // eliminarEvaluacionToolStripMenuItem
            // 
            this.eliminarEvaluacionToolStripMenuItem.Name = "eliminarEvaluacionToolStripMenuItem";
            this.eliminarEvaluacionToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.eliminarEvaluacionToolStripMenuItem.Text = "Eliminar evaluacion";
            this.eliminarEvaluacionToolStripMenuItem.Click += new System.EventHandler(this.eliminarEvaluacionToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAcciones);
            this.groupBox3.Controls.Add(this.dtgEvaluacion);
            this.groupBox3.Controls.Add(this.txtEvaluacion);
            this.groupBox3.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(174, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(756, 589);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resultados de Evaluaciones";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // btnAcciones
            // 
            this.btnAcciones.FlatAppearance.BorderSize = 0;
            this.btnAcciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcciones.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcciones.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnAcciones.IconChar = FontAwesome.Sharp.IconChar.Paste;
            this.btnAcciones.IconColor = System.Drawing.Color.CadetBlue;
            this.btnAcciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAcciones.IconSize = 50;
            this.btnAcciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcciones.Location = new System.Drawing.Point(573, 499);
            this.btnAcciones.Name = "btnAcciones";
            this.btnAcciones.Size = new System.Drawing.Size(160, 65);
            this.btnAcciones.TabIndex = 31;
            this.btnAcciones.Text = "Evaluar";
            this.btnAcciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnAcciones, "Haga clic aquí para ir a la pantalla de evaluación de empleados");
            this.btnAcciones.UseVisualStyleBackColor = true;
            this.btnAcciones.Click += new System.EventHandler(this.btnAcciones_Click);
            // 
            // txtEvaluacion
            // 
            this.txtEvaluacion.Location = new System.Drawing.Point(23, 40);
            this.txtEvaluacion.Name = "txtEvaluacion";
            this.txtEvaluacion.Size = new System.Drawing.Size(710, 31);
            this.txtEvaluacion.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtEvaluacion, "Ingrese el nombre del empleado que desea buscar");
            this.txtEvaluacion.TextChanged += new System.EventHandler(this.txtEvaluacion_TextChanged);
            this.txtEvaluacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEvaluacion_KeyPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SeitonRH.Properties.Resources.cerrarcuad;
            this.pictureBox2.Location = new System.Drawing.Point(712, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "Haga clic aquí para cerrar el módulo de evaluación");
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // txtIdEmpleado
            // 
            this.txtIdEmpleado.BackgroundImage = global::SeitonRH.Properties.Resources.Evaluacion;
            this.txtIdEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtIdEmpleado.Controls.Add(this.pictureBox2);
            this.txtIdEmpleado.Location = new System.Drawing.Point(174, 0);
            this.txtIdEmpleado.Name = "txtIdEmpleado";
            this.txtIdEmpleado.Size = new System.Drawing.Size(765, 236);
            this.txtIdEmpleado.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtIdEmpleado);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 844);
            this.panel1.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(157, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // FrmEvaluacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 846);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmEvaluacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEvaluacion";
            this.Load += new System.EventHandler(this.FrmEvaluacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaluacion)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.txtIdEmpleado.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnAcciones;
        private System.Windows.Forms.DataGridView dtgEvaluacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtEvaluacion;
        private System.Windows.Forms.Panel txtIdEmpleado;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eliminarEvaluacionToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}