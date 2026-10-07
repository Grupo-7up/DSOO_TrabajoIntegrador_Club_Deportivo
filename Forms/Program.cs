namespace ClubDeportivo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var login = new LoginPractica.Form1())
            {
                if (login.ShowDialog() != DialogResult.OK)
                    return;
            }

            Application.Run(new Pantalla_De_Opciones.Form1());
        }
    }
}