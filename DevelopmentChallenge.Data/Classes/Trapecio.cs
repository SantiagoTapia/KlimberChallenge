using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : IFormaGeometrica
    {

        private readonly decimal _baseA;
        private readonly decimal _baseB;
        private readonly decimal _catetoC;
        private readonly decimal _catetoD;
        private readonly decimal _altura;

        public Trapecio(decimal baseA, decimal baseB, decimal catetoC, decimal catetoD, decimal altura)
        {
            _baseA = baseA;
            _baseB = baseB;
            _catetoC = catetoC;
            _catetoD = catetoD;
            _altura = altura;
        }

        public decimal CalcularArea()
        {
            return ((_baseA + _baseB) * _altura) / 2;
        }

        public decimal CalcularPerimetro()
        {
            return _baseA + _baseB + _catetoC + _catetoD;
        }
    }
}
