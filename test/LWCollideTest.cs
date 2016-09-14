using System;
using System.Collections.Generic;

using Atagoal.Core;

namespace LWCollide
{
    namespace UnitTest
    {
        public class LWCollideTest
        {
            public static void Main()
            {
                new LWCollideTest().Run();
            }

            public void Run()
            {
                var mathTest = new LWCollideMathTest();
                mathTest.InnerTest();
            }
        }
    }
}