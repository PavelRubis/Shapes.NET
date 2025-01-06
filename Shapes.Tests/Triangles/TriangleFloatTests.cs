using Shapes.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Tests.Triangles
{
    public class TriangleFloatTests
    {
        [Theory]
        [InlineData(1f, 1f, 5f)]
        [InlineData(3f, 4f, -5f)]
        public void TryCreateWithInvalidSides(float a, float b, float c)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var triangle = Triangle<float>.CreateWithSides(a, b, c);
            });
        }

        [Theory]
        [InlineData(3f, 4f, 5f)]
        public void CreateRightAngled(float a, float b, float c)
        {
            var triangle = Triangle<float>.CreateWithSides(a, b, c);
            Assert.Equal(true, triangle.IsRightAngled);
            Assert.Equal(6f, triangle.Area);
        }

        [Theory]
        [InlineData(9f, 10f, 11f)]
        public void CreateNotRightAngled(float a, float b, float c)
        {
            var triangle = Triangle<float>.CreateWithSides(a, b, c);
            Assert.Equal(false, triangle.IsRightAngled);
            Assert.Equal(30f * float.Sqrt(2f), triangle.Area);
        }
    }
}
