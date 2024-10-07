using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElastoSystem
{
    public static class VariablesGlobales
    {
        public static string Usuario {  get; set; }
        /*
        public static string ConexionElastoSystem = "server=10.120.1.3 ; username=root; password=; database=elastosystem";
        public static string ConexionElastotec = "server=10.120.1.3 ; username=root; password=; database=elastotec";
        public static string ConexionLocal = "server=localhost ; username=root; password=; database=elastosystem";
        */
        public static string IPServidor = "10.120.1.104";
        public static string ConexionBDElastotecnica = $"server={IPServidor} ; username=root; password=; database=elastosystem";

        public class ConvertidorNumerosALetrasPESOS
        {
            private static readonly string[] Unidades = { "", "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE" };
            private static readonly string[] Decenas = { "", "DIEZ", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA" };
            private static readonly string[] DiezAVeinte = { "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE", "DIECISEIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE" };
            private static readonly string[] Centenas = { "", "CIEN", "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS" };

            public static string ConvertirNumeroALetras(decimal numero)
            {
                // Dividir el número en partes enteras y decimales
                int parteEntera = (int)numero;
                int parteDecimal = (int)((numero - parteEntera) * 100);

                // Convertir la parte entera a letras
                string parteEnteraEnLetras = ConvertirParteEnteraALetras(parteEntera);

                // Convertir la parte decimal a letras
                string parteDecimalEnLetras = ConvertirParteDecimalALetras(parteDecimal);

                // Combinar las partes en una sola cadena
                string resultado = parteEnteraEnLetras + " PESOS " + parteDecimalEnLetras + " CENTAVOS";

                return resultado;
            }

            private static string ConvertirParteEnteraALetras(int parteEntera)
            {
                if (parteEntera == 0)
                {
                    return "CERO";
                }

                string letras = "";

                if (parteEntera >= 1000000 && parteEntera <= 999999999)
                {
                    int millones = parteEntera / 1000000;
                    letras += (millones == 1) ? "UN MILLON" : ConvertirParteEnteraALetras(millones) + " MILLONES";
                    parteEntera %= 1000000;
                }

                if (parteEntera >= 1000 && parteEntera <= 999999)
                {
                    int miles = parteEntera / 1000;
                    letras += (miles == 1) ? " MIL" : ConvertirParteEnteraALetras(miles) + " MIL";
                    parteEntera %= 1000;
                }

                if (parteEntera >= 100)
                {
                    int centenas = parteEntera / 100;
                    letras += " " + Centenas[centenas];
                    parteEntera %= 100;
                }

                if (parteEntera >= 10)
                {
                    if (parteEntera < 20)
                    {
                        letras += " " + DiezAVeinte[parteEntera - 10];
                        parteEntera = 0;
                    }
                    else
                    {
                        int decenas = parteEntera / 10;
                        letras += " " + Decenas[decenas];
                        parteEntera %= 10;
                    }
                }

                if (parteEntera > 0)
                {
                    letras += " " + Unidades[parteEntera];
                }

                return letras.Trim();
            }

            private static string ConvertirParteDecimalALetras(int parteDecimal)
            {
                if (parteDecimal == 0)
                {
                    return "CERO";
                }

                string letras = "";

                if (parteDecimal >= 10)
                {
                    if (parteDecimal < 20)
                    {
                        letras += DiezAVeinte[parteDecimal - 10];
                        parteDecimal = 0;
                    }
                    else
                    {
                        int decenas = parteDecimal / 10;
                        letras += Decenas[decenas];
                        parteDecimal %= 10;
                    }
                }

                if (parteDecimal > 0)
                {
                    letras += " " + Unidades[parteDecimal];
                }

                return letras.Trim();
            }
        }

        public class ConvertidorNumerosALetrasUSD
        {
            private static readonly string[] Unidades = { "", "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE" };
            private static readonly string[] Decenas = { "", "DIEZ", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA" };
            private static readonly string[] DiezAVeinte = { "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE", "DIECISEIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE" };
            private static readonly string[] Centenas = { "", "CIEN", "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS" };

            public static string ConvertirNumeroALetras(decimal numero)
            {
                // Dividir el número en partes enteras y decimales
                int parteEntera = (int)numero;
                int parteDecimal = (int)((numero - parteEntera) * 100);

                // Convertir la parte entera a letras
                string parteEnteraEnLetras = ConvertirParteEnteraALetras(parteEntera);

                // Convertir la parte decimal a letras
                string parteDecimalEnLetras = ConvertirParteDecimalALetras(parteDecimal);

                // Combinar las partes en una sola cadena
                string resultado = parteEnteraEnLetras + " DOLARES " + parteDecimalEnLetras + " CENTAVOS";

                return resultado;
            }

            private static string ConvertirParteEnteraALetras(int parteEntera)
            {
                if (parteEntera == 0)
                {
                    return "CERO";
                }

                string letras = "";

                if (parteEntera >= 1000000 && parteEntera <= 999999999)
                {
                    int millones = parteEntera / 1000000;
                    letras += (millones == 1) ? "UN MILLON" : ConvertirParteEnteraALetras(millones) + " MILLONES";
                    parteEntera %= 1000000;
                }

                if (parteEntera >= 1000 && parteEntera <= 999999)
                {
                    int miles = parteEntera / 1000;
                    letras += (miles == 1) ? " MIL" : ConvertirParteEnteraALetras(miles) + " MIL";
                    parteEntera %= 1000;
                }

                if (parteEntera >= 100)
                {
                    int centenas = parteEntera / 100;
                    letras += " " + Centenas[centenas];
                    parteEntera %= 100;
                }

                if (parteEntera >= 10)
                {
                    if (parteEntera < 20)
                    {
                        letras += " " + DiezAVeinte[parteEntera - 10];
                        parteEntera = 0;
                    }
                    else
                    {
                        int decenas = parteEntera / 10;
                        letras += " " + Decenas[decenas];
                        parteEntera %= 10;
                    }
                }

                if (parteEntera > 0)
                {
                    letras += " " + Unidades[parteEntera];
                }

                return letras.Trim();
            }

            private static string ConvertirParteDecimalALetras(int parteDecimal)
            {
                if (parteDecimal == 0)
                {
                    return "CERO";
                }

                string letras = "";

                if (parteDecimal >= 10)
                {
                    if (parteDecimal < 20)
                    {
                        letras += DiezAVeinte[parteDecimal - 10];
                        parteDecimal = 0;
                    }
                    else
                    {
                        int decenas = parteDecimal / 10;
                        letras += Decenas[decenas];
                        parteDecimal %= 10;
                    }
                }

                if (parteDecimal > 0)
                {
                    letras += " " + Unidades[parteDecimal];
                }

                return letras.Trim();
            }
        }
    }
}
