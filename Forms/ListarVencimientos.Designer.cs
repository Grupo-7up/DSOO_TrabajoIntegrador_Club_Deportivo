namespace TrabajoIntegrador
{
    partial class ListarVencimientos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFechaConsulta = new System.Windows.Forms.Label();
            this.lblFechaVerificar = new System.Windows.Forms.Label();
            this.dtpFechaVerificar = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lstVencimientos = new System.Windows.Forms.ListBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(27, 28);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(213, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Socios con cuota vencida";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // lblFechaConsulta
            // 
            this.lblFechaConsulta.AutoSize = true;
            this.lblFechaConsulta.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblFechaConsulta.Location = new System.Drawing.Point(413, 449);
            this.lblFechaConsulta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaConsulta.Name = "lblFechaConsulta";
            this.lblFechaConsulta.Size = new System.Drawing.Size(200, 16);
            this.lblFechaConsulta.TabIndex = 1;
            this.lblFechaConsulta.Text = "Consulta realizada el: --/--/---- --:--";
            // 
            // lblFechaVerificar
            // 
            this.lblFechaVerificar.AutoSize = true;
            this.lblFechaVerificar.Location = new System.Drawing.Point(28, 67);
            this.lblFechaVerificar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaVerificar.Name = "lblFechaVerificar";
            this.lblFechaVerificar.Size = new System.Drawing.Size(109, 16);
            this.lblFechaVerificar.TabIndex = 2;
            this.lblFechaVerificar.Text = "Fecha a verificar:";
            // 
            // dtpFechaVerificar
            // 
            this.dtpFechaVerificar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVerificar.Location = new System.Drawing.Point(153, 64);
            this.dtpFechaVerificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechaVerificar.Name = "dtpFechaVerificar";
            this.dtpFechaVerificar.Size = new System.Drawing.Size(172, 22);
            this.dtpFechaVerificar.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(351, 64);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(133, 22);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lstVencimientos
            // 
            this.lstVencimientos.FormattingEnabled = true;
            this.lstVencimientos.ItemHeight = 16;
            this.lstVencimientos.Location = new System.Drawing.Point(27, 103);
            this.lstVencimientos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstVencimientos.Name = "lstVencimientos";
            this.lstVencimientos.Size = new System.Drawing.Size(612, 308);
            this.lstVencimientos.TabIndex = 5;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(27, 436);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(133, 43);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // ListarVencimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 505);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lstVencimientos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpFechaVerificar);
            this.Controls.Add(this.lblFechaVerificar);
            this.Controls.Add(this.lblFechaConsulta);
            this.Controls.Add(this.lblTitulo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListarVencimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listar vencimientos";
            this.Load += new System.EventHandler(this.ListarVencimientos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFechaConsulta;
        private System.Windows.Forms.Label lblFechaVerificar;
        private System.Windows.Forms.DateTimePicker dtpFechaVerificar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ListBox lstVencimientos;
        private System.Windows.Forms.Button btnVolver;
    }
}
