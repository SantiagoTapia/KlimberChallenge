using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Modelos;
using DevelopmentChallenge.Data.Service;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        List<IFormaGeometrica> formasGeometricas = new List<IFormaGeometrica> { new Cuadrado(5) };

        [Test]
        [TestCase(Idioma.Ingles, "<h1>Empty list of shapes!</h1>")]
        [TestCase(Idioma.Castellano, "<h1>Lista vacía de formas!</h1>")]
        [TestCase(Idioma.Italiano, "<h1>Elenco vuoto di forme</h1>")]
        public void TestResumenListaVacia(Idioma idioma, string result)
        {
            FormaGeometricaService formaService = new FormaGeometricaService(idioma);
            Assert.That(result == formaService.Imprimir(new List<IFormaGeometrica>()));
        }


        //[TestCase(Idioma.Ingles, ]
        [TestCase(Idioma.Castellano, "<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 Formas Area 25 Perimetro 20")]
        [TestCase(Idioma.Ingles, "<h1>Shapes report</h1>1 Square | Area 25 | Perimeter 20 <br/>TOTAL:<br/>1 Shapes Area 25 Perimeter 20")]
        [TestCase(Idioma.Italiano, "<h1>Rapporto sui moduli</h1>1 Piazza | Zona 25 | Perimetro 20 <br/>Totale1 Forme Zona 25 Perimetro 20")]
        public void TestResumenListaConUnCuadrado(Idioma idioma, string result)
        {
            var cuadrados = new List<IFormaGeometrica> {new Cuadrado(5)};

            FormaGeometricaService formaService = new FormaGeometricaService(idioma);
            var resumen = formaService.Imprimir(cuadrados);

            Assert.That(result == resumen);
        }

        [TestCase(Idioma.Castellano, "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Circulos | Area 13,01 | Perimetro 18,06 <br/>3 Triangulos | Area 49,64 | Perimetro 51,6 <br/>1 Rectangulo | Area 8 | Perimetro 12 <br/>1 Trapezio | Area 42,5 | Perimetro 19 <br/>TOTAL:<br/>9 Formas Area 142,15 Perimetro 128,66")]
        [TestCase(Idioma.Ingles, "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>1 Rectangle | Area 8 | Perimeter 12 <br/>1 Trapezium | Area 42,5 | Perimeter 19 <br/>TOTAL:<br/>9 Shapes Area 142,15 Perimeter 128,66")]
        [TestCase(Idioma.Italiano, "<h1>Rapporto sui moduli</h1>2 Piazze | Zona 29 | Perimetro 28 <br/>2 Cerchi | Zona 13,01 | Perimetro 18,06 <br/>3 Triangoli | Zona 49,64 | Perimetro 51,6 <br/>1 Rettangolo | Zona 8 | Perimetro 12 <br/>1 Trapezio | Zona 42,5 | Perimetro 19 <br/>Totale9 Forme Zona 142,15 Perimetro 128,66")]
        public void TestResumenListaConMasTipos(Idioma idioma, string result)
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
                new Rectangulo(2,4),
                new Trapecio(10, 7, 1,1, 5)
            };

            FormaGeometricaService formaService = new FormaGeometricaService(idioma);
            var resumen = formaService.Imprimir(formas);

            Assert.That(result == resumen);
        }
    }
}
