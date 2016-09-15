using System;
using System.Collections.Generic;

using Atagoal.Core;

namespace LWCollide
{
    namespace UnitTest
    {
        public class LWCollideMathTest
        {
            public LWCollideMathTest()
            {
                Console.WriteLine("LWCollideMathTest cTor");
            }
            
            //-----------------------------------------------------------------------------
            // Test Inner().
            // This calculate inner product by two vectors.
            public void InnerTest()
            {
                Console.WriteLine("Test Math.Inner() ... ");
                
                // right angle
                float rightAngleInnerProduct = LWCollide.Math.Inner(
                    new Vector
                    {
                        x = 1,
                        y = 0,
                    },
                    new Vector
                    {
                        x = 0,
                        y = 1,
                    }
                    );

                
                if (rightAngleInnerProduct == 0)
                    Console.WriteLine("  Åõ Testing right angle inner product Passed.");
                else
                {
                    Console.WriteLine("  Å~ Testing right angle inner product Failed.");
                    Console.WriteLine("Å~ Math.Inner() is red.");
                    return;
                }

                // parallel
                float parallelInnerProduct = LWCollide.Math.Inner(
                   new Vector
                   {
                       x = 1,
                       y = 0,
                   },
                   new Vector
                   {
                       x = 1,
                       y = 0,
                   }
                   );


                if (parallelInnerProduct == 1)
                    Console.WriteLine("  Åõ Testing parallel inner product Passed.");
                else
                {
                    Console.WriteLine("  Å~ Testing parallel inner product Failed.");
                    Console.WriteLine("Å~ Math.Inner() is red.");
                    return;
                }

                // acute angle
                float acuteAngleInnerProduct = LWCollide.Math.Inner(
                   new Vector
                   {
                       x = 1,
                       y = 2,
                   },
                   new Vector
                   {
                       x = 3,
                       y = 4,
                   }
                   );


                if (acuteAngleInnerProduct == 11)
                    Console.WriteLine("  Åõ Testing acute inner product Passed.");
                else
                {
                    Console.WriteLine("  Å~ Testing acute inner product Failed.");
                    Console.WriteLine("Å~ Math.Inner() is red.");
                    return;
                }

                // obtuse angle
                float obtuseAngleInnerProduct = LWCollide.Math.Inner(
                   new Vector
                   {
                       x = 1,
                       y = 2,
                   },
                   new Vector
                   {
                       x = -3,
                       y = -4,
                   }
                   );


                if (obtuseAngleInnerProduct == -11)
                    Console.WriteLine("  Åõ Testing obtuse inner product Passed.");
                else
                {
                    Console.WriteLine("  Å~ Testing obtuse inner product Failed.");
                    Console.WriteLine("Å~ Math.Inner() is red.");
                    return;
                }


                Console.WriteLine("Åù Math.Inner() is green.");
            }

            //-----------------------------------------------------------------------------
            // Test Cross().
            // This calculate cross product by two vectors.
            public void CrossTest()
            {
                Console.WriteLine("Test Math.Cross() ... ");

                // right angle
                float rightAngleCrossProduct = LWCollide.Math.Cross(
                    new Vector
                    {
                        x = 1,
                        y = 0,
                    },
                    new Vector
                    {
                        x = 0,
                        y = 1,
                    }
                    );


                if (rightAngleCrossProduct == 1)
                    Console.WriteLine("  Åõ Testing right angle cross product Passed.");
                else
                {
                    Console.WriteLine("  Å~ Testing right angle cross product Failed.");
                    Console.WriteLine("Å~ Math.Inner() is red.");
                    return;
                }

                // parallel
                float parallelCrossProduct = LWCollide.Math.Cross(
                    new Vector
                    {
                        x = 1,
                        y = 2,
                    },
                    new Vector
                    {
                        x = 1,
                        y = 2,
                    }
                    );


                if (parallelCrossProduct == 0)
                    Console.WriteLine("  Åõ Testing parallel cross product Passed.");
                else
                {
                    Console.WriteLine("  Å~ Testing parallel cross product Failed.");
                    Console.WriteLine("Å~ Math.Inner() is red.");
                    return;
                }

                // acute angle
                float acuteAngleCrossProduct = LWCollide.Math.Cross(
                    new Vector
                    {
                        x = 1,
                        y = 2,
                    },
                    new Vector
                    {
                        x = 3,
                        y = 4,
                    }
                    );


                if (acuteAngleCrossProduct == -2)
                    Console.WriteLine("  Åõ Testing acute angle cross product Passed.");
                else
                {
                    Console.WriteLine("  Å~ Testing acute angle cross product Failed.");
                    Console.WriteLine("Å~ Math.Inner() is red.");
                    return;
                }
                    

                // obtuse angle
                float obtuseAngleCrossProduct = LWCollide.Math.Cross(
                    new Vector
                    {
                        x = 1,
                        y = 2,
                    },
                    new Vector
                    {
                        x = -3,
                        y = -4,
                    }
                    );


                if (obtuseAngleCrossProduct == 2)
                    Console.WriteLine("  Åõ Testing obtuse angle cross product Passed.");
                else
                {
                    Console.WriteLine("  Å~ Testing obtuse angle cross product Failed.");
                    Console.WriteLine("Å~ Math.Inner() is red.");
                    return;
                }

                Console.WriteLine("Åù Math.Cross() is green.");
            }

            //-----------------------------------------------------------------------------
            // Test Intersection().
            // This calculate an intersection point by two line segments.
            public void IntersectionTest()
            {

            }

            //-----------------------------------------------------------------------------
            // Test IsWithIn().
            // This calculate the point is with in the shape or not.
            public void IsWithInTest()
            {

            }

            //-----------------------------------------------------------------------------
            // Test GetLineVector().
            // This provide a unit vector of line that is same direction of the vector.
            public void GetLineVectorTest()
            {

            }
        }
    }
}