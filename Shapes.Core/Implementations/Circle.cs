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
    /// Represents a circle which props possible values constrained by type
    /// <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of all circle's props. MUST implements <see cref="IFloatingPoint{T}"/> interface.</typeparam>
    public class Circle<T> : IShape<T> where T : IFloatingPoint<T>
    {
        /// <summary>Gets the circle's radius.</summary>
        public T Radius { get; private set; }

        private T _area;
        private bool _areaCalculated;

        private Circle(T radius)
        {
            this.Radius = radius;
        }

        public T Area
        {
            get
            {
                if (_areaCalculated)
                {
                    return _area;
                }
                _area = T.Pi * this.Radius * this.Radius;
                _areaCalculated = true;
                return _area;
            }
        }

        /// <summary>
        /// Creates a circle with specified <paramref name="radius"/> of type
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <param name="radius">The new circle's radius.</param>
        /// <returns>A new instance of <see cref="Circle{T}"><c>Circle</c></see></returns>
        /// <exception cref="ArgumentOutOfRangeException">The circle can not be presented by type <typeparamref name="T" /> or impossible.</exception>
        public static Circle<T> CreateWithRadius(T radius)
        {
            if (!T.IsPositive(radius) || !T.IsRealNumber(radius))
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "The circle with radius " + radius + " " + "is impossible.");
            }
            if (!Circle<T>.IsTypeFitsCircleWithRadius(radius))
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "The circle with radius " + radius + " " + "can not be presented by " + typeof(T).FullName + " type.");
            }
            return new Circle<T>(radius);
        }

        private static bool IsTypeFitsCircleWithRadius(T radius)
        {
            var area = T.Zero;
            try
            {
               area = checked(T.Pi * radius * radius);
            }
            catch (OverflowException)
            {
                return false;
            }
            return !T.IsPositiveInfinity(area);
        }
    }
}
