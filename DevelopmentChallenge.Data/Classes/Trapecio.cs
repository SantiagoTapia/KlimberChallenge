using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    internal class Trapecio : IFormaGeometrica
    {

        private readonly decimal _lado;
        public int Tipo { get; set; }

        public Trapecio(decimal ancho)
        {
            _lado = ancho;
        }

        public decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public decimal CalcularPerimetro()
        {
            throw new NotImplementedException();
        }

        public string TraducirForma(int tipo, int cantidad, int idioma)
        {
            throw new NotImplementedException();
        }
    }
}
