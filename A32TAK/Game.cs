namespace A32TAK.Game
{
    public struct Message
    {
        public Player Player;
        public Drone? Drone;
        public float[]? Laser_Position;
    }
    public struct Player
    {
        public float[] Position;
        public float Speed;
        public float Direction;
    }
    public struct Drone
    {
        public string Name;
        public float[] Position;
        public float Speed;
        public float Direction;
    }
}