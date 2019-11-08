using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00179496_ManishBC_DDOOCP
{
    public class Formulae
    {
        public double Sum(IList<double> values)
        {
            double sum = 0;
            foreach (var v in values)
            {
                sum += v;
            }
            return sum;
        }
        public double Average(IList<double> values)
        {
            double Average = 0;
            foreach (var v in values)
            {
                Average += v;
            }
            return Average = Average / values.Count;
        }
        public double Mean(IList<double> values)
        {
            double mean = 0;
            foreach (var v in values)
            {
                mean += v;
            }
            return mean = mean / values.Count;
        }
        public double Median(IList<double> values)
        {
            double median;
            IList<double> tempArray = values;
            int count = tempArray.Count;
            Array.Sort(tempArray.ToArray());
            if (count % 2 == 0)
            {
                int middleElement1 = Convert.ToInt32(tempArray[(count / 2)] - 1);
                int middleElement2 = Convert.ToInt32(tempArray[(count) / 2]);
                median = (middleElement1 + middleElement2) / 2;
            }
            else
            {
                median = Convert.ToInt32(tempArray[(count / 2)]);
            }
            return median;
        }
        public double Mode(IList<double> values)
        {
            var groups = values.GroupBy(x => x);
            var largest = groups.OrderByDescending(x => x.Count()).First();
            double Mode = Convert.ToInt32(largest.Key);
            return Mode;
        }
        public double Multiply(IList<double>values)
        {
                double multiply = 1;
                foreach (var v in values)
                {
                    multiply *= v;
                }
            return multiply;
        }
    }
}

