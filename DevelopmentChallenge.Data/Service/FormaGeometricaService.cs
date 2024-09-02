﻿/******************************************************************************************************************/
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
using DevelopmentChallenge.Data.Modelos;
using DevelopmentChallenge.Data.Classes;

namespace DevelopmentChallenge.Data.Service
{
    public class FormaGeometricaService
    {
        ResourceManager _resourceManager;

        public FormaGeometricaService(Idioma idioma)
        {
            _resourceManager = new ResourceManager("DevelopmentChallenge.Data.Textos", typeof(FormaGeometricaService).Assembly);

            switch (idioma)
            {
                case Idioma.Castellano:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");  
                    break;
                case Idioma.Ingles:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");   
                    break;
                default:
                    Console.WriteLine("Idioma no soportado");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");   
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

                Dictionary<FormasGeometricas, (int, decimal, decimal)> calculo = new Dictionary<FormasGeometricas, (int, decimal, decimal)>();
                foreach(var forma  in formas)
                {

                    if(forma is Cuadrado cuadrado)
                    {
                        ActualizarOCrearEntrada(calculo, FormasGeometricas.Cuadrado, cuadrado.CalcularArea(), cuadrado.CalcularPerimetro());
                    }
                    else if (forma is Circulo circulo)
                    {
                        ActualizarOCrearEntrada(calculo, FormasGeometricas.Circulo, circulo.CalcularArea(), circulo.CalcularPerimetro());
                    }
                    else if (forma is TrianguloEquilatero trianguloEq)
                    {
                        ActualizarOCrearEntrada(calculo, FormasGeometricas.TrianguloEquilatero, trianguloEq.CalcularArea(), trianguloEq.CalcularPerimetro());
                    }
                    else
                    {
                        Console.WriteLine("Forma desconocida");
                    }
                }


                foreach (var item in calculo)
                {
                    sb.Append(ObtenerLinea(calculo, item.Key)); 
                }

                // FOOTER
                sb.Append(_resourceManager.GetString("Total"));
                sb.Append(calculo.Values.Sum(t => t.Item1) + " " + _resourceManager.GetString("Formas") + " ");
                sb.Append(_resourceManager.GetString("Area") + " " + (calculo.Values.Sum(t => t.Item2)).ToString("#.##") + " ");
                sb.Append(_resourceManager.GetString("Perimetro") + " " + (calculo.Values.Sum(p => p.Item3)).ToString("#.##") + " ");
            }

            return sb.ToString();
        }

        private void ActualizarOCrearEntrada(Dictionary<FormasGeometricas, (int, decimal, decimal)> col, FormasGeometricas tipo, decimal area, decimal perimetro)
        {
            if (col.TryGetValue(tipo, out var currentValues))
            {
                col[tipo] = (currentValues.Item1 + 1, currentValues.Item2 + area, currentValues.Item3 + perimetro);
            }
            else
            {
                col.Add(tipo, (1, area, perimetro));
            }
        }

        private string ObtenerLinea(Dictionary<FormasGeometricas, (int, decimal, decimal)> col, FormasGeometricas tipo)
        {
            if (col.TryGetValue(tipo, out var currentValues))
            {
                return $"{col[tipo].Item1} {TraducirForma(tipo, col[tipo].Item1)} | {_resourceManager.GetString("Area")}  {col[tipo].Item2:#.##} | {_resourceManager.GetString("Perimetro")} {col[tipo].Item3:#.##} <br/>";
            }

            return string.Empty;
        }
        private string TraducirForma(FormasGeometricas tipo, int cantidad)
        {
            return cantidad == 1 ? _resourceManager.GetString($"FGS_{tipo}") : _resourceManager.GetString($"FGP_{tipo}");
        }
    }
}

