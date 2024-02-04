namespace A32TAK
{
    public static class A32TAK
    {
        public static MainWindow MainWindow = new MainWindow();
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(MainWindow);
        }
    }
}