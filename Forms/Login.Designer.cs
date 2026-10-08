using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrabajoIntegrador
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.lbl_contrasena = new System.Windows.Forms.Label();
            this.lbl_usuarioRequired = new System.Windows.Forms.Label();
            this.lbl_contrasenaRequired = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(276, 233);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(4);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(85, 25);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(276, 178);
            this.txtClave.Margin = new System.Windows.Forms.Padding(4);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(113, 22);
            this.txtClave.TabIndex = 1;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(276, 97);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(113, 22);
            this.txtUsuario.TabIndex = 0;
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Location = new System.Drawing.Point(276, 65);
            this.lbl_usuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(54, 16);
            this.lbl_usuario.TabIndex = 4;
            this.lbl_usuario.Text = "Usuario";
            // 
            // lbl_contrasena
            // 
            this.lbl_contrasena.AutoSize = true;
            this.lbl_contrasena.Location = new System.Drawing.Point(276, 148);
            this.lbl_contrasena.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_contrasena.Name = "lbl_contrasena";
            this.lbl_contrasena.Size = new System.Drawing.Size(76, 16);
            this.lbl_contrasena.TabIndex = 5;
            this.lbl_contrasena.Text = "Contraseña";
            // 
            // lbl_usuarioRequired
            // 
            this.lbl_usuarioRequired.AutoSize = true;
            this.lbl_usuarioRequired.BackColor = System.Drawing.Color.Transparent;
            this.lbl_usuarioRequired.ForeColor = System.Drawing.Color.Red;
            this.lbl_usuarioRequired.Location = new System.Drawing.Point(397, 100);
            this.lbl_usuarioRequired.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_usuarioRequired.Name = "lbl_usuarioRequired";
            this.lbl_usuarioRequired.Size = new System.Drawing.Size(12, 16);
            this.lbl_usuarioRequired.TabIndex = 6;
            this.lbl_usuarioRequired.Text = "*";
            // 
            // lbl_contrasenaRequired
            // 
            this.lbl_contrasenaRequired.AutoSize = true;
            this.lbl_contrasenaRequired.BackColor = System.Drawing.Color.Transparent;
            this.lbl_contrasenaRequired.ForeColor = System.Drawing.Color.Red;
            this.lbl_contrasenaRequired.Location = new System.Drawing.Point(397, 181);
            this.lbl_contrasenaRequired.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_contrasenaRequired.Name = "lbl_contrasenaRequired";
            this.lbl_contrasenaRequired.Size = new System.Drawing.Size(12, 16);
            this.lbl_contrasenaRequired.TabIndex = 7;
            this.lbl_contrasenaRequired.Text = "*";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(915, 480);
            this.Controls.Add(this.lbl_contrasenaRequired);
            this.Controls.Add(this.lbl_usuarioRequired);
            this.Controls.Add(this.lbl_contrasena);
            this.Controls.Add(this.lbl_usuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.btnIngresar);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_usuario;
        private TextBox txtUsuario;
        private Label lbl_contrasena;
        private TextBox txtClave;
        private Button btnIngresar;
        private Label lbl_usuarioRequired;
        private Label lbl_contrasenaRequired;
    }
}