using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace AplicacionCalculadora
{
    public partial class MainForm : Form
    {
        private string currentEntry = "0";
        private double? operand = null;
        private string pendingOp = null;
        private bool newEntry = true; // si el siguiente número debe reemplazar el display
        private StringBuilder expressionBuilder = new StringBuilder();

        public MainForm()
        {
            InitializeComponent();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            txtDisplay.Text = currentEntry;
        }

        // manejar click de dígitos y punto
        private void Digit_Click(object sender, EventArgs e)
        {
            var b = (Button)sender;
            string v = b.Text;

            if (newEntry)
            {
                currentEntry = (v == ".") ? "0." : v;
                newEntry = false;
            }
            else
            {
                if (v == "." && currentEntry.Contains(".")) return;
                currentEntry += v;
            }
            UpdateDisplay();
        }

        // signo plus/minus
        private void BtnToggleSign_Click(object sender, EventArgs e)
        {
            if (currentEntry.StartsWith("-")) currentEntry = currentEntry.Substring(1);
            else if (currentEntry != "0") currentEntry = "-" + currentEntry;
            UpdateDisplay();
        }

        // CE (clear entry)
        private void BtnCE_Click(object sender, EventArgs e)
        {
            currentEntry = "0";
            newEntry = true;
            UpdateDisplay();
        }

        // C (clear all)
        private void BtnC_Click(object sender, EventArgs e)
        {
            currentEntry = "0";
            operand = null;
            pendingOp = null;
            newEntry = true;
            expressionBuilder.Clear();
            UpdateDisplay();
        }

        // operaciones binarias (+ - * /, power, percent)
        private void Operator_Click(object sender, EventArgs e)
        {
            var b = (Button)sender;
            string op = b.Tag?.ToString() ?? b.Text;

            if (!double.TryParse(currentEntry, NumberStyles.Any, CultureInfo.InvariantCulture, out double curVal))
            {
                MessageBox.Show("Número no válido.");
                return;
            }

            if (operand == null)
            {
                operand = curVal;
            }
            else if (pendingOp != null && !newEntry)
            {
                // realizar la operación pendiente
                operand = EvaluateBinary((double)operand, curVal, pendingOp);
            }

            pendingOp = op;
            expressionBuilder.Clear();
            expressionBuilder.Append($"{operand} {SymbolForOp(op)} ");
            newEntry = true;
            UpdateDisplay();
        }

        private string SymbolForOp(string op)
        {
            switch (op)
            {
                case "+": return "+";
                case "-": return "-";
                case "*": return "×";
                case "/": return "÷";
                case "POW": return "^";
                case "PCT": return "%";
                default: return op;
            }
        }

        private double EvaluateBinary(double a, double b, string op)
        {
            switch (op)
            {
                case "+": return Calculator.Add(a, b);
                case "-": return Calculator.Subtract(a, b);
                case "*": return Calculator.Multiply(a, b);
                case "/": return Calculator.Divide(a, b);
                case "POW": return Calculator.Power(a, b); // x^y
                case "PCT": return Calculator.PercentOf(a, b); // interpretamos a % de b
                default: throw new InvalidOperationException("Operación desconocida");
            }
        }

        // igual
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(currentEntry, NumberStyles.Any, CultureInfo.InvariantCulture, out double curVal))
            {
                MessageBox.Show("Número no válido.");
                return;
            }

            double result;
            string expr;

            try
            {
                if (pendingOp == null)
                {
                    result = curVal;
                    expr = curVal.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    double left = operand ?? 0;
                    result = EvaluateBinary(left, curVal, pendingOp);
                    expr = $"{left} {SymbolForOp(pendingOp)} {curVal}";
                }

                // mostrar
                currentEntry = result.ToString(CultureInfo.InvariantCulture);
                UpdateDisplay();

                // guardar en BD
                var rec = new CalculationRecord
                {
                    Expression = expr,
                    Result = currentEntry,
                    DatePerformed = DateTime.Now
                };

                try
                {
                    Database.SaveCalculation(rec);
                }
                catch (Exception exDb)
                {
                    MessageBox.Show("No se pudo guardar en la base de datos: " + exDb.Message);
                }

                // reset para próxima operación
                operand = null;
                pendingOp = null;
                newEntry = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular: " + ex.Message);
            }
        }

        // Funciones unarias: cuadrado, raiz
        private void BtnSquare_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(currentEntry, NumberStyles.Any, CultureInfo.InvariantCulture, out double curVal))
            {
                MessageBox.Show("Número no válido.");
                return;
            }
            double res = Calculator.Square(curVal);
            string expr = $"{curVal}²";
            currentEntry = res.ToString(CultureInfo.InvariantCulture);
            UpdateDisplay();

            try
            {
                Database.SaveCalculation(new CalculationRecord { Expression = expr, Result = currentEntry, DatePerformed = DateTime.Now });
            }
            catch (Exception ex) { MessageBox.Show("Error BD: " + ex.Message); }

            newEntry = true;
        }

        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(currentEntry, NumberStyles.Any, CultureInfo.InvariantCulture, out double curVal))
            {
                MessageBox.Show("Número no válido.");
                return;
            }
            try
            {
                double res = Calculator.Sqrt(curVal);
                string expr = $"√({curVal})";
                currentEntry = res.ToString(CultureInfo.InvariantCulture);
                UpdateDisplay();
                Database.SaveCalculation(new CalculationRecord { Expression = expr, Result = currentEntry, DatePerformed = DateTime.Now });
                newEntry = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Botón Mostrar cálculos: abre una ventana simple con la lista
        private void BtnShowCalculations_Click(object sender, EventArgs e)
        {
            var list = Database.GetAllCalculations();
            var sb = new System.Text.StringBuilder();
            foreach (var r in list)
            {
                sb.AppendLine($"{r.DatePerformed:yyyy-MM-dd HH:mm:ss} | {r.Expression} = {r.Result}");
            }
            // mostrar en un MessageBox grande o en un Form sencillo. Usamos un form auxiliar
            var viewer = new CalculationsViewerForm(list);
            viewer.ShowDialog();
        }
    }
}

