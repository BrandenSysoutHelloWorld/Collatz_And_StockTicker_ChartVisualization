using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz_ChartVisualization
{
    internal class BenFordsLaw
    {
        private Random Random = new Random();

        public int FirstDigit()
        {
            int num;
            num = RandomGenerator();

            while (num >= 10)
            {
                num /= 10;
            }
            return num;
        }

        public int RandomGenerator()
        {           
            int random = Random.Next();
            return random;
        }


    }
}
