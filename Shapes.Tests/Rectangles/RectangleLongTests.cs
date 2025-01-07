using Shapes.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Tests.Rectangles
{
    public class RectangleLongTests
    {
        [Theory]
        [InlineData(5, -5)]
        [InlineData(5, 0)]
        [InlineData(5, long.MaxValue)]
        public void TryCreateWithInvalidSides(long a, long b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var rectangle = Rectangle<long>.CreateWithSides(a, b);
            });
        }

        [Theory]
        [InlineData(5d, 6d)]
        public void Create(long a, long b)
        {
            Assert.Equal(a * b, Rectangle<long>.CreateWithSides(a, b).Area);
        }
    }
}
