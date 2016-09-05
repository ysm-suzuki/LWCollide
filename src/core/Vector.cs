using System;

namespace LWCollide
{
    namespace Core
    {
        public class Vector
        {
            public float x;
            public float y;

            public static Vector Create()
            {
                return new Vector { x = 0, y = 0 };
            }

            public static Vector Create(Point from, Point to)
            {
                return new Vector { x = to.x - from.x, y = to.y - from.y };
            }

            public float GetPower()
            {
                return x * x + y * y;
            }

            public Vector GetUnit()
            {
                float length = (float)System.Math.Sqrt(GetPower());
                return new Vector {
                    x = x / length,
                    y = y / length
                };
            }

            public Vector Clone()
            {
                return new Vector { x = this.x, y = this.y };
            }

            public bool Equals(Vector vector)
            {
                return x == vector.x
                    && y == vector.y;
            }

            public string Describe()
            {
                return "Vector: x = " + x + ", y = " + y;
            }
        }
    }
}