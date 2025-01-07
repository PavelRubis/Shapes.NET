using Shapes.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Core.Implementations
{
    public class Circle<T> : IShape<T> where T : IFloatingPoint<T>
    {
        private T _radius;
        private T _area;
        private bool _areaCalculated;

        private Circle(T radius)
        {
            _radius = radius;
        }

        public T Area
        {
            get
            {
                if (_areaCalculated)
                {
                    return _area;
                }
                _area = T.Pi * _radius * _radius;
                _areaCalculated = true;
                return _area;
            }
        }

        public static Circle<T> CreateWithRadius(T radius)
        {
            if (!T.IsPositive(radius) || !T.IsRealNumber(radius))
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "The circle with radius " + radius + " " + "is impossible.");
            }
            if (!Circle<T>.IsTypeFitsCircleWithRadius(radius))
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "The circle with radius " + radius + " " + "can not be presented via " + typeof(T).FullName + " type.");
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
