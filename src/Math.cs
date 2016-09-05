using System;
using LWCollide.Core;

namespace LWCollide
{
    public class Math
    {
        public float Cross(LineSegment line1, LineSegment line2)
        {
            return line1.x * line2.y - line2.x * line1.y;
        }
    }
}