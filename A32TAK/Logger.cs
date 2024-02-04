namespace A32TAK
{
    public static class Logger
    {
        public static void Log(string Message, Color? MessageColor = null)
        {
            if (MessageColor == null)
            {
                A32TAK.MainWindow.rtbLogs.ForeColor = Color.White;
            }
            else
            {
                A32TAK.MainWindow.rtbLogs.ForeColor = (Color)MessageColor;
            }
            A32TAK.MainWindow.rtbLogs.Text += Message + "\r\n";
        }
    }
}