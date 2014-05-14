using System;
using System.Diagnostics;

using NUnit.Framework;

namespace Pilipala.FlightSimulator.Tests
{
    [TestFixture]
    public class QuadtreeTests
    {
        [Test]
        public void CanAddItemToQuadtree()
        {
            var quadtree = new Quadtree(new Rectangle { X1 = 0, X2 = 100, Y1 = 0, Y2 = 100 });
            var item1 = new Rectangle { X1 = 10, X2 = 20, Y1 = 10, Y2 = 20 };
            quadtree.Add(item1);
            Assert.That(quadtree.Items, Has.Member(item1));
        }

        [Test]
        public void CanCreateQuadTree()
        {
            var bounds = new Rectangle { X1 = 0, X2 = 100, Y1 = 0, Y2 = 100 };
            var quadtree = new Quadtree(bounds);
            Assert.That(quadtree.Bounds, Is.EqualTo(bounds));
        }

        [Test]
        public void CanCreateRandomCoordinates()
        {
            var random = new Random();
            for (var i = 0; i < 11; i++)
            {
                var x1 = random.Next(0, 100);
                var x2 = random.Next(
                    x1 + 1, 
                    x1 + 50 > 100
                        ? 101
                        : x1 + 50);

                var y1 = random.Next(0, 100);
                var y2 = random.Next(
                    y1 + 1, 
                    y1 + 50 > 100
                        ? 101
                        : y1 + 50);

                Debug.Print("X1 = {0}, X2 = {1}, Y1 = {2}, Y2 = {3}", x1, x2, y1, y2);
            }
        }

        [Test]
        public void CanGetAllItemsThatCouldBeNearSpecifiedRectangle()
        {
            var quadtree = new Quadtree(new Rectangle { X1 = 0, X2 = 100, Y1 = 0, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 11, X2 = 13, Y1 = 99, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 72, X2 = 78, Y1 = 42, Y2 = 47 });
            quadtree.Add(new Rectangle { X1 = 18, X2 = 23, Y1 = 27, Y2 = 39 });
            quadtree.Add(new Rectangle { X1 = 80, X2 = 89, Y1 = 15, Y2 = 34 });
            quadtree.Add(new Rectangle { X1 = 66, X2 = 87, Y1 = 42, Y2 = 90 });
            quadtree.Add(new Rectangle { X1 = 70, X2 = 74, Y1 = 45, Y2 = 48 });
            quadtree.Add(new Rectangle { X1 = 86, X2 = 100, Y1 = 84, Y2 = 86 });
            quadtree.Add(new Rectangle { X1 = 56, X2 = 75, Y1 = 31, Y2 = 32 });
            quadtree.Add(new Rectangle { X1 = 29, X2 = 76, Y1 = 6, Y2 = 17 });
            quadtree.Add(new Rectangle { X1 = 85, X2 = 94, Y1 = 36, Y2 = 49 });
            quadtree.Add(new Rectangle { X1 = 61, X2 = 75, Y1 = 99, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 73, X2 = 76, Y1 = 2, Y2 = 11 });
            quadtree.Add(new Rectangle { X1 = 74, X2 = 100, Y1 = 19, Y2 = 27 });
            quadtree.Add(new Rectangle { X1 = 59, X2 = 68, Y1 = 15, Y2 = 24 });
            quadtree.Add(new Rectangle { X1 = 31, X2 = 45, Y1 = 48, Y2 = 70 });
            quadtree.Add(new Rectangle { X1 = 86, X2 = 96, Y1 = 28, Y2 = 45 });
            quadtree.Add(new Rectangle { X1 = 19, X2 = 50, Y1 = 0, Y2 = 27 });
            quadtree.Add(new Rectangle { X1 = 91, X2 = 95, Y1 = 27, Y2 = 49 });
            quadtree.Add(new Rectangle { X1 = 29, X2 = 49, Y1 = 69, Y2 = 74 });
            quadtree.Add(new Rectangle { X1 = 81, X2 = 90, Y1 = 49, Y2 = 50 });
            quadtree.Add(new Rectangle { X1 = 39, X2 = 54, Y1 = 68, Y2 = 98 });

            Assert.That(quadtree.Items.Count, Is.EqualTo(4));
            Assert.That(quadtree.Nodes[0].Items.Count, Is.EqualTo(4));
            Assert.That(quadtree.Nodes[1].Items.Count, Is.EqualTo(2));
            Assert.That(quadtree.Nodes[2].Items.Count, Is.EqualTo(2));
            Assert.That(quadtree.Nodes[3].Items.Count, Is.EqualTo(2));

            Assert.That(quadtree.Nodes[0].Nodes[0], Is.Not.Null);
            Assert.That(quadtree.Nodes[0].Nodes[0].Items.Count, Is.EqualTo(0));
            Assert.That(quadtree.Nodes[0].Nodes[1].Items.Count, Is.EqualTo(1));
            Assert.That(quadtree.Nodes[0].Nodes[2].Items.Count, Is.EqualTo(2));
            Assert.That(quadtree.Nodes[0].Nodes[3].Items.Count, Is.EqualTo(4));

            var items = quadtree.GetItemsNear(new Rectangle { X1 = 62, X2 = 62, Y1 = 34, Y2 = 34 });

            Assert.That(items.Count, Is.EqualTo(10));
            Assert.That(items, Has.Member(new Rectangle { X1 = 72, X2 = 78, Y1 = 42, Y2 = 47 }));
            Assert.That(items, Has.Member(new Rectangle { X1 = 80, X2 = 89, Y1 = 15, Y2 = 34 }));
            Assert.That(items, Has.Member(new Rectangle { X1 = 66, X2 = 87, Y1 = 42, Y2 = 90 }));
            Assert.That(items, Has.Member(new Rectangle { X1 = 70, X2 = 74, Y1 = 45, Y2 = 48 }));
            Assert.That(items, Has.Member(new Rectangle { X1 = 56, X2 = 75, Y1 = 31, Y2 = 32 }));
            Assert.That(items, Has.Member(new Rectangle { X1 = 29, X2 = 76, Y1 = 6, Y2 = 17 }));
            Assert.That(items, Has.Member(new Rectangle { X1 = 73, X2 = 76, Y1 = 2, Y2 = 11 }));
            Assert.That(items, Has.Member(new Rectangle { X1 = 74, X2 = 100, Y1 = 19, Y2 = 27 }));
            Assert.That(items, Has.Member(new Rectangle { X1 = 31, X2 = 45, Y1 = 48, Y2 = 70 }));
            Assert.That(items, Has.Member(new Rectangle { X1 = 39, X2 = 54, Y1 = 68, Y2 = 98 }));
        }

        [Test]
        public void ItemIsAddedToNodeOnceTheQuadTreeHasSplitIfTheyFit()
        {
            var quadtree = new Quadtree(new Rectangle { X1 = 0, X2 = 100, Y1 = 0, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 11, X2 = 13, Y1 = 99, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 18, X2 = 23, Y1 = 27, Y2 = 39 });
            quadtree.Add(new Rectangle { X1 = 66, X2 = 87, Y1 = 42, Y2 = 90 });
            quadtree.Add(new Rectangle { X1 = 86, X2 = 100, Y1 = 84, Y2 = 86 });
            quadtree.Add(new Rectangle { X1 = 29, X2 = 76, Y1 = 6, Y2 = 17 });
            quadtree.Add(new Rectangle { X1 = 61, X2 = 75, Y1 = 99, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 74, X2 = 100, Y1 = 19, Y2 = 27 });
            quadtree.Add(new Rectangle { X1 = 31, X2 = 45, Y1 = 48, Y2 = 70 });
            quadtree.Add(new Rectangle { X1 = 19, X2 = 50, Y1 = 0, Y2 = 27 });
            quadtree.Add(new Rectangle { X1 = 29, X2 = 49, Y1 = 69, Y2 = 74 });
            quadtree.Add(new Rectangle { X1 = 39, X2 = 54, Y1 = 68, Y2 = 98 });

            Assert.That(quadtree.Items.Count, Is.EqualTo(4));
            Assert.That(quadtree.Nodes[0].Items.Count, Is.EqualTo(1));

            quadtree.Add(new Rectangle { X1 = 76, X2 = 89, Y1 = 12, Y2 = 16 });

            Assert.That(quadtree.Items.Count, Is.EqualTo(4));
            Assert.That(quadtree.Nodes[0].Items.Count, Is.EqualTo(2));
        }

        [Test]
        public void ItemIsAddedToTopLevelQuadTreeEvenIfItHasSplitIfItDoesNotFitInAnyNode()
        {
            var quadtree = new Quadtree(new Rectangle { X1 = 0, X2 = 100, Y1 = 0, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 11, X2 = 13, Y1 = 99, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 18, X2 = 23, Y1 = 27, Y2 = 39 });
            quadtree.Add(new Rectangle { X1 = 66, X2 = 87, Y1 = 42, Y2 = 90 });
            quadtree.Add(new Rectangle { X1 = 86, X2 = 100, Y1 = 84, Y2 = 86 });
            quadtree.Add(new Rectangle { X1 = 29, X2 = 76, Y1 = 6, Y2 = 17 });
            quadtree.Add(new Rectangle { X1 = 61, X2 = 75, Y1 = 99, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 74, X2 = 100, Y1 = 19, Y2 = 27 });
            quadtree.Add(new Rectangle { X1 = 31, X2 = 45, Y1 = 48, Y2 = 70 });
            quadtree.Add(new Rectangle { X1 = 19, X2 = 50, Y1 = 0, Y2 = 27 });
            quadtree.Add(new Rectangle { X1 = 29, X2 = 49, Y1 = 69, Y2 = 74 });
            quadtree.Add(new Rectangle { X1 = 39, X2 = 54, Y1 = 68, Y2 = 98 });

            Assert.That(quadtree.Items.Count, Is.EqualTo(4));
            Assert.That(quadtree.Nodes[0].Items.Count, Is.EqualTo(1));

            quadtree.Add(new Rectangle { X1 = 61, X2 = 74, Y1 = 46, Y2 = 77 });

            Assert.That(quadtree.Items.Count, Is.EqualTo(5));
            Assert.That(quadtree.Nodes[0].Items.Count, Is.EqualTo(1));
            Assert.That(quadtree.Nodes[1].Items.Count, Is.EqualTo(2));
            Assert.That(quadtree.Nodes[2].Items.Count, Is.EqualTo(2));
            Assert.That(quadtree.Nodes[3].Items.Count, Is.EqualTo(2));
        }

        [Test]
        public void QuadTreeWillSplitAfterAddingMoreThanTenItemsToIt()
        {
            var quadtree = new Quadtree(new Rectangle { X1 = 0, X2 = 100, Y1 = 0, Y2 = 100 });
            quadtree.Add(new Rectangle { X1 = 11, X2 = 13, Y1 = 99, Y2 = 100 }); // 2
            quadtree.Add(new Rectangle { X1 = 18, X2 = 23, Y1 = 27, Y2 = 39 }); // 1
            quadtree.Add(new Rectangle { X1 = 66, X2 = 87, Y1 = 42, Y2 = 90 }); // -1
            quadtree.Add(new Rectangle { X1 = 86, X2 = 100, Y1 = 84, Y2 = 86 }); // 3
            quadtree.Add(new Rectangle { X1 = 29, X2 = 76, Y1 = 6, Y2 = 17 }); // -1
            quadtree.Add(new Rectangle { X1 = 61, X2 = 75, Y1 = 99, Y2 = 100 }); // 3
            quadtree.Add(new Rectangle { X1 = 74, X2 = 100, Y1 = 19, Y2 = 27 }); // 0
            quadtree.Add(new Rectangle { X1 = 31, X2 = 45, Y1 = 48, Y2 = 70 }); // -1
            quadtree.Add(new Rectangle { X1 = 19, X2 = 50, Y1 = 0, Y2 = 27 }); // 1
            quadtree.Add(new Rectangle { X1 = 29, X2 = 49, Y1 = 69, Y2 = 74 }); // 2

            Assert.That(quadtree.Nodes[0], Is.Null);

            quadtree.Add(new Rectangle { X1 = 39, X2 = 54, Y1 = 68, Y2 = 98 }); // -1

            Assert.That(quadtree.Nodes[0], Is.Not.Null);
            Assert.That(quadtree.Nodes[0].Bounds, Is.EqualTo(new Rectangle { X1 = 50, X2 = 100, Y1 = 0, Y2 = 50 }));
            Assert.That(quadtree.Nodes[1], Is.Not.Null);
            Assert.That(quadtree.Nodes[1].Bounds, Is.EqualTo(new Rectangle { X1 = 0, X2 = 50, Y1 = 0, Y2 = 50 }));
            Assert.That(quadtree.Nodes[2], Is.Not.Null);
            Assert.That(quadtree.Nodes[2].Bounds, Is.EqualTo(new Rectangle { X1 = 0, X2 = 50, Y1 = 50, Y2 = 100 }));
            Assert.That(quadtree.Nodes[3], Is.Not.Null);
            Assert.That(quadtree.Nodes[3].Bounds, Is.EqualTo(new Rectangle { X1 = 50, X2 = 100, Y1 = 50, Y2 = 100 }));

            Assert.That(quadtree.Items.Count, Is.EqualTo(4));
            Assert.That(quadtree.Nodes[0].Items.Count, Is.EqualTo(1));
            Assert.That(quadtree.Nodes[1].Items.Count, Is.EqualTo(2));
            Assert.That(quadtree.Nodes[2].Items.Count, Is.EqualTo(2));
            Assert.That(quadtree.Nodes[3].Items.Count, Is.EqualTo(2));
        }
    }
}
