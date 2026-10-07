namespace Pantalla_De_Opciones
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(52, 61);
            button1.Name = "button1";
            button1.Size = new Size(204, 58);
            button1.TabIndex = 0;
            button1.Text = "Incribir Cliente";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.AccessibleRole = AccessibleRole.OutlineButton;
            button2.AutoSize = true;
            button2.Location = new Point(335, 61);
            button2.Name = "button2";
            button2.Size = new Size(204, 58);
            button2.TabIndex = 1;
            button2.Text = "Asignar Actividad";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.AccessibleRole = AccessibleRole.OutlineButton;
            button3.AutoSize = true;
            button3.Location = new Point(335, 186);
            button3.Name = "button3";
            button3.Size = new Size(204, 58);
            button3.TabIndex = 2;
            button3.Text = "Listar Vencimientos";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.AccessibleRole = AccessibleRole.OutlineButton;
            button4.AutoSize = true;
            button4.Location = new Point(52, 186);
            button4.Name = "button4";
            button4.Size = new Size(204, 58);
            button4.TabIndex = 3;
            button4.Text = "Pagar Cuota";
            button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
