using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        private static char ValidarOperador(char operador)
        {
            if(operador != '+' && operador != '-' && operador != '/' && operador != '*')
            {
                operador = '+';
            }
            return operador;
        }

        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double result = 0;
            if(num1 != null && num2 != null)
            {
                switch (Calculadora.ValidarOperador(operador))
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '/':
                        result = num1 / num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                }

            }
            return result;
        }
        #endregion
    }
}
