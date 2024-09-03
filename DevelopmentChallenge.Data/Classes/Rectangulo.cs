using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : IFormaGeometrica
    {
        private readonly decimal _ancho;
        private readonly decimal _largo;

        public int Tipo { get; set; }

        public Rectangulo(decimal ancho, decimal largo)
        {
            _ancho = ancho;
            _largo = largo;
        }
        public decimal CalcularArea()
        {
            return _ancho * _largo;
        }

        public decimal CalcularPerimetro()
        {
            return (2 * _ancho) + (2 * _largo);
        }

        string IFormaGeometrica.TraducirForma(int tipo, int cantidad, int idioma)
        {
            throw new NotImplementedException();
        }
    }
}
