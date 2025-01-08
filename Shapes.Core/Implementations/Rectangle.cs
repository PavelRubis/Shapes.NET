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
    /// Represents a rectangle with sides named "<c>A</c>" and "<c>B</c>". Values of sides and all other props constrained by type
    /// <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of all rectangle's props. MUST implements <see cref="INumber{T}"/> interface.</typeparam>
    public class Rectangle<T> : IShape<T> where T : INumber<T>
    {
        /// <summary>Gets the rectangle's side, named as "<c>A</c>".</summary>
        public T A { get; private set; }

        /// <summary>Gets the rectangle's side, named as "<c>B</c>".</summary>
        public T B { get; private set; }

        private T _area;
        private bool _areaCalculated;

        private Rectangle(T a, T b)
        {
            this.A = a;
            this.B = b;
        }

        public T Area
        {
            get
            {
                if (_areaCalculated)
                {
                    return _area;
                }

                _area = this.A * this.B;
                _areaCalculated = true;
                return _area;
            }
        }

        /// <summary>
        /// Creates a rectangle with specified sides (<paramref name="a"/>, <paramref name="b"/>) of type
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <param name="a">The rectangle's side "<c>A</c>".</param>
        /// <param name="b">The rectangle's side "<c>B</c>".</param>
        /// <returns>A new instance of <see cref="Rectangle{T}"><c>Rectangle</c></see></returns>
        /// <exception cref="ArgumentOutOfRangeException">The rectangle can not be presented by type <typeparamref name="T" /> or impossible.</exception>
        public static Rectangle<T> CreateWithSides(T a, T b)
        {
            T[] sides = [a, b];
            if (sides.Any(side => side <= T.Zero || !T.IsRealNumber(side)))
            {
                throw new ArgumentOutOfRangeException(nameof(a) + ", " + nameof(b), "Rectangle with sides " + a + ", " + b + " is impossible.");
            }
            if (!Rectangle<T>.IsTypeFitsRectangleWithSides(a, b))
            {
                throw new ArgumentOutOfRangeException(nameof(a) + ", " + nameof(b), "Rectangle with sides " + a + ", " + b + " " + "can not be presented by " + typeof(T).FullName + " type.");
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
