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

            public static Distance Create(Point from, Point to)
            {
                return new Distance 
                {
                    x = to.x - from.x,
                    y = to.y - from.y
                };
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
                return GetPower() == distance.GetPower();
            }

            public bool FuzzyEquals(Distance distance, float threshold)
            {
                float pow = GetPower();
                float targetPow = distance.GetPower();
                return targetPow - threshold <= pow
                    && pow <= targetPow + threshold;
            }

            public string Describe()
            {
                return "Distance: x = " + x + ", y = " + y;
            }
        }
    }
}