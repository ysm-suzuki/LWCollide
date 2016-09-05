using System;
using System.Collections.Generic;
using LWCollide.Core;

namespace LWCollide
{
    // This is the main interface
    public class LWShape
    {
        private List<LineSegment> _shape = new List<LineSegment>();

        // vertexes: Convex polygon vertexes with clockwise rotation only.
        public static LWShape Create(List<Point> vertexes)
        {
            LWShape lwShape = new LWShape();
            lwShape.SetShape(vertexes);
            return lwShape;
        }
        
        public void SetShape(List<Point> vertexes)
        {
            int count = vertexes.Count;
            for (int i = 0; i < count; i++)
                _shape.Add(LineSegment.Create(
                        new Point
                        {
                            x = vertexes[i].x,
                            y = vertexes[i].y
                        },
                        new Point
                        {
                            x = vertexes[(i + 1) % count].x,
                            y = vertexes[(i + 1) % count].y
                        }
                    ));
        }
    }
}