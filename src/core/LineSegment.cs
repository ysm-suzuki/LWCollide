using System;

namespace LWCollide
{
    namespace Core
    {
        public class LineSegment
        {
            public Point from;
            public Point to;
            public float x
            {
                get { return to.x - from.x; }
            }
            public float y
            {
                get { return to.y - from.y; }
            }

            public static LineSegment Create(Point fromPoint, Point toPoint)
            {
                return new LineSegment { from = fromPoint, to = toPoint };
            }

            public LineSegment Clone()
            {
                return new LineSegment { from = from.Clone(), to = to.Clone() };
            }

            public bool Equals(LineSegment segment)
            {
                return from.Equals(segment.from)
                    && to.Equals(segment.to);
            }

            public string Describe()
            {
                return "LineSegment: from (" + x + ", " + y + ") to (" + x + ", " + y + ")";
            }


            public static LineSegment operator +(LineSegment lineSegment, Vector vector)
            {
                return new LineSegment
                {
                    from = lineSegment.from + vector,
                    to = lineSegment.to + vector
                };
            }
        }
    }
}