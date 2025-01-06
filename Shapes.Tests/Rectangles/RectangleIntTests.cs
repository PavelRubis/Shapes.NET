using Shapes.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Tests.Rectangles
{
    public class RectangleIntTests
    {
        [Theory]
        [InlineData(5, -5)]
        [InlineData(5, 0)]
        public void TryCreateWithInvalidSides(int a, int b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var rectangle = Rectangle<int>.CreateWithSides(a, b);
            });
        }

        //[Theory]
        //[InlineData(5, int.MaxValue)]
        //public void TryCreateWithOverflow(int a, int b)
        //{
        //    Assert.Throws<OverflowException>(() =>
        //    {
        //        var rectangle = Rectangle<int>.CreateWithSides(a, b);
        //        var v = rectangle.Area;
        //    });
        //}

        [Theory]
        [InlineData(5d, 6d)]
        public void Create(int a, int b)
        {
            Assert.Equal(a * b, Rectangle<int>.CreateWithSides(a, b).Area);
        }
    }
}
