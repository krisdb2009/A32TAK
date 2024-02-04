namespace A32TAK
{
    public partial class MainWindow : Form
    {
        public UdpListener? UdpListener;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            UdpListener = new();
            UdpListener.ReceivedData += UdpListener_ReceivedData;
            Logger.Log("A32TAK Started.");
        }
        private void UdpListener_ReceivedData(object? sender, ReceivedDataArgs e)
        {
            Logger.Log("X: " + e.X + "Y: " + e.Y + "Z: " + e.Z, Color.Gray);
        }
    }
}