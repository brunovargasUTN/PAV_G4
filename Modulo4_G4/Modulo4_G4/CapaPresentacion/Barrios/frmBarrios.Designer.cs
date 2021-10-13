
namespace Modulo4_G4.CapaPresentacion.Barrios
{
    partial class frmBarrios
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblSalir = new System.Windows.Forms.Label();
            this.cboBarrios = new System.Windows.Forms.ComboBox();
            this.grbRegistrar = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbRegistrar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(15, 39);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(222, 27);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.Click += new System.EventHandler(this.txtNombre_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(271, 39);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(107, 27);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "Registrar";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(271, 39);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(107, 27);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Modificar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(271, 82);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(107, 27);
            this.btnQuitar.TabIndex = 4;
            this.btnQuitar.Text = "Eliminar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Modulo4_G4.Properties.Resources.exit_icon;
            this.btnSalir.Location = new System.Drawing.Point(314, 272);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(59, 56);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblSalir
            // 
            this.lblSalir.AutoSize = true;
            this.lblSalir.Location = new System.Drawing.Point(323, 331);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(38, 20);
            this.lblSalir.TabIndex = 10;
            this.lblSalir.Text = "Salir";
            // 
            // cboBarrios
            // 
            this.cboBarrios.FormattingEnabled = true;
            this.cboBarrios.Location = new System.Drawing.Point(15, 38);
            this.cboBarrios.Name = "cboBarrios";
            this.cboBarrios.Size = new System.Drawing.Size(222, 28);
            this.cboBarrios.TabIndex = 2;
            this.cboBarrios.SelectedValueChanged += new System.EventHandler(this.cboBarrios_SelectedValueChanged);
            // 
            // grbRegistrar
            // 
            this.grbRegistrar.Controls.Add(this.txtNombre);
            this.grbRegistrar.Controls.Add(this.btnNuevo);
            this.grbRegistrar.Location = new System.Drawing.Point(14, 163);
            this.grbRegistrar.Name = "grbRegistrar";
            this.grbRegistrar.Size = new System.Drawing.Size(394, 89);
            this.grbRegistrar.TabIndex = 5;
            this.grbRegistrar.TabStop = false;
            this.grbRegistrar.Text = "Registrar Nuevo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboBarrios);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barrios";
            // 
            // frmBarrios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 363);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbRegistrar);
            this.Controls.Add(this.lblSalir);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmBarrios";
            this.Text = "Barrios";
            this.Load += new System.EventHandler(this.frmBarrios_Load);
            this.grbRegistrar.ResumeLayout(false);
            this.grbRegistrar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.ComboBox cboBarrios;
        private System.Windows.Forms.GroupBox grbRegistrar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}