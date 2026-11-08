namespace TrabajoIntegrador
{
    partial class GestionPago
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
            this.panelDatos = new System.Windows.Forms.Panel();
            this.lblInfoCliente = new System.Windows.Forms.Label();
            this.panelPago = new System.Windows.Forms.Panel();
            this.lblCuotasDetalle = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblMontoValor = new System.Windows.Forms.Label();
            this.lblTotalTexto = new System.Windows.Forms.Label();
            this.panelCuotas = new System.Windows.Forms.Panel();
            this.rb6Cuotas = new System.Windows.Forms.RadioButton();
            this.rb3Cuotas = new System.Windows.Forms.RadioButton();
            this.rb1Pago = new System.Windows.Forms.RadioButton();
            this.cmbMedioPago = new System.Windows.Forms.ComboBox();
            this.lblMedioActividades = new System.Windows.Forms.Label();
            this.panelActividades = new System.Windows.Forms.Panel();
            this.lblMedio = new System.Windows.Forms.Label();
            this.btnPasarIzquierda = new System.Windows.Forms.Button();
            this.btnPasarDerecha = new System.Windows.Forms.Button();
            this.lstSeleccionadas = new System.Windows.Forms.ListBox();
            this.lstDisponibles = new System.Windows.Forms.ListBox();
            this.lblTituloSelec = new System.Windows.Forms.Label();
            this.lblTituloDisp = new System.Windows.Forms.Label();
            this.lstMesesAdeudados = new System.Windows.Forms.ListBox();
            this.panelDatos.SuspendLayout();
            this.panelPago.SuspendLayout();
            this.panelCuotas.SuspendLayout();
            this.panelActividades.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDatos
            // 
            this.panelDatos.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelDatos.Controls.Add(this.lblInfoCliente);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDatos.Location = new System.Drawing.Point(0, 0);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(654, 60);
            this.panelDatos.TabIndex = 0;
            // 
            // lblInfoCliente
            // 
            this.lblInfoCliente.AutoSize = true;
            this.lblInfoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoCliente.Location = new System.Drawing.Point(49, 26);
            this.lblInfoCliente.Name = "lblInfoCliente";
            this.lblInfoCliente.Size = new System.Drawing.Size(125, 17);
            this.lblInfoCliente.TabIndex = 0;
            this.lblInfoCliente.Text = "Datos del cliente...";
            // 
            // panelPago
            // 
            this.panelPago.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelPago.Controls.Add(this.lblCuotasDetalle);
            this.panelPago.Controls.Add(this.btnCancelar);
            this.panelPago.Controls.Add(this.btnAceptar);
            this.panelPago.Controls.Add(this.lblMontoValor);
            this.panelPago.Controls.Add(this.lblTotalTexto);
            this.panelPago.Controls.Add(this.panelCuotas);
            this.panelPago.Controls.Add(this.cmbMedioPago);
            this.panelPago.Controls.Add(this.lblMedioActividades);
            this.panelPago.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPago.Location = new System.Drawing.Point(0, 331);
            this.panelPago.Name = "panelPago";
            this.panelPago.Size = new System.Drawing.Size(654, 150);
            this.panelPago.TabIndex = 1;
            // 
            // lblCuotasDetalle
            // 
            this.lblCuotasDetalle.AutoSize = true;
            this.lblCuotasDetalle.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblCuotasDetalle.Location = new System.Drawing.Point(363, 69);
            this.lblCuotasDetalle.Name = "lblCuotasDetalle";
            this.lblCuotasDetalle.Size = new System.Drawing.Size(70, 13);
            this.lblCuotasDetalle.TabIndex = 7;
            this.lblCuotasDetalle.Text = "Detalle cuota";
            this.lblCuotasDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCuotasDetalle.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(30, 97);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(141, 35);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(492, 97);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(141, 35);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Confirmar pago";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnConfirmarPago_Click);
            // 
            // lblMontoValor
            // 
            this.lblMontoValor.AutoSize = true;
            this.lblMontoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoValor.Location = new System.Drawing.Point(443, 35);
            this.lblMontoValor.Name = "lblMontoValor";
            this.lblMontoValor.Size = new System.Drawing.Size(60, 24);
            this.lblMontoValor.TabIndex = 4;
            this.lblMontoValor.Text = "$ 0.00";
            this.lblMontoValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalTexto
            // 
            this.lblTotalTexto.AutoSize = true;
            this.lblTotalTexto.Location = new System.Drawing.Point(363, 14);
            this.lblTotalTexto.Name = "lblTotalTexto";
            this.lblTotalTexto.Size = new System.Drawing.Size(92, 13);
            this.lblTotalTexto.TabIndex = 3;
            this.lblTotalTexto.Text = "TOTAL A PAGAR";
            this.lblTotalTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCuotas
            // 
            this.panelCuotas.Controls.Add(this.rb6Cuotas);
            this.panelCuotas.Controls.Add(this.rb3Cuotas);
            this.panelCuotas.Controls.Add(this.rb1Pago);
            this.panelCuotas.Location = new System.Drawing.Point(243, 14);
            this.panelCuotas.Name = "panelCuotas";
            this.panelCuotas.Size = new System.Drawing.Size(78, 77);
            this.panelCuotas.TabIndex = 2;
            this.panelCuotas.Visible = false;
            // 
            // rb6Cuotas
            // 
            this.rb6Cuotas.AutoSize = true;
            this.rb6Cuotas.Location = new System.Drawing.Point(4, 51);
            this.rb6Cuotas.Name = "rb6Cuotas";
            this.rb6Cuotas.Size = new System.Drawing.Size(67, 17);
            this.rb6Cuotas.TabIndex = 2;
            this.rb6Cuotas.Text = "6 Cuotas";
            this.rb6Cuotas.UseVisualStyleBackColor = true;
            this.rb6Cuotas.CheckedChanged += new System.EventHandler(this.rbCuotas_CheckedChanged);
            // 
            // rb3Cuotas
            // 
            this.rb3Cuotas.AutoSize = true;
            this.rb3Cuotas.Location = new System.Drawing.Point(4, 27);
            this.rb3Cuotas.Name = "rb3Cuotas";
            this.rb3Cuotas.Size = new System.Drawing.Size(67, 17);
            this.rb3Cuotas.TabIndex = 1;
            this.rb3Cuotas.Text = "3 Cuotas";
            this.rb3Cuotas.UseVisualStyleBackColor = true;
            this.rb3Cuotas.CheckedChanged += new System.EventHandler(this.rbCuotas_CheckedChanged);
            // 
            // rb1Pago
            // 
            this.rb1Pago.AutoSize = true;
            this.rb1Pago.Checked = true;
            this.rb1Pago.Location = new System.Drawing.Point(4, 3);
            this.rb1Pago.Name = "rb1Pago";
            this.rb1Pago.Size = new System.Drawing.Size(59, 17);
            this.rb1Pago.TabIndex = 0;
            this.rb1Pago.TabStop = true;
            this.rb1Pago.Text = "1 Pago";
            this.rb1Pago.UseVisualStyleBackColor = true;
            // 
            // cmbMedioPago
            // 
            this.cmbMedioPago.FormattingEnabled = true;
            this.cmbMedioPago.Items.AddRange(new object[] {
            "Efectivo",
            "Transferencia",
            "Tarjeta de Crédito"});
            this.cmbMedioPago.Location = new System.Drawing.Point(116, 14);
            this.cmbMedioPago.Name = "cmbMedioPago";
            this.cmbMedioPago.Size = new System.Drawing.Size(121, 21);
            this.cmbMedioPago.TabIndex = 1;
            this.cmbMedioPago.SelectedIndexChanged += new System.EventHandler(this.cmbMedioPago_SelectedIndexChanged);
            // 
            // lblMedioActividades
            // 
            this.lblMedioActividades.AutoSize = true;
            this.lblMedioActividades.Location = new System.Drawing.Point(27, 14);
            this.lblMedioActividades.Name = "lblMedioActividades";
            this.lblMedioActividades.Size = new System.Drawing.Size(82, 13);
            this.lblMedioActividades.TabIndex = 0;
            this.lblMedioActividades.Text = "Medio de Pago:";
            // 
            // panelActividades
            // 
            this.panelActividades.BackColor = System.Drawing.Color.DimGray;
            this.panelActividades.Controls.Add(this.lblMedio);
            this.panelActividades.Controls.Add(this.btnPasarIzquierda);
            this.panelActividades.Controls.Add(this.btnPasarDerecha);
            this.panelActividades.Controls.Add(this.lstSeleccionadas);
            this.panelActividades.Controls.Add(this.lstDisponibles);
            this.panelActividades.Controls.Add(this.lblTituloSelec);
            this.panelActividades.Controls.Add(this.lblTituloDisp);
            this.panelActividades.Controls.Add(this.lstMesesAdeudados);
            this.panelActividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActividades.Location = new System.Drawing.Point(0, 60);
            this.panelActividades.Name = "panelActividades";
            this.panelActividades.Size = new System.Drawing.Size(654, 271);
            this.panelActividades.TabIndex = 2;
            // 
            // lblMedio
            // 
            this.lblMedio.AutoSize = true;
            this.lblMedio.Location = new System.Drawing.Point(267, 16);
            this.lblMedio.Name = "lblMedio";
            this.lblMedio.Size = new System.Drawing.Size(104, 13);
            this.lblMedio.TabIndex = 8;
            this.lblMedio.Text = "Actividades/Deudas";
            this.lblMedio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPasarIzquierda
            // 
            this.btnPasarIzquierda.Location = new System.Drawing.Point(281, 128);
            this.btnPasarIzquierda.Name = "btnPasarIzquierda";
            this.btnPasarIzquierda.Size = new System.Drawing.Size(25, 25);
            this.btnPasarIzquierda.TabIndex = 5;
            this.btnPasarIzquierda.Text = "<";
            this.btnPasarIzquierda.UseVisualStyleBackColor = true;
            this.btnPasarIzquierda.Click += new System.EventHandler(this.btnPasarIzquierda_Click);
            // 
            // btnPasarDerecha
            // 
            this.btnPasarDerecha.Location = new System.Drawing.Point(321, 128);
            this.btnPasarDerecha.Name = "btnPasarDerecha";
            this.btnPasarDerecha.Size = new System.Drawing.Size(25, 25);
            this.btnPasarDerecha.TabIndex = 4;
            this.btnPasarDerecha.Text = ">";
            this.btnPasarDerecha.UseVisualStyleBackColor = true;
            this.btnPasarDerecha.Click += new System.EventHandler(this.btnPasarDerecha_Click);
            // 
            // lstSeleccionadas
            // 
            this.lstSeleccionadas.FormattingEnabled = true;
            this.lstSeleccionadas.Location = new System.Drawing.Point(385, 44);
            this.lstSeleccionadas.Name = "lstSeleccionadas";
            this.lstSeleccionadas.Size = new System.Drawing.Size(200, 186);
            this.lstSeleccionadas.TabIndex = 3;
            // 
            // lstDisponibles
            // 
            this.lstDisponibles.FormattingEnabled = true;
            this.lstDisponibles.Location = new System.Drawing.Point(52, 44);
            this.lstDisponibles.Name = "lstDisponibles";
            this.lstDisponibles.Size = new System.Drawing.Size(200, 186);
            this.lstDisponibles.TabIndex = 2;
            // 
            // lblTituloSelec
            // 
            this.lblTituloSelec.AutoSize = true;
            this.lblTituloSelec.Location = new System.Drawing.Point(418, 16);
            this.lblTituloSelec.Name = "lblTituloSelec";
            this.lblTituloSelec.Size = new System.Drawing.Size(77, 13);
            this.lblTituloSelec.TabIndex = 1;
            this.lblTituloSelec.Text = "Seleccionadas";
            // 
            // lblTituloDisp
            // 
            this.lblTituloDisp.AutoSize = true;
            this.lblTituloDisp.Location = new System.Drawing.Point(89, 16);
            this.lblTituloDisp.Name = "lblTituloDisp";
            this.lblTituloDisp.Size = new System.Drawing.Size(61, 13);
            this.lblTituloDisp.TabIndex = 0;
            this.lblTituloDisp.Text = "Disponibles";
            // 
            // lstMesesAdeudados
            // 
            this.lstMesesAdeudados.FormattingEnabled = true;
            this.lstMesesAdeudados.Location = new System.Drawing.Point(133, 44);
            this.lstMesesAdeudados.Name = "lstMesesAdeudados";
            this.lstMesesAdeudados.Size = new System.Drawing.Size(370, 147);
            this.lstMesesAdeudados.TabIndex = 7;
            // 
            // GestionPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 481);
            this.Controls.Add(this.panelActividades);
            this.Controls.Add(this.panelPago);
            this.Controls.Add(this.panelDatos);
            this.Name = "GestionPago";
            this.Text = "Gestion de pago";
            this.panelDatos.ResumeLayout(false);
            this.panelDatos.PerformLayout();
            this.panelPago.ResumeLayout(false);
            this.panelPago.PerformLayout();
            this.panelCuotas.ResumeLayout(false);
            this.panelCuotas.PerformLayout();
            this.panelActividades.ResumeLayout(false);
            this.panelActividades.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Label lblInfoCliente;
        private System.Windows.Forms.Panel panelPago;
        private System.Windows.Forms.ComboBox cmbMedioPago;
        private System.Windows.Forms.Label lblMedioActividades;
        private System.Windows.Forms.Label lblMontoValor;
        private System.Windows.Forms.Label lblTotalTexto;
        private System.Windows.Forms.Panel panelCuotas;
        private System.Windows.Forms.RadioButton rb6Cuotas;
        private System.Windows.Forms.RadioButton rb3Cuotas;
        private System.Windows.Forms.RadioButton rb1Pago;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel panelActividades;
        private System.Windows.Forms.Button btnPasarDerecha;
        private System.Windows.Forms.ListBox lstSeleccionadas;
        private System.Windows.Forms.ListBox lstDisponibles;
        private System.Windows.Forms.Label lblTituloSelec;
        private System.Windows.Forms.Label lblTituloDisp;
        private System.Windows.Forms.Button btnPasarIzquierda;
        private System.Windows.Forms.Label lblCuotasDetalle;
        private System.Windows.Forms.ListBox lstMesesAdeudados;
        private System.Windows.Forms.Label lblMedio;
    }
}