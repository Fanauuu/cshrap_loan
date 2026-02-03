namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // Optional: Migrate default admin password on first run
            // Uncomment the line below to hash the default admin password
            // After first run, comment it again to avoid re-hashing
            // PasswordMigrationTool.MigrateDefaultAdmin();
            
            Application.Run(new ModernLoginForm());
        }
    }
}