using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCientifica
{
    public class RaizCubica
    {
        // Método para calcular la raíz cúbica de un número
        public double Calcular(double numero)
        {
            return Math.Pow(numero, 1.0 / 3.0); // Utiliza Math.Pow para calcular la raíz cúbica
        }
    }
}
