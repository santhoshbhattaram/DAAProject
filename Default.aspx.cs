using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Diagnostics;
using System.Threading;
namespace DAAProject
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.Visible = false;
        }
        /// <summary>
        /// Displaying chart
        /// </summary>
        /// <param name="cType"></param>
        /// <param name="time"></param>
        private void DisplayChart(SeriesChartType cType,IDictionary<string, double> time)
        {         
            string[] x = new string[time.Keys.Count];
            double[] y = new double[time.Keys.Count];
            int i = 0;
            foreach(KeyValuePair<string, double> kvp in time)
            {
                x[i] = kvp.Key;
                y[i] = kvp.Value;
                i += 1;
            }
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = cType;
            Chart1.Legends[0].Enabled = true;
        }
        /// <summary>
        /// Button Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            IDictionary<string, double> timeconplexity = new Dictionary<string, double>();

            var message = "";
            if (Inputsize.Text != "" && !string.IsNullOrEmpty(Inputsize.Text))
            {
                SearchingAlgorithms sc = new SearchingAlgorithms();
                long size = long.Parse(Inputsize.Text);
                long[] times = new long[4];
                long[] inputarray = get_inputarray(size);
                Random rnd = new Random();
                int searchelement = rnd.Next(800, 1000);
                long position = -1;
                var elemenets = "";
                //DateTime startTime = DateTime.Now;

                for (long i = 0; i < inputarray.Length - 1; i++)
                {
                    elemenets += inputarray[i] + " ,";
                }
                //DateTime endTime = DateTime.Now;

                elemenets += inputarray[inputarray.Length - 1];
                message += "Input Array is " + elemenets + "<br/>";
                if (CheckBox1.Checked)
                {

                    DateTime startTime1 = DateTime.Now;
                    //message += "Start Time is " + startTime1 + "<br/>";
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    position = sc.LinearSearch(inputarray, searchelement);
                    stopWatch.Stop();
                    DateTime endTime1 = DateTime.Now;
                    TimeSpan TimeElapsed = (TimeSpan)(endTime1 - startTime1);
                    double microseconds = stopWatch.Elapsed.TotalMilliseconds * 1000;
                    timeconplexity.Add("Linear Search", microseconds);

                    if (position == -1)
                    {

                        message += "Linear Search Algorithm Results are as follows<br/>";
                        message += "Element " + searchelement + " is not found <br/> Time taken by Linear Algorithm is: " + microseconds + " microseconds<br/>";
                    }
                    else
                    {
                        message += "Linear Search Algorithm Results are as follows <br/>";
                        message += "Element " + searchelement + " is found <br/> Time taken by Linear Algorithm is: " + microseconds + " microseconds<br/>";
                    }
                }
                if (CheckBox2.Checked)
                {
                    long[] arr = inputarray;
                    Array.Sort(arr);
                    DateTime startTime1 = DateTime.Now;
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    position = sc.BinarySeach(inputarray, searchelement);
                    stopWatch.Stop();
                    DateTime endTime1 = DateTime.Now;
                    TimeSpan TimeElapsed = (TimeSpan)(endTime1 - startTime1);
                    double microseconds = stopWatch.Elapsed.TotalMilliseconds * 1000;
                    timeconplexity.Add("Binary Search", microseconds);

                    if (position == -1)
                    {

                        message += "Binary Search Algorithm Results are as follows<br/>";
                        message += "Element " + searchelement + " is not found <br/> Time taken by Binary Search Algorithm is: " + microseconds + " microseconds<br/>";
                    }
                    else
                    {
                        message += "Binary Search Algorithm Results are as follows <br/>";
                        message += "Element " + searchelement + " is found <br/> Time taken by Binary Search Algorithm is: " + microseconds + " microseconds<br/>";
                    }

                }
                if (CheckBox3.Checked)
                {
                    long[] arr = inputarray;
                    //Array.Sort(arr);
                    BinarySearchTree bst = new BinarySearchTree();
                    for (long i = 0; i < inputarray.Length; i++)
                    {
                        bst.AddNode(arr[i]);
                    }
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    Node searchnode = bst.SearchKey(searchelement, bst.Root);
                    stopWatch.Stop();
                    double microseconds = stopWatch.Elapsed.TotalMilliseconds * 1000;
                    timeconplexity.Add("Binary Search Tree", microseconds);
                    if (searchnode == null)
                    {

                        message += "Binary Search Tree Algorithm Results are as follows<br/>";
                        message += "Element " + searchelement + " is not found <br/> Time taken by Binary Search Tree is: " + microseconds + " microseconds<br/>";
                    }
                    else
                    {
                        message += "Binary Search Tree  Algorithm Results are as follows <br/>";
                        message += "Element " + searchelement + " is found <br/> Time taken by Binary Search Tree Algorithm is: " + microseconds + " microseconds<br/>";
                    }

                }
                if (CheckBox4.Checked)
                {
                    RedBlackNode rb = new RedBlackNode();
                    for (long i = 0; i < inputarray.Length; i++)
                    {
                        rb.AddNode(inputarray[i]);
                    }
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    RedBlackNode searchnode = rb.searchNode(searchelement);
                    stopWatch.Stop();
                    double microseconds = stopWatch.Elapsed.TotalMilliseconds * 1000;
                    timeconplexity.Add("Red Black Tree Search", microseconds);
                    if (searchnode == null)
                    {

                        message += "Red Black Tree Algorithm Results are as follows<br/>";
                        message += "Element " + searchelement + " is not found <br/> Time taken by Red Black Tree is: " + microseconds + " microseconds<br/>";
                    }
                    else
                    {
                        message += "Red Black Tree  Algorithm Results are as follows <br/>";
                        message += "Element " + searchelement + " is found <br/> Time taken by Red Black Tree Algorithm is: " + microseconds + " microseconds<br/>";
                    }

                }
                SeriesChartType type = SeriesChartType.Bar;
                DisplayChart(type, timeconplexity);
                Resultmessage.Text = message;
                Chart1.Visible = true;
            }
            else
            {
                Resultmessage.Text = "Please enter input";
            }
        }
        /// <summary>
        /// Generating the input array
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private long[] get_inputarray(long size)
        {
            long[] inputarray = new long[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                inputarray[i] = rnd.Next(0, 1000);

            }
            return inputarray;
        }
    }

}
