using System;
using System.Collections.Generic;

using Atagoal.Core;

namespace LWCollide
{
    namespace UnitTest
    {
        public class LWCollideTest
        {
            public static void Main(string[] args)
            {
                new LWCollideTest().Run();
            }

            public void Run()
            {
                var shapeTest = new LWShapeTest();
                shapeTest.GetCollisionPointTest();

                var mathTest = new LWCollideMathTest();
                mathTest.InnerTest();
                mathTest.CrossTest();
            }
        }
    }
}