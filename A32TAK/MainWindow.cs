using System.Net;

namespace A32TAK
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            A32TAK.UdpListener.ReceivedData += UdpListener_ReceivedData;
            Logger.Log("A32TAK Started.");
        }
        private void UdpListener_ReceivedData(object? sender, ReceivedDataArgs e)
        {
            Logger.Log("X: " + e.X + " Y: " + e.Y + " Z: " + e.Z, Color.Gray);
        }
        private void btnSetTarget_Click(object sender, EventArgs e)
        {
            if (IPEndPoint.TryParse(tbTargetIPAddresss.Text, out IPEndPoint? target))
            {
                Logger.Log("Target set to: " + target.ToString(), Color.Green);
            }
            A32TAK.NMEASender.Target = target;
        }
    }
}