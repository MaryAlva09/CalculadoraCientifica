using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCientifica
{
    class RaizEnesima
    {
        public double Calcular(double x, double n)
        {
            return Math.Pow(x, 1.0 / n);
        }
    }
}
