namespace A32TAK
{
    public static class A32TAK
    {
        public static MainWindow MainWindow { get; } = new();
        public static UdpListener UdpListener { get; } = new();
        public static COTSender COTSender { get; } = new();
        [STAThread]
        static void Main()
        {
            Application.Run(MainWindow);
        }
    }
}