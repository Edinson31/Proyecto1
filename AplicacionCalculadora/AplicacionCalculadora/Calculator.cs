using System;

namespace AplicacionCalculadora
{
    public static class Calculator
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;

        public static double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("División por cero.");
            return a / b;
        }

        public static double Square(double a) => a * a;
        public static double Sqrt(double a)
        {
            if (a < 0) throw new ArgumentException("No se puede sacar la raíz de número negativo.");
            return Math.Sqrt(a);
        }

        // Opcional 1: Potencia x^y
        public static double Power(double a, double b) => Math.Pow(a, b);

        // Opcional 2: Porcentaje (ejemplo sencillo: a % de b -> (a/100)*b)
        // Aquí lo interpretamos como "porcentaje de" cuando se presiona % entre dos números:
        public static double PercentOf(double percent, double ofValue) => (percent / 100.0) * ofValue;
    }
}

