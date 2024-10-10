using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCientifica
{
    class Potencia
    {
        public double Calcular(double baseNum, double exponente)
        {
            return Math.Pow(baseNum, exponente);
        }
    }
}
