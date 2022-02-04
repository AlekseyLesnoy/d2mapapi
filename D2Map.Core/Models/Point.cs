namespace D2Map.Core.Models
{
    public struct Point
    {
        public Point(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        public uint X { get; set; }

        public uint Y { get; set; }

        public PointX ToPointX()
        {
            return new PointX {X = (int) X, Y = (int) Y};
        }
    }

    public struct PointX
    {
        public PointX(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
