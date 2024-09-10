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

using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.Modelos;
using DevelopmentChallenge.Data.Classes;

namespace DevelopmentChallenge.Data.Service
{
    public class FormaGeometricaService
    {
        TraductorService _traductorService;
        public FormaGeometricaService(Idioma idioma)
        {
            _traductorService = new TraductorService(idioma);
        }
        public string Imprimir(List<IFormaGeometrica> formas)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(_traductorService.TraducirTexto("ListaVacia"));
            }
            else
            {
                sb.Append(_traductorService.TraducirTexto("Titulo"));

                Dictionary<string, (int, decimal, decimal)> totales = new Dictionary<string, (int, decimal, decimal)>();
                foreach(var forma  in formas)
                {
                    ActualizarOCrearEntrada(totales, forma.GetType().Name, forma.CalcularArea(), forma.CalcularPerimetro());
                }

                foreach (var item in totales)
                {
                    sb.Append(ObtenerLinea(totales, item.Key)); 
                }

                // FOOTER
                sb.Append(_traductorService.TraducirTexto("Total"));
                sb.Append(totales.Values.Sum(t => t.Item1) + " " + _traductorService.TraducirTexto("Formas") + " ");
                sb.Append(_traductorService.TraducirTexto("Area") + " " + (totales.Values.Sum(t => t.Item2)).ToString("#.##") + " ");
                sb.Append(_traductorService.TraducirTexto("Perimetro") + " " + (totales.Values.Sum(p => p.Item3)).ToString("#.##"));
            }

            return sb.ToString();
        }

        private void ActualizarOCrearEntrada(Dictionary<string, (int, decimal, decimal)> totales, string tipo, decimal area, decimal perimetro)
        {
            if (totales.TryGetValue(tipo, out var currentValues))
            {
                totales[tipo] = (currentValues.Item1 + 1, currentValues.Item2 + area, currentValues.Item3 + perimetro);
            }
            else
            {
                totales.Add(tipo, (1, area, perimetro));
            }
        }

        private string ObtenerLinea(Dictionary<string, (int, decimal, decimal)> totales, string tipo)
        {
            if (totales.TryGetValue(tipo, out var currentValues))
            {
                return $"{totales[tipo].Item1} {_traductorService.TraducirForma(tipo, totales[tipo].Item1)} | {_traductorService.TraducirTexto("Area")} {totales[tipo].Item2:#.##} | {_traductorService.TraducirTexto("Perimetro")} {totales[tipo].Item3:#.##} <br/>";
            }

            return string.Empty;
        }
    }
}

