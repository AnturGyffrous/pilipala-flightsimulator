using System;
using System.Diagnostics;

using NUnit.Framework;

namespace Pilipala.FlightSimulator.Tests
{
    [TestFixture]
    public class QuadtreeTests
    {
        [Test]
        public void CanCreateQuadTree()
        {
            var bounds = new Rectangle { X1 = 0, X2 = 100, Y1 = 0, Y2 = 100 };
            var quadtree = new Quadtree(bounds);
            Assert.That(quadtree.Bounds, Is.EqualTo(bounds));
            Assert.That(quadtree.Level, Is.EqualTo(0));
        }

        [Test]
        public void CanAddItemToQuadtree()
        {
            var quadtree = new Quadtree(new Rectangle { X1 = 0, X2 = 100, Y1 = 0, Y2 = 100 });
            var item1 = new Rectangle { X1 = 10, X2 = 20, Y1 = 10, Y2 = 20 };
            quadtree.Add(item1);
            Assert.That(quadtree.Items, Has.Member(item1));
        }

        [Test]
        public void CanCreateRandomCoordinates()
        {
            var random = new Random();
            for (int i = 0; i < 11; i++)
            {
                var x1 = random.Next(0, 21);
                int x2;
                while ((x2 = random.Next(0, 21)) == x1)
                {
                }

                var y1 = random.Next(0, 21);
                int y2;
                while ((y2 = random.Next(0, 21)) == y1)
                {
                }

                if (x1 > x2)
                {
                    Swap(ref x1, ref x2);
                }

                if (y1 > y2)
                {
                    Swap(ref y1, ref y2);
                }

                Debug.Print("X1 = {0}, X2 = {1}, Y1 = {2}, Y2 = {3}", x1 * 5, x2 * 5, y1 * 5, y2 * 5);
            }
        }

        private static void Swap(ref int y1, ref int y2)
        {
            y1 ^= y2;
            y2 ^= y1;
            y1 ^= y2;
        }

        [Test]
        public void QuadTreeWillSplitAfterAddingMoreThanTenItemsToIt()
        {
            var quadtree = new Quadtree(new Rectangle { X1 = 0, X2 = 100, Y1 = 0, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 80, X2 = 100, Y1 = 75, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 0, X2 = 35, Y1 = 10, Y2 = 30 });
            quadtree.Add(new Rectangle { X1 = 15, X2 = 50, Y1 = 30, Y2 = 45 });
            quadtree.Add(new Rectangle { X1 = 55, X2 = 100, Y1 = 30, Y2 = 75 });
            quadtree.Add(new Rectangle { X1 = 15, X2 = 100, Y1 = 40, Y2 = 95 });
            quadtree.Add(new Rectangle { X1 = 65, X2 = 100, Y1 = 50, Y2 = 85 });
            quadtree.Add(new Rectangle { X1 = 0, X2 = 90, Y1 = 50, Y2 = 55 });
            quadtree.Add(new Rectangle { X1 = 80, X2 = 100, Y1 = 10, Y2 = 20 });
            quadtree.Add(new Rectangle { X1 = 60, X2 = 85, Y1 = 25, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 0, X2 = 65, Y1 = 30, Y2 = 55 });
            quadtree.Add(new Rectangle { X1 = 30, X2 = 40, Y1 = 25, Y2 = 95 });
        }
    }
}
