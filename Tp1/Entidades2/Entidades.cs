using System;
using System.Data.Common;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Entidades
{
    
    public class Numero
    {
       
        private double numero;
        
        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        public static double operator + (Numero num1, Numero num2)
        {
            Numero resultado = new Numero(num1.numero + num2.numero);
            return resultado.numero;
        }

        public static double operator -(Numero num1, Numero num2)
        {
            Numero resultado = new Numero(num1.numero - num2.numero);
            return resultado.numero;
        }

        public static double operator /(Numero num1, Numero num2)
        {
            Numero resultado = new Numero(num1.numero / num2.numero);
            return resultado.numero;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            Numero resultado = new Numero(num1.numero * num2.numero);
            return resultado.numero;
        }


        public string BinarioDecimal(string binario)
        {
            string decim = null;
            int control = 0;

            foreach (char c in binario)
                if (c == '0' || c == '1')
                {
                    control++;
                }

            if (control == binario.Length)
            {
                decim = Convert.ToString(Convert.ToInt64(binario, 2));
                return decim;
            }

            return decim;

        }

        public string DecimalBinario(double numero)
        {
            string binario;
            binario = Convert.ToString(Convert.ToInt32(Math.Abs(numero)), 2);
            return binario;
                    
        }

        public string DecimalBinario(string numero)
        {
            string binario = null;

            if (double.TryParse(numero, out double val))
            {
                binario = DecimalBinario(val);
                return binario;
            }
            else
            {
                return binario;
            }
        }



        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        
        }

        public Numero(string numero) 
        {
            this.numero = Convert.ToDouble(numero);
        }

        private double ValidarNumero(string strNumero)
        {
            double num = 0;

            if (double.TryParse(strNumero, out double val))
            {
                num = double.Parse(strNumero);
                return num;
            }
            return num;
        }

    }


    public static class Calculadora
    {

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    return (num1 + num2);

                case "-":
                     return (num1 - num2);

                case "/":

                    if ((num1/num2).ToString() == "∞" || (num1/num2).ToString() == "NaN")
                    {
                        return double.MinValue;
                    }
                    return (num1 / num2);

                case "*":
                     return (num1 * num2);

                default:
                    return (num1 + num2);
            }           
        }

        private static string ValidarOperador(string operador) 
        {
            string validacion = "+";

            if (operador == "-" || operador == "/" || operador == "*")
            {
                validacion = operador;
                return validacion;
            }
            return validacion;
        }
    }
}
