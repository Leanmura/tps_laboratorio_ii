using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades
        public string Numero
        {
            set 
            {
                this.numero = this.ValidarOperando(value);            
            }
            
        }
        #endregion

        #region Contructor
        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        #endregion

        #region Metodos

        private bool EsBinario(string binario)
        {
            bool retorno = true;
            foreach (char item in binario)
            {
                if (item != '0' && item != '1')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        private double ValidarOperando(string strNumero)
        {
            double result = 0;
            double.TryParse(strNumero, out result);
            //Console.WriteLine(result);
            return result;
        }

        public string DecimalBinario(string strNumero)
        {
            //this.Numero = strNumero;
            string retorno = "Valor invalido";
            double numero;
            if(double.TryParse(strNumero, out numero))
            {
                retorno = this.DecimalBinario(numero);
            }

            return retorno;
        }

        //public string DecimalBinario(double numero)
        //{
        //    string retorno = ""; //= "Valor invalido";
        //    int numeroInt = (int)numero;
        //    int resto;
        //    if(numeroInt < 0)
        //    {
        //        numeroInt = -numeroInt;
        //    }
        //    while(numeroInt > 0)
        //    {
        //        resto = numeroInt % 2;
        //        numeroInt /= 2;
        //        retorno += resto.ToString();
        //    }
        //    char[] charArray= retorno.ToCharArray();
        //    Array.Reverse(charArray);
        //    retorno = new string(charArray);
        //    return retorno;
        //}
        public string DecimalBinario(double numero)
        {
            string retorno = "Valor invalido";
            int resto;
            if(numero == 0)
            {
                retorno = "0";
            }
            else
            {
                if (numero >= 0 && numero % 1 == 0)
                {
                    retorno = "";
                    while (numero > 0)
                    {
                        resto = (int)numero % 2;
                        numero = (int)numero / 2;
                        retorno += resto.ToString();
                    }
                    char[] charArray = retorno.ToCharArray();
                    Array.Reverse(charArray);
                    retorno = new string(charArray);
                }

            }
            return retorno;
        }

        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            int peso = 1;
            double decimalNumber = 0;
            if (this.EsBinario(binario))
            {
                for(int x = binario.Length-1; x >= 0; x--)
                {
                    if(binario[x] == '1')
                    {
                        decimalNumber += peso;
                    }
                    peso *= 2;
                }

                retorno = decimalNumber.ToString();
            }
            return retorno;
        }
         
        #endregion

        #region Operadores
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Operando dividendo, Operando divisor)
        {
            double retorno = double.MinValue;
            if(divisor.numero != 0)
            {
                retorno = dividendo.numero / divisor.numero;
            }
            return retorno;
        }


        
        #endregion
    }
}
