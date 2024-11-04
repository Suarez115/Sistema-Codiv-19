
namespace SeitonRH
{
    partial class FrmConsEvaluacion
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCons = new System.Windows.Forms.TextBox();
            this.dtgBusqueda = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBusqueda)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre del Empleado:";
            // 
            // txtNombreCons
            // 
            this.txtNombreCons.Location = new System.Drawing.Point(298, 166);
            this.txtNombreCons.Name = "txtNombreCons";
            this.txtNombreCons.Size = new System.Drawing.Size(332, 22);
            this.txtNombreCons.TabIndex = 6;
            this.txtNombreCons.TextChanged += new System.EventHandler(this.txtNombreCons_TextChanged);
            // 
            // dtgBusqueda
            // 
            this.dtgBusqueda.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBusqueda.Location = new System.Drawing.Point(10, 209);
            this.dtgBusqueda.Name = "dtgBusqueda";
            this.dtgBusqueda.RowHeadersWidth = 51;
            this.dtgBusqueda.RowTemplate.Height = 24;
            this.dtgBusqueda.Size = new System.Drawing.Size(776, 235);
            this.dtgBusqueda.TabIndex = 7;
            this.dtgBusqueda.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBusqueda_CellContentDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SeitonRH.Properties.Resources.Búsqueda_de_Empleados;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(1, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 138);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SeitonRH.Properties.Resources.cerrarcuad;
            this.pictureBox2.Location = new System.Drawing.Point(749, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // FrmConsEvaluacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreCons);
            this.Controls.Add(this.dtgBusqueda);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsEvaluacion";
            this.Text = "FrmConsEvaluacion";
            ((System.ComponentModel.ISupportInitialize)(this.dtgBusqueda)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreCons;
        private System.Windows.Forms.DataGridView dtgBusqueda;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}