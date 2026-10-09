using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrabajoIntegrador
{
    partial class IngresarCliente
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresarCliente));
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_apellido = new System.Windows.Forms.Label();
            this.lbl_tipoDocumento = new System.Windows.Forms.Label();
            this.lbl_mail = new System.Windows.Forms.Label();
            this.lbl_telefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btn_volver = new System.Windows.Forms.Button();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkEsSocio = new System.Windows.Forms.CheckBox();
            this.chkAptoFisico = new System.Windows.Forms.CheckBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            resources.ApplyResources(this.txtNombre, "txtNombre");
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtApellido
            // 
            resources.ApplyResources(this.txtApellido, "txtApellido");
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.TextChanged += new System.EventHandler(this.txtApellido_TextChanged);
            // 
            // txtEmail
            // 
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lbl_nombre
            // 
            resources.ApplyResources(this.lbl_nombre, "lbl_nombre");
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Click += new System.EventHandler(this.lbl_nombre_Click);
            // 
            // lbl_apellido
            // 
            resources.ApplyResources(this.lbl_apellido, "lbl_apellido");
            this.lbl_apellido.Name = "lbl_apellido";
            this.lbl_apellido.Click += new System.EventHandler(this.lbl_apellido_Click);
            // 
            // lbl_tipoDocumento
            // 
            resources.ApplyResources(this.lbl_tipoDocumento, "lbl_tipoDocumento");
            this.lbl_tipoDocumento.Name = "lbl_tipoDocumento";
            this.lbl_tipoDocumento.Click += new System.EventHandler(this.lbl_tipoDocumento_Click);
            // 
            // lbl_mail
            // 
            resources.ApplyResources(this.lbl_mail, "lbl_mail");
            this.lbl_mail.Name = "lbl_mail";
            this.lbl_mail.Click += new System.EventHandler(this.lbl_mail_Click);
            // 
            // lbl_telefono
            // 
            resources.ApplyResources(this.lbl_telefono, "lbl_telefono");
            this.lbl_telefono.Name = "lbl_telefono";
            this.lbl_telefono.Click += new System.EventHandler(this.lbl_telefono_Click);
            // 
            // txtTelefono
            // 
            resources.ApplyResources(this.txtTelefono, "txtTelefono");
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            // 
            // btn_volver
            // 
            resources.ApplyResources(this.btn_volver, "btn_volver");
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Items.AddRange(new object[] {
            resources.GetString("cboTipoDoc.Items"),
            resources.GetString("cboTipoDoc.Items1"),
            resources.GetString("cboTipoDoc.Items2")});
            resources.ApplyResources(this.cboTipoDoc, "cboTipoDoc");
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.SelectedIndexChanged += new System.EventHandler(this.cboTipoDoc_SelectedIndexChanged);
            // 
            // btn_registrar
            // 
            resources.ApplyResources(this.btn_registrar, "btn_registrar");
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // txtDocumento
            // 
            resources.ApplyResources(this.txtDocumento, "txtDocumento");
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.TextChanged += new System.EventHandler(this.txtDocumento_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // chkEsSocio
            // 
            resources.ApplyResources(this.chkEsSocio, "chkEsSocio");
            this.chkEsSocio.Name = "chkEsSocio";
            this.chkEsSocio.UseVisualStyleBackColor = true;
            this.chkEsSocio.CheckedChanged += new System.EventHandler(this.chkEsSocio_CheckedChanged);
            // 
            // chkAptoFisico
            // 
            resources.ApplyResources(this.chkAptoFisico, "chkAptoFisico");
            this.chkAptoFisico.Name = "chkAptoFisico";
            this.chkAptoFisico.UseVisualStyleBackColor = true;
            this.chkAptoFisico.CheckedChanged += new System.EventHandler(this.chkAptoFisico_CheckedChanged);
            // 
            // lblFechaNacimiento
            // 
            resources.ApplyResources(this.lblFechaNacimiento, "lblFechaNacimiento");
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpFechaNacimiento, "dtpFechaNacimiento");
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            // 
            // IngresarCliente
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.chkAptoFisico);
            this.Controls.Add(this.chkEsSocio);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.cboTipoDoc);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lbl_telefono);
            this.Controls.Add(this.lbl_mail);
            this.Controls.Add(this.lbl_tipoDocumento);
            this.Controls.Add(this.lbl_apellido);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Name = "IngresarCliente";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_nombre;
        private TextBox txtNombre;
        private Label lbl_apellido;
        private TextBox txtApellido;
        private Label lbl_tipoDocumento;
        private ComboBox cboTipoDoc;
        private TextBox txtDocumento;
        private TextBox txtTelefono;
        private Label lbl_telefono;
        private TextBox txtEmail;
        private Label lbl_mail;
        private Label lblFechaNacimiento;
        private DateTimePicker dtpFechaNacimiento;
        private CheckBox chkEsSocio;
        private CheckBox chkAptoFisico;
        private Button btn_registrar;
        private Button btn_volver;
        private ErrorProvider errorProvider1;
    }
}
