using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00179496_ManishBC_DDOOCP
{
   public class Context
    {
        public bool CheckEqual(string textbox)
        {
            if (textbox.Contains("="))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckColon(string textbox)

        {
            if (textbox.Contains(":"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckEmpty(string textbox)
        {
            if (textbox != string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

