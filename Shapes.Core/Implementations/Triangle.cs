using Shapes.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Core.Implementations
{
    public class Triangle<T> : IShape<T> where T : INumber<T>, IRootFunctions<T>
    {
        private T _a;
        private T _b;
        private T _c;
        private T _area;
        private bool? _isRightAngled;
        private bool _areaCalculated;

        private Triangle(T a, T b, T c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public T Area
        {
            get
            {
                if (_areaCalculated)
                {
                    return _area;
                }

                var p = (_a + _b + _c) / (T.One + T.One);
                _area = T.Sqrt((p * (p - _a) * (p - _b) * (p - _c)));
                _areaCalculated = true;
                return _area;
            }
        }

        public bool IsRightAngled
        {
            get
            {
                if (_isRightAngled.HasValue)
                {
                    return _isRightAngled.Value;
                }
                T[] sides = [_a, _b, _c];
                var maxSide = sides.Max();
                var otherSide1 = default(T);
                var otherSide2 = default(T);

                switch (true)
                {
                    case true when maxSide == _a:
                        otherSide1 = _b;
                        otherSide2 = _c;
                        break;
                    case true when maxSide == _b:
                        otherSide1 = _a;
                        otherSide2 = _c;
                        break;
                    case true when maxSide == _c:
                        otherSide1 = _a;
                        otherSide2 = _b;
                        break;
                }

                var res = maxSide * maxSide == (otherSide1 * otherSide1) + (otherSide2 * otherSide2);
                return res;
            }
        }

        public static Triangle<T> CreateWithSides(T a, T b, T c)
        {
            T[] sides = [a, b, c];
            if (sides.All(side => T.IsPositive(side) && T.IsRealNumber(side) && !T.IsPositiveInfinity(side)) && Triangle<T>.SidesFitTriangleEquation(a, b, c))
            {
                return new Triangle<T>(a, b, c);
            }
            throw new ArgumentOutOfRangeException("The triangle with sides " + a + ", " + b + ", " + c + " is impossible.");
        }

        private static bool SidesFitTriangleEquation(T a, T b, T c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}
