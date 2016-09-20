using System;
using System.Collections.Generic;

using Atagoal.Core;

namespace LWCollide
{
    namespace UnitTest
    {
        public class LWShapeTest
        {
            //-----------------------------------------------------------------------------
            // Test GetCollisionPoint().
            // This calculate CollisionPoint.
            public void GetCollisionPointTest()
            {
                Console.WriteLine("Test LWShape.GetCollisionPoint() ... ");

                List<TestCase> testCases = new List<TestCase>
                {
                    case1,
                    case2,
                    case3,
                    case4
                };

                foreach (var testCase in testCases)
                {
                    Point result = testCase.subject.GetCollisionPoint(testCase.velocity, testCase.target);
                    if (result == null
                        || !result.Equals(testCase.expectedCollisionPoint))
                    {
                        Console.WriteLine("  X Test failed at [" + testCase.title + "].");
                        Console.WriteLine("   - expected (" + testCase.expectedCollisionPoint.x + "," + testCase.expectedCollisionPoint.y + ")");
                        Console.WriteLine("   - but (" + result.x + "," + result.y + ")");
                        Console.WriteLine("X LWShape.GetCollisionPoint() is red.");
                        return;
                    }
                }

                Console.WriteLine("O LWShape.GetCollisionPoint() is green.");
            }

            class TestCase
            {
                public String title;
                public LWShape subject;
                public LWShape target;
                public Vector velocity;
                public Point expectedCollisionPoint;
            }

            TestCase case1 = new TestCase
            {
                title = "case1 : No obstacles.",
                subject = LWShape.Create(
                    // position
                    new Point
                    {
                        x = 0,
                        y = 2
                    },
                    // vertexes
                    new List<Point>
                    {
                        new Point
                        {
                            x = -0.2f,
                            y = -0.2f
                        },
                        new Point
                        {
                            x = -0.2f,
                            y = 0.2f
                        },
                        new Point
                        {
                            x = 0.2f,
                            y = 0.2f
                        },
                        new Point
                        {
                            x = 0.2f,
                            y = -0.2f
                        }
                    }
                ),
                target = null,
                velocity = Vector.Create(
                    new Point { x = 0, y = 0 },
                    new Point { x = 0, y = 1 }
                ),
                expectedCollisionPoint = Point.CreateInvalidPoint()
            };

            TestCase case2 = new TestCase
            {
                title = "case2 : An obstacle has no shape.",
                subject = LWShape.Create(
                    // position
                    new Point
                    {
                        x = 0,
                        y = 2
                    },
                    // vertexes
                    new List<Point>
                    {
                        new Point
                        {
                            x = -0.2f,
                            y = -0.2f
                        },
                        new Point
                        {
                            x = -0.2f,
                            y = 0.2f
                        },
                        new Point
                        {
                            x = 0.2f,
                            y = 0.2f
                        },
                        new Point
                        {
                            x = 0.2f,
                            y = -0.2f
                        }
                    }
                ),
                target = LWShape.Create(
                    // position
                    new Point
                    {
                        x = 1.0f,
                        y = 1.0f
                    },
                    // vertexes
                    new List<Point>
                    {
                    }
                ),
                velocity = Vector.Create(
                    new Point { x = 0, y = 0 },
                    new Point { x = 0, y = 1 }
                ),
                expectedCollisionPoint = Point.CreateInvalidPoint()
            };

            TestCase case3 = new TestCase
            {
                title = "case3 : Not collide.",
                subject = LWShape.Create(
                    // position
                    new Point
                    {
                        x = 0,
                        y = 2
                    },
                    // vertexes
                    new List<Point>
                    {
                        new Point
                        {
                            x = -0.2f,
                            y = -0.2f
                        },
                        new Point
                        {
                            x = -0.2f,
                            y = 0.2f
                        },
                        new Point
                        {
                            x = 0.2f,
                            y = 0.2f
                        },
                        new Point
                        {
                            x = 0.2f,
                            y = -0.2f
                        }
                    }
                ),
                target = LWShape.Create(
                    // position
                    new Point
                    {
                        x = 1.0f,
                        y = 1.0f
                    },
                    // vertexes
                    new List<Point>
                    {
                        new Point
                        {
                            x = 0,
                            y = 0
                        },
                        new Point
                        {
                            x = 0,
                            y = 2.5f
                        },
                        new Point
                        {
                            x = 1,
                            y = 2.5f
                        },
                        new Point
                        {
                            x = 1,
                            y = 0
                        }
                    }
                ),
                velocity = Vector.Create(
                    new Point { x = 0, y = 0 },
                    new Point { x = 0, y = 1 }
                ),
                expectedCollisionPoint = Point.CreateInvalidPoint()
            };

            TestCase case4 = new TestCase
            {
                title = "case4 : Collide over target.",
                subject = LWShape.Create(
                    // position
                    new Point
                    {
                        x = 0,
                        y = 2
                    },
                    // vertexes
                    new List<Point>
                    {
                        new Point
                        {
                            x = -0.2f,
                            y = -0.2f
                        },
                        new Point
                        {
                            x = -0.2f,
                            y = 0.2f
                        },
                        new Point
                        {
                            x = 0.2f,
                            y = 0.2f
                        },
                        new Point
                        {
                            x = 0.2f,
                            y = -0.2f
                        }
                    }
                ),
                target = LWShape.Create(
                    // position
                    new Point
                    {
                        x = 1.0f,
                        y = 1.0f
                    },
                    // vertexes
                    new List<Point>
                    {
                        new Point
                        {
                            x = 0,
                            y = 0
                        },
                        new Point
                        {
                            x = 0,
                            y = 2.5f
                        },
                        new Point
                        {
                            x = 1,
                            y = 2.5f
                        },
                        new Point
                        {
                            x = 1,
                            y = 0
                        }
                    }
                ),
                velocity = Vector.Create(
                    new Point { x = 0, y = 0 },
                    new Point { x = 4, y = 0 }
                ),
                expectedCollisionPoint = Point.Create(1, 2.2f)
            };
        }
    }
}