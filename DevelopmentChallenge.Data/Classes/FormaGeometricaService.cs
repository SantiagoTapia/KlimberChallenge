/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Resources;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometricaService
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;

        #endregion

        ResourceManager _resourceManager;

        public FormaGeometricaService(int idioma)
        {
            _resourceManager = new ResourceManager("DevelopmentChallenge.Data.Textos", typeof(FormaGeometricaService).Assembly);

            switch (idioma)
            {
                case Castellano:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");   //create culture for vietnamese
                    break;
                case Ingles:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");   //create culture for vietnamese
                    break;
                default:
                    Console.WriteLine("Idioma no soportado");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");   //create culture for vietnamese
                    break;
            }
        }
        public string Imprimir(List<IFormaGeometrica> formas)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(_resourceManager.GetString("ListaVacia"));
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append(_resourceManager.GetString("Titulo"));

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;

                foreach(var forma  in formas)
                {
                    if(forma is Cuadrado cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += cuadrado.CalcularArea();
                        perimetroCuadrados += cuadrado.CalcularPerimetro();
                    }
                    else if (forma is Circulo circulo)
                    {
                        numeroCuadrados++;
                        areaCuadrados += circulo.CalcularArea();
                        perimetroCuadrados += circulo.CalcularPerimetro();
                    }
                    else if (forma is Trapecio trapecio)
                    {
                        numeroCuadrados++;
                        areaCuadrados += trapecio.CalcularArea();
                        perimetroCuadrados += trapecio.CalcularPerimetro();
                    }
                    else if (forma is TrianguloEquilatero trianguloEq)
                    {
                        numeroCuadrados++;
                        areaCuadrados += trianguloEq.CalcularArea();
                        perimetroCuadrados += trianguloEq.CalcularPerimetro();
                    }
                    else
                    {
                        Console.WriteLine("Forma desconocida");
                    }
                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero));

                // FOOTER
                sb.Append(_resourceManager.GetString("Total"));
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + _resourceManager.GetString("Formas") + " ");
                sb.Append(_resourceManager.GetString("Perimetro") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                sb.Append(_resourceManager.GetString("Area") + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            }

            return sb.ToString();
        }

        private string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad)} | {_resourceManager.GetString("Area")}  {area:#.##} | {_resourceManager.GetString("Perimetro")} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private string TraducirForma(int tipo, int cantidad)
        {
            switch (tipo)
            {
                case Cuadrado:
                    return cantidad == 1 ? _resourceManager.GetString("FG_Cuadrado") : _resourceManager.GetString("FG_Cuadrados");
                case Circulo:
                    return cantidad == 1 ? _resourceManager.GetString("FG_Circulo") : _resourceManager.GetString("FG_Circulos");
                case TrianguloEquilatero:
                    return cantidad == 1 ? _resourceManager.GetString("FG_Triangulo") : _resourceManager.GetString("FG_Triangulos");
            }

            return string.Empty;
        }

    }
}
