using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Modelos;
using DevelopmentChallenge.Data.Service;
using System;
using System.Collections.Generic;

namespace KlimberChallengeApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("KlimberChallengeApp");

            Console.WriteLine("Seleccione un idioma y presione enter");
            Console.WriteLine($"Presione {Idioma.Castellano.GetHashCode()} para: {Idioma.Castellano}");
            Console.WriteLine($"Presione {Idioma.Ingles.GetHashCode()} para: {Idioma.Ingles}");
            Console.WriteLine($"Presione {Idioma.Italiano.GetHashCode()} para: {Idioma.Italiano}");
            Idioma idiomaElegido = Idioma.Castellano;

            try
            {
                int i = int.Parse(Console.ReadLine());
                idiomaElegido = i > 0 && i<=3 ? (Idioma)i : idiomaElegido;
            }
            catch 
            {
                Console.WriteLine($"Idioma no encontrado, se usara {Idioma.Castellano.ToString()} por defecto");
            }

            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                //new Circulo(3),
                //new TrianguloEquilatero(4),
                //new Cuadrado(2),
                //new TrianguloEquilatero(9),
                //new Circulo(2.75m),
                //new TrianguloEquilatero(4.2m)
            };


            var formaService = new FormaGeometricaService(idiomaElegido);

            var texto = formaService.Imprimir(formas);
            Console.WriteLine(texto);

            Console.WriteLine($"\n + {texto.Replace("<br/>", "\n").Replace("</h1>", "</h1>\n")}");
            Console.ReadLine();


        }
    }
}
