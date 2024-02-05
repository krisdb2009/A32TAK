namespace A32TAK
{
    public class Math
    {
        public event EventHandler<MathDoneEventArgs>? MathDone;
        public Math()
        {
            A32TAK.UdpListener.ReceivedData += Instance_ReceivedData;
        }
        private void Instance_ReceivedData(object? sender, ReceivedDataArgs e)
        {








            // do math








            MathDoneEventArgs data = new()
            {
                X = e.X,
                Y = e.Y,
                Z = e.Z
            };
            MathDone?.Invoke(this, data);
        }
    }
    public class MathDoneEventArgs : EventArgs
    {
        public float X;
        public float Y;
        public float Z;
    }
}
