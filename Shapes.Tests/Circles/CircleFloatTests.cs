using Shapes.Core.Implementations;

namespace Shapes.Tests.Circles
{
    // Tests ensures fitting the equation of a circle:
    // (x - a)^2 + (y - b)^2 = r^2, where (a, b) are coordinates of circle center and r is the radius.
    public class CircleFloatTests
    {
        [Theory]
        [InlineData(float.NaN)]
        [InlineData(float.NegativeInfinity)]
        [InlineData(-float.Pi)]
        [InlineData(float.NegativeZero)]
        [InlineData(float.MaxValue)]
        [InlineData(float.PositiveInfinity)]
        public void TryCreateWithInvalidRadius(float radius)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var circle = Circle<float>.CreateWithRadius(radius);
            });
        }

        [Theory]
        [InlineData(0f)]
        [InlineData(float.Pi)]
        public void Create(float radius)
        {
            Assert.Equal(float.Pi * radius * radius, Circle<float>.CreateWithRadius(radius).Area);
        }
    }
}