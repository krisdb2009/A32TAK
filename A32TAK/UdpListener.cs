using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace A32TAK
{
    public class UdpListener
    {
        public uint Port { 
            get
            {
                return (uint)_BindEndpoint.Port;
            }
            set
            {
                _BindEndpoint.Port = (int)value;
                ReloadSettings();
            }
        }
        public UdpClient UdpClient = new();
        public event EventHandler<ReceivedDataArgs>? ReceivedData;
        private IPEndPoint _BindEndpoint = new(IPAddress.Loopback, 12345);
        public UdpListener()
        {
            ReloadSettings();
            byte[] buffer = new byte[256];
            Task.Run(() => {
                while (true)
                {
                    UdpClient.Client.Receive(buffer);
                    string message = Encoding.ASCII.GetString(buffer, 0, buffer.Length).TrimEnd('\x00');
                    if (Regex.IsMatch(message, "^([0-9.]*,){2}[0-9.]*$"))
                    {
                        string[] parts = message.Split(',');
                        ReceivedDataArgs args = new()
                        {
                            X = float.Parse(parts[0]),
                            Y = float.Parse(parts[1]),
                            Z = float.Parse(parts[2])
                        };
                        ReceivedData?.Invoke(this, args);
                    }
                    else
                    {
                        Logger.Log("Received invalid packet.", Color.Red);
                        Logger.Log("Got: " + message, Color.Red);
                    }
                }
            });
        } 
        public void ReloadSettings()
        {
            UdpClient.Client.Bind(_BindEndpoint);
        }
    }
    public class ReceivedDataArgs : EventArgs
    {
        public float X;
        public float Y;
        public float Z;
    }
}