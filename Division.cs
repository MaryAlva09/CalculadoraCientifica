using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCientifica
{
    class Division
    {
        public double Calcular(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("No se puede dividir entre cero.");
            }
            return x / y;
        }
    }
}
