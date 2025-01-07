using Shapes.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Tests.Triangles
{
    // Tests ensures fitting the triangle existance conditions:
    // a + b > c and a + c > b and b + c > a, where a, b, c are sides of triangle.
    public class TriangleDoubleTests
    {
        [Theory]
        [InlineData(1d, 1d, 5d)]
        [InlineData(3d, 4d, -5d)]
        [InlineData(3d, 4d, double.NaN)]
        [InlineData(3d, 4d, double.NegativeInfinity)]
        [InlineData(3d, 4d, -double.Pi)]
        [InlineData(3d, 4d, 0d)]
        [InlineData(3d, 4d, double.PositiveInfinity)]
        public void TryCreateWithInvalidSides(double a, double b, double c)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var triangle = Triangle<double>.CreateWithSides(a, b, c);
            });
        }

        [Theory]
        [InlineData(3d, 4d, 5d)]
        public void CreateRightAngled(double a, double b, double c)
        {
            var triangle = Triangle<double>.CreateWithSides(a, b, c);
            Assert.Equal(true, triangle.IsRightAngled);
            Assert.Equal(6d, triangle.Area);
        }

        [Theory]
        [InlineData(9d, 10d, 11d)]
        public void CreateNotRightAngled(double a, double b, double c)
        {
            var triangle = Triangle<double>.CreateWithSides(a, b, c);
            Assert.Equal(30d * double.Sqrt(2d), triangle.Area);
            Assert.Equal(false, triangle.IsRightAngled);
        }
    }
}
