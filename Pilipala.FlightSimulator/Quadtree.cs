using System.Collections.Generic;

namespace Pilipala.FlightSimulator
{
    public class Quadtree
    {
        public Rectangle Bounds { get; set; }

        public int Level { get; set; }

        public List<Rectangle> Items { get; set; }

        public Quadtree(Rectangle bounds)
        {
            Bounds = bounds;
            Items = new List<Rectangle>();
        }

        public void Add(Rectangle item)
        {
            Items.Add(item);
        }
    }
}