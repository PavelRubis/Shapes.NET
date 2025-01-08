using Shapes.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Core.Implementations
{
    /// <summary>
    /// Represents a triangle with sides named "<c>A</c>", "<c>B</c>" and "<c>C</c>". Values of sides and all other props constrained by type
    /// <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of all triangle's props. MUST implements <see cref="INumber{T}"/> and <see cref="IRootFunctions{T}"/> interfaces.</typeparam>
    public class Triangle<T> : IShape<T> where T : IFloatingPoint<T>, IRootFunctions<T>
    {
        /// <summary>Gets the triangle's side, named as "<c>A</c>".</summary>
        public T A { get; private set; }

        /// <summary>Gets the triangle's side, named as "<c>B</c>".</summary>
        public T B { get; private set; }

        /// <summary>Gets the triangle's side, named as "<c>C</c>".</summary>
        public T C { get; private set; }

        private T _area;
        private bool? _isRightAngled;
        private bool _areaCalculated;

        private Triangle(T a, T b, T c)
        {
            this.A = a;
            B = b;
            C = c;
        }

        public T Area
        {
            get
            {
                if (_areaCalculated)
                {
                    return _area;
                }

                var p = (this.A + B + C) / (T.One + T.One);
                _area = T.Sqrt((p * (p - this.A) * (p - B) * (p - C)));
                _areaCalculated = true;
                return _area;
            }
        }

        /// <summary>
        /// Returns <c>true</c> if one of the triangle's angles is exactly 90 degrees. <c>false</c> otherwise.
        /// </summary>
        public bool IsRightAngled
        {
            get
            {
                if (_isRightAngled.HasValue)
                {
                    return _isRightAngled.Value;
                }
                T[] sides = [this.A, B, C];
                var maxSide = sides.Max();
                var otherSide1 = default(T);
                var otherSide2 = default(T);

                switch (true)
                {
                    case true when maxSide == this.A:
                        otherSide1 = B;
                        otherSide2 = C;
                        break;
                    case true when maxSide == B:
                        otherSide1 = this.A;
                        otherSide2 = C;
                        break;
                    case true when maxSide == C:
                        otherSide1 = this.A;
                        otherSide2 = B;
                        break;
                }

                if (_areaCalculated) // reducing implicit side effects)
                {
                    return _area == otherSide1 * otherSide2 / (T.One + T.One);
                }

                var res = maxSide * maxSide == (otherSide1 * otherSide1) + (otherSide2 * otherSide2);
                return res;
            }
        }

        /// <summary>
        /// Creates a triangle with specified sides (<paramref name="a"/>, <paramref name="b"/>, <paramref name="c"/>) of type
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <param name="a">The triangle's side "<c>A</c>".</param>
        /// <param name="b">The triangle's side "<c>B</c>".</param>
        /// <param name="c">The triangle's side "<c>C</c>".</param>
        /// <returns>A new instance of <see cref="Triangle{T}"><c>Triangle</c></see></returns>
        /// <exception cref="ArgumentOutOfRangeException">The triangle can not be presented by type <typeparamref name="T" /> or impossible.</exception>
        public static Triangle<T> CreateWithSides(T a, T b, T c)
        {
            T[] sides = [a, b, c];
            if (sides.Any(side => side <= T.Zero || !T.IsRealNumber(side)) || !Triangle<T>.SidesFitTriangleEquation(a, b, c))
            {
                throw new ArgumentOutOfRangeException(nameof(a) + ", " + nameof(b) + ", " + nameof(c), "Triangle with sides " + a + ", " + b + ", " + c + " is impossible.");
            }
            if (!Triangle<T>.IsTypeFitsTriangleWithSides(a, b, c))
            {
                throw new ArgumentOutOfRangeException(nameof(a) + ", " + nameof(b) + ", " + nameof(c), "Triangle with sides " + a + ", " + b + ", " + c + " can not be presented by " + typeof(T).FullName + " type.");
            }
            return new Triangle<T>(a, b, c);
        }

        private static bool SidesFitTriangleEquation(T a, T b, T c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        private static bool IsTypeFitsTriangleWithSides(T a, T b, T c)
        {
            var area = T.Zero;
            try
            {
                checked
                {
                    var p = (a + b + c) / (T.One + T.One);
                    area = T.Sqrt((p * (p - a) * (p - b) * (p - c)));
                }
            }
            catch (OverflowException)
            {
                return false;
            }
            return !T.IsPositiveInfinity(area);
        }
    }
}
