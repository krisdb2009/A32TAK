using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;

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
            byte[] buffer = new byte[512];
            Task.Run(() => {
                while (true)
                {
                    UdpClient.Client.Receive(buffer);
                    string message = Encoding.ASCII.GetString(buffer, 0, buffer.Length).TrimEnd('\x00');
                    try
                    {
                        JsonReceivedData jrd = JsonSerializer.Deserialize<JsonReceivedData>(
                            message, 
                            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, IncludeFields = true }
                        );
                        ReceivedData?.Invoke(this, ParseJsonData(jrd));
                    }
                    catch
                    {
                        continue;
                    }
                }
            });
        }
        public void ReloadSettings()
        {
            UdpClient.Client.Bind(_BindEndpoint);
        }
        private ReceivedDataArgs ParseJsonData(JsonReceivedData JsonReceivedData)
        {
            return new()
            {
                X = JsonReceivedData.POS[0],
                Y = JsonReceivedData.POS[1],
                Z = JsonReceivedData.POS[2],
                Direction = JsonReceivedData.DIR,
                Speed = JsonReceivedData.Speed
            };
        }
    }
    public struct JsonReceivedData
    {
        public float[] POS;
        public float DIR;
        public float Speed;
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