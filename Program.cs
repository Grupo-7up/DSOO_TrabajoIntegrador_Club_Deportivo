using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoIntegrador.Clases;

namespace TrabajoIntegrador
{
    internal static class Program
    {
        // Instancia única y global del Club para toda la aplicación
        public static Club MiClub { get; private set; } = new Club();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DatabaseInitializer.InicializarBaseDeDatos();

            Application.Run(new Login());
        }
    }

}