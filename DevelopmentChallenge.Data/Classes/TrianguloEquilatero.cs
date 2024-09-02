using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    internal class TrianguloEquilatero : IFormaGeometrica
    {
        private readonly decimal _lado;
        public int Tipo { get; set; }

        public TrianguloEquilatero(decimal ancho)
        {
            _lado = ancho;
        }

        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public string TraducirForma(int tipo, int cantidad, int idioma)
        {
            throw new NotImplementedException();
        }
    }
}
