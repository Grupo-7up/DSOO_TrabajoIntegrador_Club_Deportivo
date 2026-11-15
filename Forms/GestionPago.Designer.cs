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
            this.lblInfoCliente = new System.Windows.Forms.Label();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.panelPago.SuspendLayout();
            this.panelCuotas.SuspendLayout();
            this.panelActividades.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPago
            // 
            this.panelPago.BackColor = System.Drawing.Color.Gainsboro;
            this.panelPago.Controls.Add(this.lblCuotasDetalle);
            this.panelPago.Controls.Add(this.btnCancelar);
            this.panelPago.Controls.Add(this.btnAceptar);
            this.panelPago.Controls.Add(this.lblMontoValor);
            this.panelPago.Controls.Add(this.lblTotalTexto);
            this.panelPago.Controls.Add(this.panelCuotas);
            this.panelPago.Controls.Add(this.cmbMedioPago);
            this.panelPago.Controls.Add(this.lblMedioActividades);
            this.panelPago.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPago.Location = new System.Drawing.Point(0, 407);
            this.panelPago.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPago.Name = "panelPago";
            this.panelPago.Size = new System.Drawing.Size(872, 185);
            this.panelPago.TabIndex = 1;
            this.panelPago.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPago_Paint);
            // 
            // lblCuotasDetalle
            // 
            this.lblCuotasDetalle.AutoSize = true;
            this.lblCuotasDetalle.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblCuotasDetalle.Location = new System.Drawing.Point(533, 84);
            this.lblCuotasDetalle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCuotasDetalle.Name = "lblCuotasDetalle";
            this.lblCuotasDetalle.Size = new System.Drawing.Size(86, 16);
            this.lblCuotasDetalle.TabIndex = 7;
            this.lblCuotasDetalle.Text = "Detalle cuota";
            this.lblCuotasDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCuotasDetalle.Visible = false;
            this.lblCuotasDetalle.Click += new System.EventHandler(this.lblCuotasDetalle_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(69, 119);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(188, 43);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(613, 119);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(188, 43);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Confirmar pago";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnConfirmarPago_Click);
            // 
            // lblMontoValor
            // 
            this.lblMontoValor.AutoSize = true;
            this.lblMontoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoValor.Location = new System.Drawing.Point(638, 42);
            this.lblMontoValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMontoValor.Name = "lblMontoValor";
            this.lblMontoValor.Size = new System.Drawing.Size(77, 29);
            this.lblMontoValor.TabIndex = 4;
            this.lblMontoValor.Text = "$ 0.00";
            this.lblMontoValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalTexto
            // 
            this.lblTotalTexto.AutoSize = true;
            this.lblTotalTexto.Location = new System.Drawing.Point(533, 17);
            this.lblTotalTexto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalTexto.Name = "lblTotalTexto";
            this.lblTotalTexto.Size = new System.Drawing.Size(113, 16);
            this.lblTotalTexto.TabIndex = 3;
            this.lblTotalTexto.Text = "TOTAL A PAGAR";
            this.lblTotalTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCuotas
            // 
            this.panelCuotas.Controls.Add(this.rb6Cuotas);
            this.panelCuotas.Controls.Add(this.rb3Cuotas);
            this.panelCuotas.Controls.Add(this.rb1Pago);
            this.panelCuotas.Location = new System.Drawing.Point(357, 17);
            this.panelCuotas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCuotas.Name = "panelCuotas";
            this.panelCuotas.Size = new System.Drawing.Size(104, 95);
            this.panelCuotas.TabIndex = 2;
            this.panelCuotas.Visible = false;
            // 
            // rb6Cuotas
            // 
            this.rb6Cuotas.AutoSize = true;
            this.rb6Cuotas.Location = new System.Drawing.Point(5, 63);
            this.rb6Cuotas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb6Cuotas.Name = "rb6Cuotas";
            this.rb6Cuotas.Size = new System.Drawing.Size(80, 20);
            this.rb6Cuotas.TabIndex = 2;
            this.rb6Cuotas.Text = "6 Cuotas";
            this.rb6Cuotas.UseVisualStyleBackColor = true;
            this.rb6Cuotas.CheckedChanged += new System.EventHandler(this.rbCuotas_CheckedChanged);
            // 
            // rb3Cuotas
            // 
            this.rb3Cuotas.AutoSize = true;
            this.rb3Cuotas.Location = new System.Drawing.Point(5, 33);
            this.rb3Cuotas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb3Cuotas.Name = "rb3Cuotas";
            this.rb3Cuotas.Size = new System.Drawing.Size(80, 20);
            this.rb3Cuotas.TabIndex = 1;
            this.rb3Cuotas.Text = "3 Cuotas";
            this.rb3Cuotas.UseVisualStyleBackColor = true;
            this.rb3Cuotas.CheckedChanged += new System.EventHandler(this.rbCuotas_CheckedChanged);
            // 
            // rb1Pago
            // 
            this.rb1Pago.AutoSize = true;
            this.rb1Pago.Checked = true;
            this.rb1Pago.Location = new System.Drawing.Point(5, 4);
            this.rb1Pago.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb1Pago.Name = "rb1Pago";
            this.rb1Pago.Size = new System.Drawing.Size(71, 20);
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
            this.cmbMedioPago.Location = new System.Drawing.Point(176, 17);
            this.cmbMedioPago.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMedioPago.Name = "cmbMedioPago";
            this.cmbMedioPago.Size = new System.Drawing.Size(160, 24);
            this.cmbMedioPago.TabIndex = 1;
            this.cmbMedioPago.SelectedIndexChanged += new System.EventHandler(this.cmbMedioPago_SelectedIndexChanged);
            // 
            // lblMedioActividades
            // 
            this.lblMedioActividades.AutoSize = true;
            this.lblMedioActividades.Location = new System.Drawing.Point(66, 20);
            this.lblMedioActividades.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMedioActividades.Name = "lblMedioActividades";
            this.lblMedioActividades.Size = new System.Drawing.Size(102, 16);
            this.lblMedioActividades.TabIndex = 0;
            this.lblMedioActividades.Text = "Medio de pago:";
            // 
            // panelActividades
            // 
            this.panelActividades.BackColor = System.Drawing.Color.DarkGray;
            this.panelActividades.Controls.Add(this.lblMedio);
            this.panelActividades.Controls.Add(this.btnPasarIzquierda);
            this.panelActividades.Controls.Add(this.btnPasarDerecha);
            this.panelActividades.Controls.Add(this.lstSeleccionadas);
            this.panelActividades.Controls.Add(this.lstDisponibles);
            this.panelActividades.Controls.Add(this.lblTituloSelec);
            this.panelActividades.Controls.Add(this.lblTituloDisp);
            this.panelActividades.Controls.Add(this.lstMesesAdeudados);
            this.panelActividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActividades.Location = new System.Drawing.Point(0, 74);
            this.panelActividades.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelActividades.Name = "panelActividades";
            this.panelActividades.Size = new System.Drawing.Size(872, 333);
            this.panelActividades.TabIndex = 2;
            // 
            // lblMedio
            // 
            this.lblMedio.AutoSize = true;
            this.lblMedio.Location = new System.Drawing.Point(369, 20);
            this.lblMedio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMedio.Name = "lblMedio";
            this.lblMedio.Size = new System.Drawing.Size(130, 16);
            this.lblMedio.TabIndex = 8;
            this.lblMedio.Text = "Actividades/Deudas";
            this.lblMedio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPasarIzquierda
            // 
            this.btnPasarIzquierda.Location = new System.Drawing.Point(385, 158);
            this.btnPasarIzquierda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPasarIzquierda.Name = "btnPasarIzquierda";
            this.btnPasarIzquierda.Size = new System.Drawing.Size(33, 31);
            this.btnPasarIzquierda.TabIndex = 5;
            this.btnPasarIzquierda.Text = "<";
            this.btnPasarIzquierda.UseVisualStyleBackColor = true;
            this.btnPasarIzquierda.Click += new System.EventHandler(this.btnPasarIzquierda_Click);
            // 
            // btnPasarDerecha
            // 
            this.btnPasarDerecha.Location = new System.Drawing.Point(453, 158);
            this.btnPasarDerecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPasarDerecha.Name = "btnPasarDerecha";
            this.btnPasarDerecha.Size = new System.Drawing.Size(33, 31);
            this.btnPasarDerecha.TabIndex = 4;
            this.btnPasarDerecha.Text = ">";
            this.btnPasarDerecha.UseVisualStyleBackColor = true;
            this.btnPasarDerecha.Click += new System.EventHandler(this.btnPasarDerecha_Click);
            // 
            // lstSeleccionadas
            // 
            this.lstSeleccionadas.FormattingEnabled = true;
            this.lstSeleccionadas.ItemHeight = 16;
            this.lstSeleccionadas.Location = new System.Drawing.Point(536, 54);
            this.lstSeleccionadas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstSeleccionadas.Name = "lstSeleccionadas";
            this.lstSeleccionadas.Size = new System.Drawing.Size(265, 228);
            this.lstSeleccionadas.TabIndex = 3;
            // 
            // lstDisponibles
            // 
            this.lstDisponibles.FormattingEnabled = true;
            this.lstDisponibles.ItemHeight = 16;
            this.lstDisponibles.Location = new System.Drawing.Point(69, 54);
            this.lstDisponibles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstDisponibles.Name = "lstDisponibles";
            this.lstDisponibles.Size = new System.Drawing.Size(265, 228);
            this.lstDisponibles.TabIndex = 2;
            // 
            // lblTituloSelec
            // 
            this.lblTituloSelec.AutoSize = true;
            this.lblTituloSelec.Location = new System.Drawing.Point(617, 20);
            this.lblTituloSelec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloSelec.Name = "lblTituloSelec";
            this.lblTituloSelec.Size = new System.Drawing.Size(98, 16);
            this.lblTituloSelec.TabIndex = 1;
            this.lblTituloSelec.Text = "Seleccionadas";
            // 
            // lblTituloDisp
            // 
            this.lblTituloDisp.AutoSize = true;
            this.lblTituloDisp.Location = new System.Drawing.Point(152, 20);
            this.lblTituloDisp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloDisp.Name = "lblTituloDisp";
            this.lblTituloDisp.Size = new System.Drawing.Size(79, 16);
            this.lblTituloDisp.TabIndex = 0;
            this.lblTituloDisp.Text = "Disponibles";
            // 
            // lstMesesAdeudados
            // 
            this.lstMesesAdeudados.FormattingEnabled = true;
            this.lstMesesAdeudados.ItemHeight = 16;
            this.lstMesesAdeudados.Location = new System.Drawing.Point(195, 54);
            this.lstMesesAdeudados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstMesesAdeudados.Name = "lstMesesAdeudados";
            this.lstMesesAdeudados.Size = new System.Drawing.Size(492, 180);
            this.lstMesesAdeudados.TabIndex = 7;
            // 
            // lblInfoCliente
            // 
            this.lblInfoCliente.AutoSize = true;
            this.lblInfoCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.lblInfoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoCliente.Location = new System.Drawing.Point(65, 32);
            this.lblInfoCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoCliente.Name = "lblInfoCliente";
            this.lblInfoCliente.Size = new System.Drawing.Size(147, 20);
            this.lblInfoCliente.TabIndex = 0;
            this.lblInfoCliente.Text = "Datos del cliente...";
            // 
            // panelDatos
            // 
            this.panelDatos.BackColor = System.Drawing.Color.Gainsboro;
            this.panelDatos.Controls.Add(this.lblInfoCliente);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDatos.Location = new System.Drawing.Point(0, 0);
            this.panelDatos.Margin = new System.Windows.Forms.Padding(4);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(872, 74);
            this.panelDatos.TabIndex = 0;
            // 
            // GestionPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(872, 592);
            this.Controls.Add(this.panelActividades);
            this.Controls.Add(this.panelPago);
            this.Controls.Add(this.panelDatos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GestionPago";
            this.Text = "Gestion de pago";
            this.panelPago.ResumeLayout(false);
            this.panelPago.PerformLayout();
            this.panelCuotas.ResumeLayout(false);
            this.panelCuotas.PerformLayout();
            this.panelActividades.ResumeLayout(false);
            this.panelActividades.PerformLayout();
            this.panelDatos.ResumeLayout(false);
            this.panelDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Label lblInfoCliente;
        private System.Windows.Forms.Panel panelDatos;
    }
}