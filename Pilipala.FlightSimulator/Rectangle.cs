namespace Pilipala.FlightSimulator
{
    public struct Rectangle : IRectangle
    {
        public int X1 { get; set; }

        public int X2 { get; set; }

        public int Y1 { get; set; }

        public int Y2 { get; set; }

        public override string ToString()
        {
            return string.Format("X1 = {0}, Y1 = {1}, X2 = {2}, Y2 = {3}", X1, Y1, X2, Y2);
        }
    }
}
