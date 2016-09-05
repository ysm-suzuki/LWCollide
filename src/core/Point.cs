using System;

namespace LWCollide
{
    namespace Core
    {
        public class Point
        {
            public float x;
            public float y;

            public static Point Create()
            {
                return new Point { x = 0, y = 0 };
            }

            public Point Clone()
            {
                return new Point { x = this.x, y = this.y };
            }

            public bool Equals(Point point)
            {
                return x == point.x
                    && y == point.y;
            }

            public string Describe()
            {
                return "Point: x = " + x + ", y = " + y;
            }
        }
    }
}