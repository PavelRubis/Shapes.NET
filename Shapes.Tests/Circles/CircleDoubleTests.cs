using Shapes.Core.Implementations;

namespace Shapes.Tests.Circles
{
    // Tests ensures fitting the equation of a circle whith is
    // (x - a)^2 + (y - b)^2 = r^2, where (a, b) are coordinates of circle center and r is the radius.
    public class CircleDoubleTests
    {
        [Theory]
        [InlineData(double.NaN)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(-double.Pi)]
        [InlineData(double.NegativeZero)]
        [InlineData(double.PositiveInfinity)]
        public void TryCreateWithInvalidRadius(double radius)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var circle = Circle<double>.CreateWithRadius(radius);
            });
        }

        [Theory]
        [InlineData(0d)]
        [InlineData(double.Pi)]
        public void Create(double radius)
        {
            Assert.Equal(double.Pi * radius * radius, Circle<double>.CreateWithRadius(radius).Area);
        }

        [Theory]
        [InlineData(double.MaxValue)]
        public void CreateWithInfiniteArea(double radius)
        {
            var circle = Circle<double>.CreateWithRadius(radius);
            Assert.Equal(double.PositiveInfinity, circle.Area);
        }
    }
}