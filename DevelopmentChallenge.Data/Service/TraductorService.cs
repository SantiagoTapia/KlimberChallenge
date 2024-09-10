using DevelopmentChallenge.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Service
{
    internal class TraductorService
    {
        ResourceManager _resourceManager;
        public TraductorService(Idioma idioma)
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
                case Idioma.Italiano:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("it-IT");
                    break;
                default:
                    Console.WriteLine("Idioma no soportado");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");
                    break;
            }
        }


        public string TraducirTexto(string texto)
        {
            return _resourceManager.GetString(texto);
        }
        public string TraducirForma(string tipo, int cantidad)
        {
            return cantidad == 1 ? _resourceManager.GetString($"FGS_{tipo}") : _resourceManager.GetString($"FGP_{tipo}");
        }
    }
}
