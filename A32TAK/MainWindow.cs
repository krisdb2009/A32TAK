using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace A32TAK
{
    public partial class MainWindow : Form
    {
        public bool DebugMode = false;
        private readonly NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            foreach (MGRSProfile profile in MGRSProfiles.Profiles)
            {
                ToolStripMenuItem mi = new(profile.Name)
                {
                    Tag = profile
                };
                mi.Click += MiProfile_Click;
                tsmProfiles.DropDownItems.Add(mi);
            }
            foreach (NetworkInterface iface in Interfaces)
            {
                foreach (UnicastIPAddressInformation ip in iface.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily != AddressFamily.InterNetwork) continue;
                    cbBindAdapter.Items.Add(ip.Address.ToString() + ": " + iface.Name);
                }
            }
            cbBindAdapter.SelectedIndex = 0;
            A32TAK.UdpListener.ReceivedData += UdpListener_ReceivedData;
            Logger.Log("A32TAK Started.");
        }
        private void MiProfile_Click(object? sender, EventArgs e)
        {
            if (sender == null) return;
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            if (mi.Tag == null) return;
            MGRSProfile profile = (MGRSProfile)mi.Tag;
            tbUTMZone.Text = profile.UTMZone.ToString();
            tbLatitudeBand.Text = profile.LatitudeBand.ToString();
            tbGridSquare1.Text = profile.GridSquareFirst.ToString();
            tbGridSquare2.Text = profile.GridSquareSecond.ToString();
            tbGeoidHeight.Text = profile.GeoidHeight.ToString();
            btnSetTarget.PerformClick();
        }
        private void UdpListener_ReceivedData(object? sender, Game.Message e)
        {
            Task.Run(async () =>
            {
                Invoke(() => lblActivity.ForeColor = Color.LimeGreen);
                await Task.Delay(100);
                Invoke(() => lblActivity.ForeColor = Color.Gray);
            });
        }
        private void BtnSetTarget_Click(object sender, EventArgs e)
        {
            if (IPAddress.TryParse(cbBindAdapter.Text.Split(':')[0], out IPAddress? bind))
            {
                Logger.Log("Bind IP set to: " + bind.ToString() + '.', Color.Green);
                A32TAK.COTSender.BindAddress = bind;
            }
            else
            {
                Logger.Log("Could not parse bind IP address.", Color.Red);
            }
            if (IPEndPoint.TryParse(tbTargetIPAddresss.Text + ':' + tbTargetPort.Text, out IPEndPoint? target))
            {
                Logger.Log("Target set to: " + target.ToString() + '.', Color.Green);
                A32TAK.COTSender.UnicastTarget = target;
            }
            else
            {
                Logger.Log("Could not parse target IP address / port.", Color.Red);
            }
            if (uint.TryParse(tbUTMZone.Text, out uint utmZone))
            {
                Logger.Log("UTM zone set to: " + utmZone.ToString() + '.', Color.Green);
                A32TAK.COTSender.UTMZone = utmZone;
            }
            else
            {
                Logger.Log("Could not parse UTM zone.", Color.Red);
            }
            if (char.TryParse(tbLatitudeBand.Text, out char latitudeBand))
            {
                if (MGRSHelper.LatitudeBandRange.Contains(latitudeBand))
                {
                    Logger.Log("Latitude band set to: " + latitudeBand.ToString() + '.', Color.Green);
                    A32TAK.COTSender.LatitudeBand = latitudeBand;
                }
                else
                {
                    Logger.Log("Latitude band not valid.", Color.Red);
                }
            }
            else
            {
                Logger.Log("Could not parse latitude band.", Color.Red);
            }
            if (char.TryParse(tbGridSquare1.Text, out char gridSquare1) && char.TryParse(tbGridSquare2.Text, out char gridSquare2))
            {
                if (MGRSHelper.GridSquareFirstRange.Contains(gridSquare1) && MGRSHelper.GridSquareSecondRange.Contains(gridSquare2))
                {
                    Logger.Log("Grid square set to: " + gridSquare1.ToString() + gridSquare2.ToString() + '.', Color.Green);
                    A32TAK.COTSender.GridSquareFirst = gridSquare1;
                    A32TAK.COTSender.GridSquareSecond = gridSquare2;
                }
                else
                {
                    Logger.Log("Grid square not valid.", Color.Red);
                }
            }
            else
            {
                Logger.Log("Could not parse grid square.", Color.Red);
            }
            if (double.TryParse(tbGeoidHeight.Text, out double geoidHeight))
            {
                Logger.Log("Geoid Height set to: " + geoidHeight.ToString() + '.', Color.Green);
                A32TAK.COTSender.GeoidHeight = geoidHeight;
            }
            else
            {
                Logger.Log("Could not parse Geoid Height.", Color.Red);
            }
            A32TAK.COTSender.ManualDroneCallsign = tbDroneCallsign.Text;
            if (tbDroneCallsign.Text != string.Empty)
            {
                Logger.Log("Manual drone callsign set to: " + tbDroneCallsign.Text + '.', Color.Green);
                
            }
        }
        private void TsmClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void TsmAbout_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
        private void CbDebug_CheckedChanged(object sender, EventArgs e)
        {
            DebugMode = cbDebug.Checked;
        }
        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            Logger.Clear();
        }
    }
}