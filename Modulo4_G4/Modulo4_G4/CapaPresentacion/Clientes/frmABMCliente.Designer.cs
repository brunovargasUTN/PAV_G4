
namespace Modulo4_G4.CapaPresentacion.Clientes
{
    partial class frmABMCliente
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
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtNro = new System.Windows.Forms.TextBox();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblRazon = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblNro = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.lblContacto = new System.Windows.Forms.Label();
            this.btnAgregarBarrio = new System.Windows.Forms.Button();
            this.btnAgregarContacto = new System.Windows.Forms.Button();
            this.cboBarrio = new System.Windows.Forms.ComboBox();
            this.cboContacto = new System.Windows.Forms.ComboBox();
            this.mtbFecha = new System.Windows.Forms.MaskedTextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblAceptar = new System.Windows.Forms.Label();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.mtbCuit = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // txtRazon
            // 
            this.txtRazon.Location = new System.Drawing.Point(129, 71);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(249, 27);
            this.txtRazon.TabIndex = 1;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(129, 114);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(95, 27);
            this.txtCalle.TabIndex = 2;
            // 
            // txtNro
            // 
            this.txtNro.Location = new System.Drawing.Point(129, 156);
            this.txtNro.Name = "txtNro";
            this.txtNro.Size = new System.Drawing.Size(249, 27);
            this.txtNro.TabIndex = 3;
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(22, 32);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(40, 20);
            this.lblCuit.TabIndex = 8;
            this.lblCuit.Text = "CUIT";
            // 
            // lblRazon
            // 
            this.lblRazon.AutoSize = true;
            this.lblRazon.Location = new System.Drawing.Point(22, 74);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(94, 20);
            this.lblRazon.TabIndex = 9;
            this.lblRazon.Text = "Razón Social";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(22, 117);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(42, 20);
            this.lblCalle.TabIndex = 10;
            this.lblCalle.Text = "Calle";
            // 
            // lblNro
            // 
            this.lblNro.AutoSize = true;
            this.lblNro.Location = new System.Drawing.Point(22, 159);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(95, 20);
            this.lblNro.TabIndex = 11;
            this.lblNro.Text = "N° Domicilio";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(22, 202);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(78, 20);
            this.lblFecha.TabIndex = 12;
            this.lblFecha.Text = "Fecha Alta";
            // 
            // lblBarrio
            // 
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(22, 248);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(49, 20);
            this.lblBarrio.TabIndex = 13;
            this.lblBarrio.Text = "Barrio";
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Location = new System.Drawing.Point(22, 296);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(69, 20);
            this.lblContacto.TabIndex = 14;
            this.lblContacto.Text = "Contacto";
            // 
            // btnAgregarBarrio
            // 
            this.btnAgregarBarrio.Enabled = false;
            this.btnAgregarBarrio.Image = global::Modulo4_G4.Properties.Resources.Small_add_icon_icons_com_74429;
            this.btnAgregarBarrio.Location = new System.Drawing.Point(350, 244);
            this.btnAgregarBarrio.Name = "btnAgregarBarrio";
            this.btnAgregarBarrio.Size = new System.Drawing.Size(28, 28);
            this.btnAgregarBarrio.TabIndex = 6;
            this.btnAgregarBarrio.UseVisualStyleBackColor = true;
            this.btnAgregarBarrio.Click += new System.EventHandler(this.btnAgregarBarrio_Click);
            // 
            // btnAgregarContacto
            // 
            this.btnAgregarContacto.Enabled = false;
            this.btnAgregarContacto.Image = global::Modulo4_G4.Properties.Resources.Small_add_icon_icons_com_74429;
            this.btnAgregarContacto.Location = new System.Drawing.Point(350, 292);
            this.btnAgregarContacto.Name = "btnAgregarContacto";
            this.btnAgregarContacto.Size = new System.Drawing.Size(28, 28);
            this.btnAgregarContacto.TabIndex = 8;
            this.btnAgregarContacto.UseVisualStyleBackColor = true;
            this.btnAgregarContacto.Click += new System.EventHandler(this.btnAgregarContacto_Click);
            // 
            // cboBarrio
            // 
            this.cboBarrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBarrio.FormattingEnabled = true;
            this.cboBarrio.Location = new System.Drawing.Point(129, 245);
            this.cboBarrio.Name = "cboBarrio";
            this.cboBarrio.Size = new System.Drawing.Size(215, 28);
            this.cboBarrio.TabIndex = 5;
            // 
            // cboContacto
            // 
            this.cboContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContacto.FormattingEnabled = true;
            this.cboContacto.Location = new System.Drawing.Point(129, 293);
            this.cboContacto.Name = "cboContacto";
            this.cboContacto.Size = new System.Drawing.Size(215, 28);
            this.cboContacto.TabIndex = 7;
            // 
            // mtbFecha
            // 
            this.mtbFecha.Location = new System.Drawing.Point(129, 199);
            this.mtbFecha.Mask = "00/00/0000";
            this.mtbFecha.Name = "mtbFecha";
            this.mtbFecha.Size = new System.Drawing.Size(95, 27);
            this.mtbFecha.TabIndex = 4;
            this.mtbFecha.ValidatingType = typeof(System.DateTime);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::Modulo4_G4.Properties.Resources.aceptar_icon;
            this.btnAceptar.Location = new System.Drawing.Point(129, 351);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(54, 58);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Modulo4_G4.Properties.Resources.cancelar_icon;
            this.btnCancelar.Location = new System.Drawing.Point(300, 351);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(54, 58);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblAceptar
            // 
            this.lblAceptar.AutoSize = true;
            this.lblAceptar.Location = new System.Drawing.Point(122, 421);
            this.lblAceptar.Name = "lblAceptar";
            this.lblAceptar.Size = new System.Drawing.Size(61, 20);
            this.lblAceptar.TabIndex = 22;
            this.lblAceptar.Text = "Aceptar";
            // 
            // lblCancelar
            // 
            this.lblCancelar.AutoSize = true;
            this.lblCancelar.Location = new System.Drawing.Point(300, 421);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(66, 20);
            this.lblCancelar.TabIndex = 23;
            this.lblCancelar.Text = "Cancelar";
            // 
            // mtbCuit
            // 
            this.mtbCuit.Location = new System.Drawing.Point(129, 29);
            this.mtbCuit.Mask = "00-00000000-0";
            this.mtbCuit.Name = "mtbCuit";
            this.mtbCuit.Size = new System.Drawing.Size(118, 27);
            this.mtbCuit.TabIndex = 0;
            this.mtbCuit.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // frmABMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 463);
            this.Controls.Add(this.mtbCuit);
            this.Controls.Add(this.lblCancelar);
            this.Controls.Add(this.lblAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.mtbFecha);
            this.Controls.Add(this.cboContacto);
            this.Controls.Add(this.cboBarrio);
            this.Controls.Add(this.btnAgregarContacto);
            this.Controls.Add(this.btnAgregarBarrio);
            this.Controls.Add(this.lblContacto);
            this.Controls.Add(this.lblBarrio);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblNro);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.lblRazon);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.txtNro);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.txtRazon);
            this.Name = "frmABMCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmABMCliente";
            this.Load += new System.EventHandler(this.frmABMCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtNro;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.Button btnAgregarBarrio;
        private System.Windows.Forms.Button btnAgregarContacto;
        private System.Windows.Forms.ComboBox cboBarrio;
        private System.Windows.Forms.ComboBox cboContacto;
        private System.Windows.Forms.MaskedTextBox mtbFecha;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblAceptar;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.MaskedTextBox mtbCuit;
    }
}