﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;


        public string SetNumero //Propiedad de solo escritura
        {
            set
            {   
                numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Valida que el string recibido por parametro sea un número válido
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        public double ValidarNumero(string strNumero)
        {
            double numeroDouble;

                if (Double.TryParse(strNumero,out numeroDouble))// Revisar validacion y conversión a INT
                {
                    return numeroDouble;
                }
                else
                {
                    return 0;
                }
        }

        /// <summary>
        /// Constructor que setea el atributo número con el valor recibido por párametro
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.SetNumero = Convert.ToString(numero);
        }
        public Numero(): this(0)
        {
        }

        public Numero(string strNumero): this(double.Parse(strNumero))
        {
        }

        /// <summary>
        /// Recibe string por parámetro para descomponer y convertir en numero decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>numero decimal en formato String</returns>
        public string BinarioDecimal(string binario)
        {
            char[] arrayBinario;
            double numeroDecimal;

            if (binario != "Valor inválido.")
            {
                numeroDecimal = 0;
                arrayBinario = binario.ToCharArray();
                Array.Reverse(arrayBinario);

                for (int i = 0; i < arrayBinario.Length; i++)
                {
                    if(arrayBinario[i] > '1') //Verifica que sea realmente un número binario
                    {
                        return "Valor inválido.";
                    }

                    if (arrayBinario[i] == '1') 
                    {
                        numeroDecimal += (int)Math.Pow(2, i); //Se realiza el calculo de conversión a decimal
                    }
                }
                return Convert.ToString(numeroDecimal);
            }
            else
            {
                return "Valor inválido.";
            }
        }

        /// <summary>
        /// Recibe string por parámetro para descomponer y convertir en numero binario
        /// </summary>
        /// <param name="numeroDecimal"></param>
        /// <returns>resultado de la conversion en formato String sino retorna mensaje</returns>
        public string DecimalBinario(double numeroDecimal)
        {
            String resultado = "";

            if (numeroDecimal >= 0)
            {
                while (numeroDecimal > 0)
                {
                    if (numeroDecimal % 2 == 0) //Verifica el resto de la división
                    {
                        resultado = "0" + resultado;//Concatena el resto de la división
                    }
                    else
                    {
                        resultado = "1" + resultado;//Concatena el resto de la división
                    }
                    numeroDecimal = (int)(numeroDecimal / 2); //Sigue dividiendo
                }
            }
            else
            {
                 resultado += "Valor inválido.";
            }
            return resultado;
        }

        public string DecimalBinario(string numeroDecimal)
        {
            if (numeroDecimal != "Valor inválido.")
            {
                return DecimalBinario(double.Parse(numeroDecimal));
            }
            else
            {
                return "Valor invalido";
            }
        }
        

        public static double operator -(Numero primerNumero, Numero segundoNumero)
        {
            return primerNumero.numero - segundoNumero.numero;
        }

        public static double operator +(Numero primerNumero, Numero segundoNumero)
        {
            return primerNumero.numero + segundoNumero.numero;
        }

        public static double operator *(Numero primerNumero, Numero segundoNumero)
        {
            return primerNumero.numero * segundoNumero.numero;
        }

        public static double operator /(Numero primerNumero, Numero segundoNumero)
        {
            if(segundoNumero.numero == 0)
            {
                return double.MinValue;
            }
            return primerNumero.numero / segundoNumero.numero;
        }
    }
}

