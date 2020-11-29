using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyUnitTest.APP
{
    public class CalculatorService : ICalculatorService
    {
        public int add(int a, int b)
        {
            return a + b;
        }
    }
}
