using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00179496_ManishBC_DDOOCP
{
    public class formulacalculation
    {
        Formulae F = new Formulae();
        public double GetCalculatedValue(string operationName, IList<double> values)
            {
                
                double result = 0;
                switch (operationName.ToUpper())
                {
                    case "SUM":
                        result = F.Sum(values);
                        break;
                    case "AVERAGE":
                        result = F.Average(values);
                        break;
                    case "MEAN":
                        result = F.Mean(values);
                        break;
                    case "MEDIAN":
                        result = F.Median(values);
                        break;
                    case "MODE":
                    result=F.Mode(values);
                        break;
                     case "*":
                    result = F.Multiply(values);
                    break;
                }
                return result;
            }
        }
}
