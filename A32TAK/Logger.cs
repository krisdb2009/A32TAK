namespace A32TAK
{
    public static class Logger
    {
        public static void Log(string Message, Color? MessageColor = null)
        {
            A32TAK.MainWindow.Invoke(() =>
            {
                if (MessageColor == null)
                {
                    A32TAK.MainWindow.rtbLogs.SelectionColor = Color.White;
                }
                else
                {
                    A32TAK.MainWindow.rtbLogs.SelectionColor = (Color)MessageColor;
                }
                A32TAK.MainWindow.rtbLogs.AppendText(Message + "\r\n");
                A32TAK.MainWindow.rtbLogs.ScrollToCaret();
            });
        }
    }
}