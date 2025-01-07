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
            if (sides.Any(side => side <= T.Zero || !T.IsRealNumber(side)))
            {
                throw new ArgumentOutOfRangeException(nameof(a) + ", " + nameof(b), "Rectangle with sides " + a + ", " + b + " is impossible.");
            }
            if (!Rectangle<T>.IsTypeFitsRectangleWithSides(a, b))
            {
                throw new ArgumentOutOfRangeException(nameof(a) + ", " + nameof(b), "Rectangle with sides " + a + ", " + b + " " + "can not be presented via " + typeof(T).FullName + " type.");
            }
            return new Rectangle<T>(a, b);
        }

        private static bool IsTypeFitsRectangleWithSides(T a, T b)
        {
            var area = T.Zero;
            try
            {
                area = checked(a * b);
            }
            catch (OverflowException)
            {
                return false;
            }
            return !T.IsPositiveInfinity(area);
        }
    }
}
