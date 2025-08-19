using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace A32TAK
{
    public class UdpListener
    {
        public uint Port
        {
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
        public event EventHandler<Game.Message>? ReceivedData;
        private readonly IPEndPoint _BindEndpoint = new(IPAddress.Loopback, 12345);
        private readonly JsonSerializerOptions JSO = new() { PropertyNameCaseInsensitive = true, IncludeFields = true };
        public UdpListener()
        {
            ReloadSettings();
            byte[] buffer = new byte[512];
            Task.Run(() =>
            {
                while (true)
                {
                    for (int i = 0; i < buffer.Length; i++) { buffer[i] = 0x00; }
                    UdpClient.Client.Receive(buffer);
                    string message = Encoding.ASCII.GetString(buffer, 0, buffer.Length).TrimEnd('\x00');
                    try
                    {
                        Game.Message gMessage = JsonSerializer.Deserialize<Game.Message>(
                            message,
                            JSO
                        );
                        if (A32TAK.MainWindow.DebugMode)
                        {
                            Logger.Log(message, Color.Aqua);
                        }
                        ReceivedData?.Invoke(this, gMessage);
                    }
                    catch
                    {
                        if (A32TAK.MainWindow.DebugMode)
                        {
                            Logger.Log("Bad JSON!", Color.Red);
                        }
                    }
                }
            });
        }
        public void ReloadSettings()
        {
            UdpClient.Client.Bind(_BindEndpoint);
        }
    }
}