using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCientifica
{
    class Tangente
    {
        public double Calcular(double x)
        {
            x = x * (Math.PI / 180);
            return Math.Tan(x);
        }
    }
}
