using System;
using System.Linq;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace CalculadoraCientifica
{
    public partial class Form1 : Form
    {
        double valor1 = 0;
        double valor2 = 0;
        string operador = "";
        string historial = ""; // Variable para almacenar el historial de operaciones


        public Form1()
        {
            InitializeComponent();
        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            if (cajaResultado.Text == "0")
                cajaResultado.Text = boton.Text;
            else
                cajaResultado.Text += boton.Text;

            // Asegúrate de que no agregas el número más de una vez en el historial
            if (historial.EndsWith(" ")) // Verifica si el último carácter fue un operador antes de añadir el número
            {
                historial += boton.Text;
            }
            textHistorial.Text = historial;
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cajaResultado.Clear();
            cajaResultado.Text = "0";
            valor1 = 0;
            valor2 = 0;
            operador = "";
            textHistorial.Clear(); // Limpiar el historial
            historial = ""; // Reiniciar la variable historial
        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            if (!double.TryParse(cajaResultado.Text, out valor1)) return; // Asegurar de que el valor es un número válido antes de asignarlo.
            operador = boton.Text;
            cajaResultado.Clear();

            // Actualizar el historial con el operador
            historial += $" {valor1} {operador} ";
            textHistorial.Clear();
            textHistorial.Text = historial;
        }


        private void btnIgual_Click(object sender, EventArgs e)
        {
            valor2 = Convert.ToDouble(cajaResultado.Text);
            double resultado = 0;

            try
            {
                switch (operador)
                {
                    case "+":
                        resultado = new Suma().oper_suma(valor1, valor2);
                        break;
                    case "-":
                        resultado = new Resta().oper_res(valor1, valor2);
                        break;
                    case "*":
                        resultado = new Multiplicacion().oper_multi(valor1, valor2);
                        break;
                    case "/":
                        resultado = new Division().Calcular(valor1, valor2);
                        break;
                    case "x^y":
                        resultado = new Potencia().Calcular(valor1, valor2);
                        break;
                    case "y√x":
                        resultado = new RaizEnesima().Calcular(valor1, valor2);
                        break;
                    case "%":
                        resultado = new Modulo().Calcular(valor1, valor2);
                        break;
                    default:
                        throw new InvalidOperationException("Operación no soportada.");
                }
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }

            cajaResultado.Text = resultado.ToString();

            // Agregar la operación y el resultado al historial
            historial += $" = {resultado}\r\n";
            textHistorial.Clear();
            textHistorial.Text = historial;

            // Limpiar historial para la siguiente operación
            historial = "";
        }


        private void btnSin_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el número del cuadro de resultado
                double x = Convert.ToDouble(cajaResultado.Text);
                double resultado = new Seno().Calcular(x);

                // Mostrar el resultado en la caja de resultado
                cajaResultado.Text = resultado.ToString();

                // Actualizar el historial con la operación realizada
                if (!string.IsNullOrEmpty(cajaResultado.Text) && cajaResultado.Text != "0")
                {
                    historial += $"sin({x}) = {resultado}\r\n";
                    textHistorial.Text = historial;
                }

                // Limpiar historial para la siguiente operación
                historial = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un número válido.");
            }
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(cajaResultado.Text);
                double resultado = new Coseno().Calcular(x);
                cajaResultado.Text = resultado.ToString();

                // Agregar operación trigonométrica al historial
                historial += $"cos({x}) = {resultado}\r\n";
                textHistorial.Text = historial;

                // Limpiar historial para la siguiente operación
                historial = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un número válido.");
            }
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(cajaResultado.Text);
                double resultado = new Tangente().Calcular(x);
                cajaResultado.Text = resultado.ToString();

                // Agregar operación trigonométrica al historial
                historial += $"tan({x}) = {resultado}\r\n";
                textHistorial.Text = historial;

                // Limpiar historial para la siguiente operación
                historial = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un número válido.");
            }
        }

        private void btnXCuadrado_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(cajaResultado.Text);
                double resultado = new Cuadrado().Calcular(x);
                cajaResultado.Text = resultado.ToString();

                // Agregar operación al historial
                historial += $"{x}^2 = {resultado}\r\n";
                textHistorial.Text = historial;

                // Limpiar historial para la siguiente operación
                historial = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un número válido.");
            }
        }

        private void btnXCubo_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(cajaResultado.Text);
                double resultado = new Cubo().Calcular(x);
                cajaResultado.Text = resultado.ToString();

                // Agregar operación al historial
                historial += $"{x}^3 = {resultado}\r\n";
                textHistorial.Text = historial;

                // Limpiar historial para la siguiente operación
                historial = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un número válido.");
            }
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            double pi = new Pi().ObtenerValor();
            cajaResultado.Text = pi.ToString();

            // Agregar operación al historial
            historial += $"π = {pi}\r\n";
            textHistorial.Text = historial;

            // Limpiar historial para la siguiente operación
            historial = "";
        }

        private void btnRaizCubica_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(cajaResultado.Text);
                double resultado = new RaizCubica().Calcular(x);
                cajaResultado.Text = resultado.ToString();

                // Agregar operación al historial
                historial += $"³√{x} = {resultado}\r\n";
                textHistorial.Text = historial;

                // Limpiar historial para la siguiente operación
                historial = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un número válido.");
            }
        }

        private void btnDiezAPotencia_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(cajaResultado.Text);
                double resultado = new DiezAPotencia().Calcular(x);
                cajaResultado.Text = resultado.ToString();

                // Agregar operación al historial
                historial += $"10^{x} = {resultado}\r\n";
                textHistorial.Text = historial;

                // Limpiar historial para la siguiente operación
                historial = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un número válido.");
            }
        }

        private void btnExponencial_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(cajaResultado.Text);
                double resultado = new Exponencial().Calcular(x);
                cajaResultado.Text = resultado.ToString();

                // Agregar operación al historial
                historial += $"e^{x} = {resultado}\r\n";
                textHistorial.Text = historial;

                // Limpiar historial para la siguiente operación
                historial = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un número válido.");
            }
        }

        private void btnLogaritmo_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(cajaResultado.Text);
                double resultado = new LogaritmoNatural().Calcular(x);
                cajaResultado.Text = resultado.ToString();

                // Agregar operación al historial
                historial += $"ln({x}) = {resultado}\r\n";
                textHistorial.Text = historial;

                // Limpiar historial para la siguiente operación
                historial = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un número válido.");
            }
        }

        private void btnRaizEnesima_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(cajaResultado.Text);
                double y = Convert.ToDouble(cajaResultado.Text);
                double resultado = new RaizEnesima().Calcular(x, y);
                cajaResultado.Text = resultado.ToString();

                historial += $"{y}√{x} = {resultado}\r\n";
                textHistorial.Text = historial;

                historial = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa números válidos.");
            }
        }

        private void btnPotencia_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de base y exponente de la caja de resultado
                double baseNum = Convert.ToDouble(cajaResultado.Text);

                // Pedir al usuario que ingrese el exponente
                string inputExponente = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el valor del exponente:", "Exponente", "2");
                if (double.TryParse(inputExponente, out double exponente))
                {
                    // Crear una instancia de la clase Potencia y calcular el resultado
                    double resultado = new Potencia().Calcular(baseNum, exponente);
                    cajaResultado.Text = resultado.ToString();

                    // Agregar la operación y el resultado al historial
                    historial += $"{baseNum}^{exponente} = {resultado}\r\n";
                    textHistorial.Text = historial;

                    // Limpiar historial para la siguiente operación
                    historial = "";
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un exponente válido.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un número válido.");
            }
        }

        public void BtnCE_Click(object sender, EventArgs e)
        {
            // Verificar que la pantalla de entrada no esté vacía
            if (!string.IsNullOrEmpty(cajaResultado.Text))
            {
                // Eliminar el último carácter de la pantalla de entrada
                cajaResultado.Text = cajaResultado.Text.Substring(0, cajaResultado.Text.Length - 1);
            }
        }

        public void BtnBorrarDigito_Click(object sender, EventArgs e)
        {
            // Verificar que la pantalla de entrada no esté vacía
            if (!string.IsNullOrEmpty(cajaResultado.Text))
            {
                // Eliminar el último carácter de la pantalla de entrada
                cajaResultado.Text = cajaResultado.Text.Substring(0, cajaResultado.Text.Length - 1);

                // Actualizar el historial eliminando el último carácter
                if (!string.IsNullOrEmpty(historial))
                {
                    // Dividir el historial en líneas para poder procesarlo
                    var lineas = historial.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList();

                    // Verificar que hay al menos una línea en el historial
                    if (lineas.Count > 0)
                    {
                        // Obtener la última línea del historial
                        var ultimaEntrada = lineas[lineas.Count - 1];

                        // Eliminar el último carácter de la última línea del historial
                        if (!string.IsNullOrEmpty(ultimaEntrada))
                        {
                            ultimaEntrada = ultimaEntrada.Substring(0, ultimaEntrada.Length - 1);

                            // Reemplazar la última línea modificada en el historial
                            lineas[lineas.Count - 1] = ultimaEntrada;

                            // Si la última línea está vacía después de la eliminación, removerla
                            if (string.IsNullOrEmpty(ultimaEntrada))
                            {
                                lineas.RemoveAt(lineas.Count - 1);
                            }

                            // Actualizar el historial con el contenido modificado
                            historial = string.Join("\r\n", lineas);
                            textHistorial.Text = historial;
                        }
                    }
                }
            }
        }



        public void BtnCambioSigno_Click(object sender, EventArgs e)
        {
            // Verificar que la pantalla de entrada no esté vacía
            if (!string.IsNullOrEmpty(cajaResultado.Text))
            {
                // Verificar si el número ya tiene un signo negativo
                if (cajaResultado.Text.StartsWith("-"))
                {
                    // Eliminar el signo negativo
                    cajaResultado.Text = cajaResultado.Text.Substring(1);
                }
                else
                {
                    // Agregar un signo negativo
                    cajaResultado.Text = "-" + cajaResultado.Text;
                }
            }
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            // Verificar que la pantalla de entrada no esté vacía
            if (!string.IsNullOrEmpty(cajaResultado.Text))
            {
                // Verificar si el punto decimal ya está presente
                if (!cajaResultado.Text.Contains("."))
                {
                    // Agregar el punto decimal al texto de entrada
                    cajaResultado.Text += ".";
                }
            }
            else
            {
                // Si la pantalla está vacía, agregar "0." para iniciar un número decimal
                cajaResultado.Text = "0.";
            }

            // Actualizar el historial con el punto decimal
            historial += ".";
            textHistorial.Text = historial;
        }


    }
}
