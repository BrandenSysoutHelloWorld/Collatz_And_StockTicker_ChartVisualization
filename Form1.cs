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

        _3n_1 _3N_1 = new _3n_1();

        StockTicker stockTicker = new StockTicker();

        BenFordsLaw BenFordsLaw = new BenFordsLaw();

        Dictionary<int, double> points = new Dictionary<int, double>();

        List<int> ints = new List<int>();

        Queue<double> queue = new Queue<double>();

        Random n = new Random();
        //------------ FUNCTIONS --------------//



        private void InitializeGraph()
        {
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            textBox2.Text = "";
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            textBox2.Text = "";
        }


        //------------ BUTTONS --------------//

        private void button3_Click(object sender, EventArgs e)
        {
            InitializeGraph();
            string sequence = stockTicker.MA50().ToString() + ";";

            for (int i = 0; i < 2000; i++)
            {
                chart1.Series[0].Points.AddY(stockTicker.RandomStock());
                chart1.Series[1].Points.AddY(stockTicker.MA50());
                sequence += stockTicker.MA50().ToString() + "; ";

            }
            textBox4.Text = sequence;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            InitializeGraph();
            long max = Convert.ToInt64(textBox6.Text);
            chart2.Series[0].Points.AddY(max);
            string sequence = max.ToString() + "; ";
            if (max > 0)
            {
                do
                {
                    max = (max % 2 == 0) ? max / 2 : max * 3 + 1;
                    textBox5.Text = max.ToString();
                    chart2.Series[0].Points.AddY(max);
                    sequence += max.ToString() + "; ";

                } while (max != 1);

            }
            else
            {
                MessageBox.Show("Insert a number greater than zero!");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            InitializeGraph();
            textBox1.Clear();
            MessageBox.Show("Graph Successfully Reset !");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InitializeGraph();
            textBox1.Clear();
            MessageBox.Show("Graph Successfully Reset !");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int tmp1 = 0;
            int tmp2 = 0;
            int tmp3 = 0;
            int tmp4 = 0;
            int tmp5 = 0;
            int tmp6 = 0;
            int tmp7 = 0;
            int tmp8 = 0;
            int tmp9 = 0;

            for (int i = 0; i < 5000; i++)
            {
                ints.Add(BenFordsLaw.FirstDigit());
            }

            foreach(int i in ints)
            {
                switch (i)
                {
                    case 1:
                        tmp1++;                        
                        break;                        
                    case 2:
                        tmp2++;                        
                        break;
                    case 3:
                        tmp3++;                        
                        break;
                    case 4:
                        tmp4++;                        
                        break;
                    case 5:
                        tmp5++;                        
                        break;
                    case 6:
                        tmp6++;
                        break;
                    case 7:
                        tmp7++;
                        break;
                    case 8:
                        tmp8++;
                        break;
                    case 9:
                        tmp9++;
                        break;
                }
            }

            points.Add(1, tmp1);
            points.Add(2, tmp2);
            points.Add(3, tmp3);
            points.Add(4, tmp4);
            points.Add(5, tmp5);
            points.Add(6, tmp6);
            points.Add(7, tmp7);
            points.Add(8, tmp8);
            points.Add(9, tmp9);

            string t = 
                "//" + tmp1 + "//" + tmp2 + "//" + tmp3 + "//" + tmp4 + "//" + tmp5 + 
                "//" + tmp6 + "//" + tmp7 + "//" + tmp8 + "//" + tmp9 + "//" +
                "//";
            textBox3.Text = t;
            
            foreach (KeyValuePair<int, double> p in points)
            {
                queue.Enqueue(p.Value);
                System.Console.WriteLine(p.Key + ":" + p.Value);
            }

            while(queue.Count > 0)
            {
                float average, percentage, total = 5000f;
                average = (float)queue.Dequeue() / total;
                percentage = average * 100;
                System.Console.WriteLine(Math.Round(percentage, 2));
                chart3.Series[0].Points.AddY(percentage);
            }
        }
    }
}


