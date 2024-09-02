using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : IFormaGeometrica
    {
        private readonly decimal _lado;
        public int Tipo { get; set; }

        public Circulo(decimal ancho)
        {
            _lado = ancho;
        }
        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _lado;
        }

        public string TraducirForma(int tipo, int cantidad, int idioma)
        {
            throw new NotImplementedException();
        }
    }
}
