namespace Pilipala.FlightSimulator.ExtensionMethods
{
    public static class RectangleExtensions
    {
        public static int Height(this IRectangle rectangle)
        {
            return rectangle.Y2 - rectangle.Y1 + 1;
        }

        public static int Width(this IRectangle rectangle)
        {
            return rectangle.X2 - rectangle.X1 + 1;
        }
    }
}
