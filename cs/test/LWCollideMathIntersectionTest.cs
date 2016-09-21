using System;
using System.Collections.Generic;

using Atagoal.Core;

namespace LWCollide
{
    namespace UnitTest
    {
        public class LWCollideMathIntersectionTest
        {
            //-----------------------------------------------------------------------------
            // Test GetCollisionPoint().
            // This calculate CollisionPoint.
            public void Run()
            {
                Console.WriteLine("Test LWCollide.Math.Intersection() ... ");

                List<TestCase> testCases = new List<TestCase>
                {
                    case1
                };

                foreach (var testCase in testCases)
                {
                    Point result = LWCollide.Math.Intersection(testCase.line1, testCase.line2);
                    if (result == null
                        || !result.Equals(testCase.expected))
                    {
                        Console.WriteLine("  X Test failed at [" + testCase.title + "].");
                        Console.WriteLine("   - expected (" + testCase.expected.x + "," + testCase.expected.y + ")");
                        Console.WriteLine("   - but (" + result.x + "," + result.y + ")");
                        Console.WriteLine("X LWCollide.Math.Intersection() is red.");
                        return;
                    }
                }

                Console.WriteLine("O LWCollide.Math.Intersection() is green.");
            }

            class TestCase
            {
                public String title;
                public LineSegment line1;
                public LineSegment line2;
                public Point expected;
            }

            TestCase case1 = new TestCase
            {
                title = "Case1 : Intersected.",
                line1 = LineSegment.Create(Point.Create(1, 0), Point.Create(0, 1)),
                line2 = LineSegment.Create(Point.Create(0, 0), Point.Create(1, 1)),
                expected = Point.Create(0.5f, 0.5f)
            };

            TestCase case2 = new TestCase
            {
                title = "Case2 : Not intersected.",
                line1 = LineSegment.Create(Point.Create(1, 0), Point.Create(0, 1)),
                line2 = LineSegment.Create(Point.Create(2, 0), Point.Create(3, 1)),
                expected = Point.CreateInvalidPoint()
            };

            TestCase case3 = new TestCase
            {
                title = "Case3 : Parallel.",
                line1 = LineSegment.Create(Point.Create(1, 0), Point.Create(0, 1)),
                line2 = LineSegment.Create(Point.Create(2, 0), Point.Create(0, 2)),
                expected = Point.CreateInvalidPoint()
            };
        }
    }
}