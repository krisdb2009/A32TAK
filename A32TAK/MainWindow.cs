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
            foreach (MGRSProfile profile in MGRSProfiles.Profiles)
            {
                ToolStripMenuItem mi = new(profile.Name);
                mi.Tag = profile;
                mi.Click += MiProfile_Click;
                tsmProfiles.DropDownItems.Add(mi);
            }
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
        private void UdpListener_ReceivedData(object? sender, ReceivedDataArgs e)
        {
            Task.Run(async () =>
            {
                Invoke(() => lblActivity.ForeColor = Color.LimeGreen);
                await Task.Delay(100);
                Invoke(() => lblActivity.ForeColor = Color.Gray);
            });
        }
        private void btnSetTarget_Click(object sender, EventArgs e)
        {
            if (IPEndPoint.TryParse(tbTargetIPAddresss.Text + ':' + tbTargetPort.Text, out IPEndPoint? target))
            {
                Logger.Log("Target set to: " + target.ToString() + '.', Color.Green);
                A32TAK.COTSender.Target = target;
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
        }
        private void tsmClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void tsmAbout_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
    }
}