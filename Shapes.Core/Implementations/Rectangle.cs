using Shapes.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Core.Implementations
{
    public class Rectangle<T> : IShape<T> where T : INumber<T>
    {
        private T _a;
        private T _b;
        private T _area;
        private bool _areaCalculated;

        private Rectangle(T a, T b)
        {
            _a = a;
            _b = b;
        }

        public T Area
        {
            get
            {
                if (_areaCalculated)
                {
                    return _area;
                }

                _area = _a * _b;
                _areaCalculated = true;
                return _area;
            }
        }

        public static Rectangle<T> CreateWithSides(T a, T b)
        {
            T[] sides = [a, b];
            if (sides.All(side => side > T.Zero && T.IsRealNumber(side) && !T.IsPositiveInfinity(side)))
            {
                return new Rectangle<T>(a, b);
            }
            throw new ArgumentOutOfRangeException("The rectangle with sides " + a + ", " + b + " is impossible.");
        }
    }
}
