namespace A32TAK
{
    public static class A32TAK
    {
        public static MainWindow MainWindow = new();
        public static UdpListener UdpListener = new();
        public static COTSender NMEASender = new();
        [STAThread]
        static void Main()
        {
            Application.Run(MainWindow);
        }
    }
}