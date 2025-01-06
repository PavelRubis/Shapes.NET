using Shapes.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Tests.Rectangles
{
    public class RectangleDoubleTests
    {
        [Theory]
        [InlineData(5d, double.NaN)]
        [InlineData(5d, double.NegativeInfinity)]
        [InlineData(5d, -double.Pi)]
        [InlineData(5d, 0d)]
        [InlineData(5d, double.PositiveInfinity)]
        public void TryCreateWithInvalidSides(double a, double b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var rectangle = Rectangle<double>.CreateWithSides(a, b);
            });
        }

        [Theory]
        [InlineData(5d, 6d)]
        [InlineData(5d, double.Pi)]
        public void Create(double a, double b)
        {
            Assert.Equal(a * b, Rectangle<double>.CreateWithSides(a, b).Area);
        }

        [Theory]
        [InlineData(5d, double.MaxValue)]
        public void CreateWithInfiniteArea(double a, double b)
        {
            var rectangle = Rectangle<double>.CreateWithSides(a, b);
            Assert.Equal(double.PositiveInfinity, rectangle.Area);
        }
    }
}
