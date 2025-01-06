using Shapes.Core.Implementations;

namespace Shapes.Tests.Circles
{
    // Tests ensures fitting the equation of a circle whith is
    // (x - a)^2 + (y - b)^2 = r^2, where (a, b) are coordinates of circle center and r is the radius.
    public class CircleFloatTests
    {
        [Theory]
        [InlineData(float.NaN)]
        [InlineData(float.NegativeInfinity)]
        [InlineData(-float.Pi)]
        [InlineData(float.NegativeZero)]
        [InlineData(float.PositiveInfinity)]
        public void TryCreateWithInvalidRadius(float radius)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var circle = Circle<float>.CreateWithRadius(radius);
            });
        }

        [Theory]
        [InlineData(float.MaxValue)]
        public void CreateWithInfiniteArea(float radius)
        {
            var circle = Circle<float>.CreateWithRadius(radius);
            Assert.Equal(circle.Area, float.PositiveInfinity);
        }

        [Theory]
        [InlineData(0f)]
        [InlineData(float.Pi)]
        public void CalculateAndVerifyArea(float radius)
        {
            Assert.Equal(Math.PI * radius * radius, Circle<float>.CreateWithRadius(radius).Area);
        }
    }
}