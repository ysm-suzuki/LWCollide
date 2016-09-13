using System;
using System.Collections.Generic;

using Atagoal.Core;

namespace LWCollide
{
    public class Math
    {
        // Inner Product
        public static float Inner(Vector vector1, Vector vector2)
        {
            return vector1.x * vector2.x + vector2.y * vector1.y;
        }

        // Cross Product
        public static float Cross(Vector vector1, Vector vector2)
        {
            return vector1.x * vector2.y - vector2.x * vector1.y;
        }

        public static Point Intersection(LineSegment line1, LineSegment line2)
        {
            Vector vector1 = Vector.Create(line1.from, line1.to);
            Vector vector2 = Vector.Create(line1.from, line2.from);
            Vector vector3 = Vector.Create(line1.from, line2.to);
            float cross1 = Cross(vector1, vector2);
            float cross2 = Cross(vector1, vector3);
            float ratio = cross1 / (cross1 + cross2);

            return new Point
            {
                x = line1.x + vector1.x * ratio,
                y = line1.y + vector1.y * ratio
            };
        }

        // shape: A convex polygon with clockwise rotation only.
        public static bool IsWithIn(Point point, List<LineSegment> shape)
        {
            foreach (LineSegment line in shape)
                if (Cross(Vector.Create(point, line.from), Vector.Create(point, line.to)) > 0)
                    return false;
            
            return true;
        }

        // Get a unit vector of line that make same direction to the vector.
        public static Vector GetLineVector(Vector vector, LineSegment line)
        {
            Vector lineVector = Vector.Create(line.from, line.to);
            Vector lineVectorReverse = Vector.Create(line.to, line.from);
            double cos = Inner(vector, lineVector) / System.Math.Sqrt((double)vector.GetPower()) * System.Math.Sqrt((double)lineVector.GetPower());

            while (cos < 0)
                cos += System.Math.PI * 2;
            while (cos > System.Math.PI * 2)
                cos -= System.Math.PI * 2;

            if (cos < System.Math.PI / 2 || cos > System.Math.PI * 3 / 2)
                return lineVector.GetUnit();
            else
                return lineVectorReverse.GetUnit();
        }
    }
}