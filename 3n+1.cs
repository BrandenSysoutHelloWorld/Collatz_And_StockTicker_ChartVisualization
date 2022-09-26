using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz_ChartVisualization
{
    internal class _3n_1
    {

        public long CalculateSequence(long max)
        {

                max = (max % 2 == 0) ? max / 2 : max * 3 + 1;


            return max;
        }
    }
}
