using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrabajoIntegrador
{
    partial class PantallaOpciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaOpciones));
            this.btn_inscribirCliente = new System.Windows.Forms.Button();
            this.btn_asignarActividad = new System.Windows.Forms.Button();
            this.btn_listarVencimiento = new System.Windows.Forms.Button();
            this.btn_pagarCuota = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_inscribirCliente
            // 
            this.btn_inscribirCliente.AutoSize = true;
            this.btn_inscribirCliente.Location = new System.Drawing.Point(59, 65);
            this.btn_inscribirCliente.Name = "btn_inscribirCliente";
            this.btn_inscribirCliente.Size = new System.Drawing.Size(233, 62);
            this.btn_inscribirCliente.TabIndex = 0;
            this.btn_inscribirCliente.Text = "Incribir Cliente";
            this.btn_inscribirCliente.UseVisualStyleBackColor = true;
            // 
            // btn_asignarActividad
            // 
            this.btn_asignarActividad.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.btn_asignarActividad.AutoSize = true;
            this.btn_asignarActividad.Location = new System.Drawing.Point(383, 65);
            this.btn_asignarActividad.Name = "btn_asignarActividad";
            this.btn_asignarActividad.Size = new System.Drawing.Size(233, 62);
            this.btn_asignarActividad.TabIndex = 1;
            this.btn_asignarActividad.Text = "Asignar Actividad";
            this.btn_asignarActividad.UseVisualStyleBackColor = true;
            // 
            // btn_listarVencimiento
            // 
            this.btn_listarVencimiento.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.btn_listarVencimiento.AutoSize = true;
            this.btn_listarVencimiento.Location = new System.Drawing.Point(383, 198);
            this.btn_listarVencimiento.Name = "btn_listarVencimiento";
            this.btn_listarVencimiento.Size = new System.Drawing.Size(233, 62);
            this.btn_listarVencimiento.TabIndex = 2;
            this.btn_listarVencimiento.Text = "Listar Vencimientos";
            this.btn_listarVencimiento.UseVisualStyleBackColor = true;
            // 
            // btn_pagarCuota
            // 
            this.btn_pagarCuota.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.btn_pagarCuota.AutoSize = true;
            this.btn_pagarCuota.Location = new System.Drawing.Point(59, 198);
            this.btn_pagarCuota.Name = "btn_pagarCuota";
            this.btn_pagarCuota.Size = new System.Drawing.Size(233, 62);
            this.btn_pagarCuota.TabIndex = 3;
            this.btn_pagarCuota.Text = "Pagar Cuota";
            this.btn_pagarCuota.UseVisualStyleBackColor = true;
            // 
            // PantallaOpciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(914, 480);
            this.Controls.Add(this.btn_pagarCuota);
            this.Controls.Add(this.btn_listarVencimiento);
            this.Controls.Add(this.btn_asignarActividad);
            this.Controls.Add(this.btn_inscribirCliente);
            this.Name = "PantallaOpciones";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_inscribirCliente;
        private Button btn_asignarActividad;
        private Button btn_pagarCuota;
        private Button btn_listarVencimiento;
    }
}
