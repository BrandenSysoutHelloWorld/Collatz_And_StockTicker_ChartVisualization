using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz_ChartVisualization
{
    internal class StockTicker
    {
        private Random StockRandom = new Random();

        private double value = new double();

        private double StockPriceRandom = new double();

        private List<double> StockPriceList = new List<double>();

        private Queue<double> q = new Queue<double>();

        public double RandomStock()
        {
            double random = StockRandom.Next(-2, 3);
            StockPriceRandom = Math.Round(StockPriceRandom + random);
            StockPriceList.Add(StockPriceRandom);
            return StockPriceRandom;

        }

        public double MA50()
        {
            //var q = new Queue<int>();

            if (q.Count < 50)
            {
                q.Enqueue(this.StockPriceRandom);
                value = q.Sum();
            }
            else
            {
                q.Dequeue();
            }
            return value / 50;
        }
    }
}
