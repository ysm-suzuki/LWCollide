using System;
using System.Collections.Generic;

using Atagoal.Core;

namespace LWCollide
{
    // This is the main interface
    public class LWShape
    {
        private List<LineSegment> _shape = new List<LineSegment>();
        private Point _position = new Point();

        // vertexes: Convex polygon vertexes with clockwise rotation only.
        public static LWShape Create(Point position, List<Point> vertexes)
        {
            LWShape lwShape = new LWShape();
            lwShape.SetPosition(position);
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
                            x = _position.x + vertexes[i].x,
                            y = _position.y + vertexes[i].y
                        },
                        new Point
                        {
                            x = _position.x + vertexes[(i + 1) % count].x,
                            y = _position.y + vertexes[(i + 1) % count].y
                        }
                    ));
        }

        public void SetPosition(Point position)
        {
            Distance diff = Distance.Create(_position, position);

            _position.x = position.x;
            _position.y = position.y;

            foreach (LineSegment lineSegment in _shape)
            {
                lineSegment.from.x += diff.x;
                lineSegment.from.y += diff.y;
                lineSegment.to.x += diff.x;
                lineSegment.to.y += diff.y;
            }
        }

        // The point is with in this shape or not.
        public bool IsWithIn(Point point)
        {
            return LWCollide.Math.IsWithIn(point, _shape);
        }

        // this shape move by velocity will collide a target or not
        public bool Collided(Vector velocity, LWShape target)
        {
            foreach (LineSegment lineSegment in _shape)
                if (target.IsWithIn(lineSegment.from + velocity))
                    return true;

            return false;
        }

        // this shape is colliding a target or not
        public bool Collided(LWShape target)
        {
            return Collided(new Vector(), target);
        }

        public Point GetCollisionPoint(Vector velocity, LWShape target)
        {
            if (target == null)
                return Point.CreateInvalidPoint();
            
            if (_cache.isRegistered(_shape,
                                    target.GetSegments(),
                                    _position,
                                    target.GetPosition(),
                                    velocity))
                return _cache.GetCollisionPoint();
            
            CalculateCollision(velocity, target);
            return _cache.GetCollisionPoint();
        }

        public Distance GetCollisionDistance(Vector velocity, LWShape target)
        {
            if (target == null)
                return Distance.Create();
            
            if (_cache.isRegistered(_shape,
                                    target.GetSegments(),
                                    _position,
                                    target.GetPosition(),
                                    velocity))
                return _cache.GetCollisionDistance();

            CalculateCollision(velocity, target);
            return _cache.GetCollisionDistance();
        }

        public Vector GetPrimaryVector(Vector velocity, LWShape target)
        {
            if (target == null)
                return Vector.Create();

            if (_cache.isRegistered(_shape,
                                    target.GetSegments(),
                                    _position,
                                    target.GetPosition(),
                                    velocity))
                return _cache.GetPrimaryVelocity();

            CalculateCollision(velocity, target);
            return _cache.GetPrimaryVelocity();
        }

        public Vector GetSecondaryVelocity(Vector velocity, LWShape target)
        {
            if (target == null)
                return Vector.Create();

            if (_cache.isRegistered(_shape,
                                    target.GetSegments(),
                                    _position,
                                    target.GetPosition(),
                                    velocity))
                return _cache.GetSecondaryVelocity();

            CalculateCollision(velocity, target);
            return _cache.GetSecondaryVelocity();
        }

        public Point GetPosition()
        {
            return _position.Clone();
        }

        public List<LineSegment> GetSegments()
        {
            return new List<LineSegment>(_shape);
        }


        private class Cache
        {
            private List<LineSegment> _originalShape = null;
            private List<LineSegment> _targetShape = null;
            private Point _originalPosition = null;
            private Point _targetPosition = null;
            private Vector _velocity = null;
            private Distance _collisionDistance = null;
            private Point _collisionPoint = null;
            private Vector _primary = null;
            private Vector _secondary = null;

            public void Register(
                    List<LineSegment> originalShape,
                    List<LineSegment> targetShape,
                    Point originalPosition,
                    Point targetPosition,
                    Vector velocity,
                    Point collisionPoint,
                    Distance collisionDistance,
                    Vector primary,
                    Vector secondary)
            {
                _originalShape = originalShape;
                _targetShape = targetShape;
                _originalPosition = originalPosition;
                _targetPosition = targetPosition;
                _velocity = velocity;
                _collisionPoint = collisionPoint;
                _collisionDistance = collisionDistance;
                _primary = primary;
                _secondary = secondary;
            }

            public bool isRegistered(
                    List<LineSegment> originalShape,
                    List<LineSegment> targetShape,
                    Point originalPosition,
                    Point targetPosition,
                    Vector velocity)
            {
                if (_originalShape == null
                    || _targetShape == null
                    || _velocity == null)
                    return false;

                if (_originalShape.Count != originalShape.Count
                    || _targetShape.Count != targetShape.Count)
                    return false;

                if (!_velocity.Equals(velocity))
                    return false;

                for (int i = 0; i < _originalShape.Count; i++)
                    if (!_originalShape[i].Equals(originalShape))
                        return false;

                for (int i = 0; i < _targetShape.Count; i++)
                    if (!_targetShape[i].Equals(targetShape))
                        return false;

                if (!_originalPosition.Equals(originalPosition))
                    return false;

                if (!_targetPosition.Equals(targetPosition))
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

            public Vector GetPrimaryVelocity()
            {
                return _primary;
            }

            public Vector GetSecondaryVelocity()
            {
                return _secondary;
            }


            public void Clear()
            {
                _originalShape = null;
                _targetShape = null;
                _velocity = null;
                _collisionDistance = null;
                _collisionPoint = null;
                _primary = null;
                _secondary = null;
            }
        }

        private Cache _cache = new Cache();


        private void CalculateCollision(Vector velocity, LWShape target)
        {
            if (target == null)
                return;

            Distance min = new Distance
            {
                x = float.MaxValue,
                y = float.MaxValue
            };
            Point collisionPoint = Point.CreateInvalidPoint();
            LineSegment collisionLine = null;

            foreach (LineSegment originalLineSegment in _shape)
            {
                foreach (LineSegment targetLineSegment in target.GetSegments())
                {
                    Point originalPoint = originalLineSegment.from;

                    if (target.IsWithIn(originalPoint)
                        && !target.IsWithIn(originalPoint + velocity))
                        continue;

                    LineSegment trajectory = LineSegment.Create(
                            originalPoint, originalPoint + velocity
                        );
                    Point intersection = LWCollide.Math.Intersection(trajectory, targetLineSegment);

                    if (intersection.IsInvalidPoint())
                        continue;

                    if (Distance.Create(originalPoint, intersection).GetPower() < min.GetPower())
                    {
                        collisionPoint = intersection;
                        min = Distance.Create(originalPoint, intersection);
                    }

                    collisionLine = targetLineSegment.Clone();
                }
            }

            // does not collide
            if (collisionPoint.IsInvalidPoint()
                || collisionLine == null)
            {
                _cache.Register(
                _shape,
                target.GetSegments(),
                _position,
                target.GetPosition(),
                velocity,
                collisionPoint.Clone(),
                min.Clone(),
                Vector.Create(),
                Vector.Create());

                return;
            }


            float primaryVectorLength = (float)System.Math.Sqrt((double)min.GetPower());
            float secondaryVectorLength = (float)System.Math.Sqrt((double)velocity.GetPower()) - primaryVectorLength;

            Vector primaryVector = velocity * (float)(primaryVectorLength / System.Math.Sqrt((double)velocity.GetPower()));
            Vector secondaryVector = LWCollide.Math.GetLineVector(velocity, collisionLine) * secondaryVectorLength;

            _cache.Register(
                _shape,
                target.GetSegments(),
                _position,
                target.GetPosition(),
                velocity,
                collisionPoint.Clone(),
                min.Clone(),
                primaryVector,
                secondaryVector);
        }
    }
}