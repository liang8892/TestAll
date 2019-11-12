using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Class1
    {

        public void GetPro()
        {
            int i;
            do
            {
                try
                {
                    int L = 0;
                    int R = 0;
                    string op = "";
                    switch (op)
                    {
                        case "+":
                            i = L + R;
                            break;
                        case "-":
                            i = L - R;
                            break;
                        case "x":
                            i = L * R;
                            break;
                        case "/":
                            i = L / R;
                            break;
                        default:
                            i = -1;
                            break;
                    }
                }
                catch (Exception e)
                {
                    i = -1;
                }
            } while (i <= 0);
        }
    }
}
