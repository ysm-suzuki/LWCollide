using System;

namespace LWCollide
{
    namespace Core
    {
        public class Distance
        {
            public float x;
            public float y;

            public static Distance Create()
            {
                return new Distance { x = 0, y = 0 };
            }

            public float GetPower()
            {
                return x * x + y * y;
            }

            public Distance Clone()
            {
                return new Distance { x = this.x, y = this.y };
            }

            public bool Equals(Distance distance)
            {
                return x == distance.x
                    && y == distance.y;
            }

            public string Describe()
            {
                return "Distance: x = " + x + ", y = " + y;
            }
        }
    }
}