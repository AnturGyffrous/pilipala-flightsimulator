using System;
using System.Collections.Generic;
using System.Linq;

using Pilipala.FlightSimulator.ExtensionMethods;

namespace Pilipala.FlightSimulator
{
    public class Quadtree
    {
        private const int _maxItems = 10;

        private Rectangle _bounds0;

        private Rectangle _bounds1;

        private Rectangle _bounds2;

        private Rectangle _bounds3;

        private bool _hasSplit;

        public Quadtree(Rectangle bounds)
        {
            Bounds = bounds;
            Items = new List<IRectangle>();
            Nodes = new Quadtree[4];
        }

        public Rectangle Bounds { get; private set; }

        public List<IRectangle> Items { get; private set; }

        public Quadtree[] Nodes { get; private set; }

        public void Add(IRectangle item)
        {
            if (_hasSplit)
            {
                var index = GetIndex(item);
                if (index != -1)
                {
                    Nodes[index].Add(item);
                    return;
                }
            }

            Items.Add(item);
            if (!_hasSplit && Items.Count > _maxItems)
            {
                Split();
            }
        }

        public List<IRectangle> GetItemsNear(Rectangle location)
        {
            if (!_hasSplit)
            {
                return Items;
            }

            var index = GetIndex(location);
            return index == -1
                       ? Items
                       : Items.Union(Nodes[index].GetItemsNear(location)).ToList();
        }

        private void CreateQuadrants()
        {
            var horizontalMidpoint = (int)Math.Floor((double)Bounds.Width() / 2) + Bounds.X1;
            var verticalMidpoint = (int)Math.Floor((double)Bounds.Height() / 2) + Bounds.Y1;
            _bounds0 = new Rectangle { X1 = horizontalMidpoint, X2 = Bounds.X2, Y1 = Bounds.Y1, Y2 = verticalMidpoint };
            _bounds1 = new Rectangle { X1 = Bounds.X1, X2 = horizontalMidpoint, Y1 = Bounds.Y1, Y2 = verticalMidpoint };
            _bounds2 = new Rectangle { X1 = Bounds.X1, X2 = horizontalMidpoint, Y1 = verticalMidpoint, Y2 = Bounds.Y2 };
            _bounds3 = new Rectangle { X1 = horizontalMidpoint, X2 = Bounds.X2, Y1 = verticalMidpoint, Y2 = Bounds.Y2 };
            Nodes[0] = new Quadtree(_bounds0);
            Nodes[1] = new Quadtree(_bounds1);
            Nodes[2] = new Quadtree(_bounds2);
            Nodes[3] = new Quadtree(_bounds3);
        }

        private int GetIndex(IRectangle bounds)
        {
            if (bounds.Y2 <= _bounds0.Y2)
            {
                if (bounds.X1 >= _bounds0.X1)
                {
                    return 0;
                }

                if (bounds.X2 <= _bounds0.X1)
                {
                    return 1;
                }
            }
            else if (bounds.Y1 >= _bounds0.Y2)
            {
                if (bounds.X2 <= _bounds0.X1)
                {
                    return 2;
                }

                if (bounds.X1 >= _bounds0.X1)
                {
                    return 3;
                }
            }

            return -1;
        }

        private void Redistribute()
        {
            var exclude = new List<IRectangle>();
            foreach (var item in Items)
            {
                var index = GetIndex(item);
                if (index != -1)
                {
                    exclude.Add(item);
                    Nodes[index].Add(item);
                }
            }

            Items = Items.Except(exclude).ToList();
        }

        private void Split()
        {
            _hasSplit = true;
            CreateQuadrants();
            Redistribute();
        }
    }
}
