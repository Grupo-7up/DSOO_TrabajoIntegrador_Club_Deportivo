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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfoCliente = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMedioPago = new System.Windows.Forms.ComboBox();
            this.panelCuotas = new System.Windows.Forms.Panel();
            this.rb1Pago = new System.Windows.Forms.RadioButton();
            this.rb3Cuotas = new System.Windows.Forms.RadioButton();
            this.rb6Cuotas = new System.Windows.Forms.RadioButton();
            this.lblTotalTexto = new System.Windows.Forms.Label();
            this.lblMontoValor = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTituloDisp = new System.Windows.Forms.Label();
            this.lblTituloSelec = new System.Windows.Forms.Label();
            this.lstDisponibles = new System.Windows.Forms.ListBox();
            this.lstSeleccionadas = new System.Windows.Forms.ListBox();
            this.btnPasarDerecha = new System.Windows.Forms.Button();
            this.btnPasarIzquierda = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTipoCliente = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblNumDoc = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTipoCliente = new System.Windows.Forms.TextBox();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelCuotas.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.txtNumDoc);
            this.panel1.Controls.Add(this.txtTipoDoc);
            this.panel1.Controls.Add(this.txtTipoCliente);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.lblNumDoc);
            this.panel1.Controls.Add(this.lblTipoDoc);
            this.panel1.Controls.Add(this.lblTipoCliente);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblInfoCliente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblInfoCliente
            // 
            this.lblInfoCliente.AutoSize = true;
            this.lblInfoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoCliente.Location = new System.Drawing.Point(49, 9);
            this.lblInfoCliente.Name = "lblInfoCliente";
            this.lblInfoCliente.Size = new System.Drawing.Size(125, 17);
            this.lblInfoCliente.TabIndex = 0;
            this.lblInfoCliente.Text = "Datos del cliente...";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Controls.Add(this.lblMontoValor);
            this.panel2.Controls.Add(this.lblTotalTexto);
            this.panel2.Controls.Add(this.panelCuotas);
            this.panel2.Controls.Add(this.cmbMedioPago);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 331);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 150);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Medio de Pago:";
            // 
            // cmbMedioPago
            // 
            this.cmbMedioPago.FormattingEnabled = true;
            this.cmbMedioPago.Items.AddRange(new object[] {
            "Efectivo",
            "Transferencia",
            "Tarjeta de Crédito"});
            this.cmbMedioPago.Location = new System.Drawing.Point(141, 4);
            this.cmbMedioPago.Name = "cmbMedioPago";
            this.cmbMedioPago.Size = new System.Drawing.Size(121, 21);
            this.cmbMedioPago.TabIndex = 1;
            // 
            // panelCuotas
            // 
            this.panelCuotas.Controls.Add(this.rb6Cuotas);
            this.panelCuotas.Controls.Add(this.rb3Cuotas);
            this.panelCuotas.Controls.Add(this.rb1Pago);
            this.panelCuotas.Location = new System.Drawing.Point(268, 4);
            this.panelCuotas.Name = "panelCuotas";
            this.panelCuotas.Size = new System.Drawing.Size(78, 77);
            this.panelCuotas.TabIndex = 2;
            this.panelCuotas.Visible = false;
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
            // rb3Cuotas
            // 
            this.rb3Cuotas.AutoSize = true;
            this.rb3Cuotas.Location = new System.Drawing.Point(4, 27);
            this.rb3Cuotas.Name = "rb3Cuotas";
            this.rb3Cuotas.Size = new System.Drawing.Size(67, 17);
            this.rb3Cuotas.TabIndex = 1;
            this.rb3Cuotas.Text = "3 Cuotas";
            this.rb3Cuotas.UseVisualStyleBackColor = true;
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
            // 
            // lblTotalTexto
            // 
            this.lblTotalTexto.AutoSize = true;
            this.lblTotalTexto.Location = new System.Drawing.Point(415, 33);
            this.lblTotalTexto.Name = "lblTotalTexto";
            this.lblTotalTexto.Size = new System.Drawing.Size(95, 13);
            this.lblTotalTexto.TabIndex = 3;
            this.lblTotalTexto.Text = "TOTAL A PAGAR:";
            // 
            // lblMontoValor
            // 
            this.lblMontoValor.AutoSize = true;
            this.lblMontoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoValor.Location = new System.Drawing.Point(516, 25);
            this.lblMontoValor.Name = "lblMontoValor";
            this.lblMontoValor.Size = new System.Drawing.Size(60, 24);
            this.lblMontoValor.TabIndex = 4;
            this.lblMontoValor.Text = "$ 0.00";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(391, 75);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(95, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Confirmar Pago";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(520, 74);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Controls.Add(this.btnPasarIzquierda);
            this.panel3.Controls.Add(this.btnPasarDerecha);
            this.panel3.Controls.Add(this.lstSeleccionadas);
            this.panel3.Controls.Add(this.lstDisponibles);
            this.panel3.Controls.Add(this.lblTituloSelec);
            this.panel3.Controls.Add(this.lblTituloDisp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(634, 271);
            this.panel3.TabIndex = 2;
            // 
            // lblTituloDisp
            // 
            this.lblTituloDisp.AutoSize = true;
            this.lblTituloDisp.Location = new System.Drawing.Point(89, 16);
            this.lblTituloDisp.Name = "lblTituloDisp";
            this.lblTituloDisp.Size = new System.Drawing.Size(119, 13);
            this.lblTituloDisp.TabIndex = 0;
            this.lblTituloDisp.Text = "Actividades Disponibles";
            // 
            // lblTituloSelec
            // 
            this.lblTituloSelec.AutoSize = true;
            this.lblTituloSelec.Location = new System.Drawing.Point(418, 16);
            this.lblTituloSelec.Name = "lblTituloSelec";
            this.lblTituloSelec.Size = new System.Drawing.Size(135, 13);
            this.lblTituloSelec.TabIndex = 1;
            this.lblTituloSelec.Text = "Actividades Seleccionadas";
            // 
            // lstDisponibles
            // 
            this.lstDisponibles.FormattingEnabled = true;
            this.lstDisponibles.Location = new System.Drawing.Point(52, 44);
            this.lstDisponibles.Name = "lstDisponibles";
            this.lstDisponibles.Size = new System.Drawing.Size(200, 186);
            this.lstDisponibles.TabIndex = 2;
            // 
            // lstSeleccionadas
            // 
            this.lstSeleccionadas.FormattingEnabled = true;
            this.lstSeleccionadas.Location = new System.Drawing.Point(385, 44);
            this.lstSeleccionadas.Name = "lstSeleccionadas";
            this.lstSeleccionadas.Size = new System.Drawing.Size(200, 186);
            this.lstSeleccionadas.TabIndex = 3;
            // 
            // btnPasarDerecha
            // 
            this.btnPasarDerecha.Location = new System.Drawing.Point(329, 124);
            this.btnPasarDerecha.Name = "btnPasarDerecha";
            this.btnPasarDerecha.Size = new System.Drawing.Size(25, 25);
            this.btnPasarDerecha.TabIndex = 4;
            this.btnPasarDerecha.Text = ">";
            this.btnPasarDerecha.UseVisualStyleBackColor = true;
            // 
            // btnPasarIzquierda
            // 
            this.btnPasarIzquierda.Location = new System.Drawing.Point(289, 124);
            this.btnPasarIzquierda.Name = "btnPasarIzquierda";
            this.btnPasarIzquierda.Size = new System.Drawing.Size(25, 25);
            this.btnPasarIzquierda.TabIndex = 5;
            this.btnPasarIzquierda.Text = "<";
            this.btnPasarIzquierda.UseVisualStyleBackColor = true;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(23, 35);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.AutoSize = true;
            this.lblTipoCliente.Location = new System.Drawing.Point(215, 35);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new System.Drawing.Size(37, 13);
            this.lblTipoCliente.TabIndex = 2;
            this.lblTipoCliente.Text = "Socio:";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(326, 35);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(54, 13);
            this.lblTipoDoc.TabIndex = 3;
            this.lblTipoDoc.Text = "Tipo Doc:";
            // 
            // lblNumDoc
            // 
            this.lblNumDoc.AutoSize = true;
            this.lblNumDoc.Location = new System.Drawing.Point(455, 35);
            this.lblNumDoc.Name = "lblNumDoc";
            this.lblNumDoc.Size = new System.Drawing.Size(55, 13);
            this.lblNumDoc.TabIndex = 4;
            this.lblNumDoc.Text = "Num Doc:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(74, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(134, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Location = new System.Drawing.Point(258, 32);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.ReadOnly = true;
            this.txtTipoCliente.Size = new System.Drawing.Size(32, 20);
            this.txtTipoCliente.TabIndex = 6;
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.Location = new System.Drawing.Point(380, 32);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.ReadOnly = true;
            this.txtTipoDoc.Size = new System.Drawing.Size(69, 20);
            this.txtTipoDoc.TabIndex = 7;
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Location = new System.Drawing.Point(516, 32);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.ReadOnly = true;
            this.txtNumDoc.Size = new System.Drawing.Size(100, 20);
            this.txtNumDoc.TabIndex = 8;
            // 
            // GestionPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 481);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GestionPago";
            this.Text = "GestionPago";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelCuotas.ResumeLayout(false);
            this.panelCuotas.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInfoCliente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbMedioPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMontoValor;
        private System.Windows.Forms.Label lblTotalTexto;
        private System.Windows.Forms.Panel panelCuotas;
        private System.Windows.Forms.RadioButton rb6Cuotas;
        private System.Windows.Forms.RadioButton rb3Cuotas;
        private System.Windows.Forms.RadioButton rb1Pago;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPasarDerecha;
        private System.Windows.Forms.ListBox lstSeleccionadas;
        private System.Windows.Forms.ListBox lstDisponibles;
        private System.Windows.Forms.Label lblTituloSelec;
        private System.Windows.Forms.Label lblTituloDisp;
        private System.Windows.Forms.Button btnPasarIzquierda;
        private System.Windows.Forms.TextBox txtTipoCliente;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNumDoc;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblTipoCliente;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.TextBox txtTipoDoc;
    }
}