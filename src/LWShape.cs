using System;
using System.Collections.Generic;

using Atagoal.Core;

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

        public bool IsWithIn(Point point)
        {
            return LWCollide.Math.IsWithIn(point, _shape);
        }

        public bool Collided(Vector velocity, LWShape target)
        {
            foreach (LineSegment lineSegment in _shape)
                if (target.IsWithIn(lineSegment.from + velocity))
                    return true;

            return false;
        }

        public bool Collided(LWShape target)
        {
            return Collided(new Vector(), target);
        }

        public Point GetCollisionPoint(Vector velocity, LWShape target)
        {
            if (_cache.isRegistered(_shape, target.GetShape(), velocity))
                return _cache.GetCollisionPoint();

            CalculateCollision(velocity, target);
            return _cache.GetCollisionPoint();
        }

        public Distance GetCollisionDistance(Vector velocity, LWShape target)
        {
            if (_cache.isRegistered(_shape, target.GetShape(), velocity))
                return _cache.GetCollisionDistance();

            CalculateCollision(velocity, target);
            return _cache.GetCollisionDistance();
        }

        public List<LineSegment> GetShape()
        {
            return new List<LineSegment>(_shape);
        }


        private class Cache
        {
            private List<LineSegment> _originalShape = null;
            private List<LineSegment> _targetShape = null;
            private Vector _velocity = null;
            private Distance _collisionDistance = null;
            private Point _collisionPoint = null;

            public void Register(
                    List<LineSegment> originalShape,
                    List<LineSegment> targetShape,
                    Vector velocity,
                    Point collisionPoint,
                    Distance collisionDistance)
            {
                _originalShape = originalShape;
                _targetShape = targetShape;
                _velocity = velocity;
                _collisionPoint = collisionPoint;
                _collisionDistance = collisionDistance;
            }

            public bool isRegistered(
                    List<LineSegment> originalShape,
                    List<LineSegment> targetShape,
                    Vector velocity)
            {
                if (_originalShape == null
                    || _targetShape == null
                    || _velocity == null)
                    return false;

                if (_originalShape.Count != originalShape.Count
                    || _targetShape.Count != targetShape.Count)
                    return false;

                for (int i = 0; i < _originalShape.Count; i++)
                    if (!_originalShape[i].Equals(originalShape))
                        return false;

                for (int i = 0; i < _targetShape.Count; i++)
                    if (!_targetShape[i].Equals(targetShape))
                        return false;

                return true;
            }

            public Point GetCollisionPoint()
            {
                return _collisionPoint;
            }

            public Distance GetCollisionDistance()
            {
                return _collisionDistance;
            }
        }

        private Cache _cache = new Cache();


        private void CalculateCollision(Vector velocity, LWShape target)
        {
            Distance min = new Distance
            {
                x = float.MaxValue,
                y = float.MaxValue
            };
            Point collisionPoint = Point.CreateInvalidPoint();

            foreach (LineSegment originalLineSegment in _shape)
            {
                foreach (LineSegment targetLineSegment in target.GetShape())
                {
                    if (target.IsWithIn(originalLineSegment.from)
                        || !target.IsWithIn(originalLineSegment.from + velocity))
                        continue;

                    LineSegment trajectory = LineSegment.Create(
                            originalLineSegment.from, originalLineSegment.from + velocity
                        );
                    Point intersection = LWCollide.Math.Intersection(trajectory, targetLineSegment);

                    if (Distance.Create(originalLineSegment.from, intersection).GetPower() < min.GetPower())
                    {
                        collisionPoint = intersection;
                        min = Distance.Create(originalLineSegment.from, intersection);
                    }
                }
            }

            _cache.Register(
                _shape,
                target.GetShape(),
                velocity,
                collisionPoint.Clone(),
                min.Clone());
        }
    }
}