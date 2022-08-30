namespace Collatz_ChartVisualization
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private Random StockRandom = new Random();

        private double value = new double();

        private double StockPriceRandom = new double();

        private List<double> StockPriceList = new List<double>();

        private Queue<double> q = new Queue<double>();


        //------------ BUTTONS --------------//

        private void button1_Click_1(object sender, EventArgs e)
        {
            long max = Convert.ToInt64(textBox1.Text);
            if (max > 0)
                CalculateSequence(max);
            else
                MessageBox.Show("Insert a number greater than zero!");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            InitializeGraph();
            string sequence = MA50().ToString() + ";";

            StockPriceList = new List<double>();
            StockRandom = new Random();
            value = new double();

            for (int i = 0; i < 2000; i++)
            {
                chart2.Series[0].Points.AddY(RandomStock());
                chart2.Series[1].Points.AddY(MA50());
                sequence += MA50().ToString() + "; ";

            }
            textBox2.Text = sequence;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            InitializeGraph();
            textBox1.Clear();
            MessageBox.Show("Graph Successfully Reset !");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
            Application.Exit();
        }

        //------------ FUNCTIONS --------------//

        private void CalculateSequence(long max)
        {
            InitializeGraph();
            string sequence = max.ToString() + "; ";
            chart2.Series[0].Points.AddY(max);
            do
            {
                max = (max % 2 == 0) ? max / 2 : max * 3 + 1;
                sequence += max.ToString() + "; ";
                chart2.Series[0].Points.AddY(max);
            } while (max != 1);
            textBox2.Text = sequence;
        }

        private void InitializeGraph()
        {
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            textBox2.Text = "";
        }

        private double RandomStock()
        {  
            double random = StockRandom.Next(-2, 3);
            StockPriceRandom = Math.Round(StockPriceRandom + random);
            StockPriceList.Add(StockPriceRandom);
            return StockPriceRandom;         

        }

        private double MA50()
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
            return value/50;
        }
    }
}