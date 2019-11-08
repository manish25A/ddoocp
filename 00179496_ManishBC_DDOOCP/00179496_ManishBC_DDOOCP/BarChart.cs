using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _00179496_ManishBC_DDOOCP
{
    public partial class BarChart : Form
    {
        string[] chars;
        int[] values;
        public BarChart(string[] chars, int[] values)
        {
            this.chars = chars;
            this.values = values;
            InitializeComponent();
        }
        public void BarExample()
        {
            chart1.Series.Clear();

            // Data arrays
            string[] seriesArray = chars;
            int[] pointsArray = values;

            // Set palette
            chart1.Palette = ChartColorPalette.EarthTones;

            // Set title
            chart1.Titles.Add("Spread Sheet");

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }

        }


       
        private void BarChart_Load_1(object sender, EventArgs e)
        {
            BarExample();
        }
    }
}

