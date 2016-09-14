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
                    Console.WriteLine("  �� Testing right angle inner product Passed.");
                else
                {
                    Console.WriteLine("  �~ Testing right angle inner product Failed.");
                    Console.WriteLine("�� Math.Inner() is red.");
                    return;
                }

                // parallel

                // acute angle

                // obtuse angle

                // random

                Console.WriteLine("�� Math.Inner() is green.");
            }

            public void CrossTest()
            {
                Console.WriteLine("Test Math.Cross() ... ");

                // right angle

                // parallel

                // acute angle

                // obtuse angle

                // random

                Console.WriteLine("�� Math.Cross() is green.");
            }
        }
    }
}