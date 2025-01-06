using Shapes.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Tests.Triangles
{
    public class TriangleDoubleTests
    {
        [Theory]
        [InlineData(3d, 4d, 5d)]
        public void Create(double a, double b, double c)
        {
            var triangle = Triangle<double>.CreateWithSides(a, b, c);
            Assert.Equal(6d, triangle.Area);
        }
    }
}
