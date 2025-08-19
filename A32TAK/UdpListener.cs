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
        public event EventHandler<ReceivedDataArgs>? ReceivedData;
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
                        JsonReceivedData jrd = JsonSerializer.Deserialize<JsonReceivedData>(
                            message,
                            JSO
                        );
                        ReceivedData?.Invoke(this, ParseJsonData(jrd));
                    }
                    catch
                    {
                        if (A32TAK.MainWindow.DebugMode)
                        {
                            Logger.Log("Recieved bad packet:", Color.Red);
                        }
                    }
                    if (A32TAK.MainWindow.DebugMode)
                    {
                        Logger.Log(message, Color.Gray);
                    }
                }
            });
        }
        public void ReloadSettings()
        {
            UdpClient.Client.Bind(_BindEndpoint);
        }
        private static ReceivedDataArgs ParseJsonData(JsonReceivedData JsonReceivedData) => new()
        {
            X = JsonReceivedData.Player.Position[0],
            Y = JsonReceivedData.Player.Position[1],
            Z = JsonReceivedData.Player.Position[2],
            Direction = JsonReceivedData.Player.Direction,
            Speed = JsonReceivedData.Player.Direction
        };
    }
    public struct JsonReceivedData
    {
        public JsonPlayer Player;
    }
    public struct JsonPlayer
    {
        public float[] Position;
        public float Speed;
        public float Direction;
    }
    public class ReceivedDataArgs : EventArgs
    {
        public float X;
        public float Y;
        public float Z;
        public float Direction;
        public float Speed;
    }
}