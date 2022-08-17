namespace Collatz_ChartVisualization
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private Random StockRandom = new Random();

        private double StockPriceRandom = new double();

        private List<double> StockPriceList = new List<double>();


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
           string sequence = RandomStock().ToString() + ";";

            for (int i = 1; i < 200; i++)
            {
                chart2.Series[0].Points.AddY(RandomStock());
                sequence += RandomStock().ToString() + "; ";

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
            textBox2.Text = "";
        }

        private double RandomStock()
        {  
            double random = StockRandom.Next(-2, 3);
            StockPriceRandom = Math.Round(StockPriceRandom + random);
            StockPriceList.Add(StockPriceRandom);
            return StockPriceRandom;          

        }

    }
}