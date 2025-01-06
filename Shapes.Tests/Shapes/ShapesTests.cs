using Shapes.Core.Contracts;
using Shapes.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Tests.Shapes
{
    public class ShapesTests
    {
        [Fact]
        public void CalculateAreaForDifferentShapes()
        {
            List<IShape<double>> shapes =
            [
                Circle<double>.CreateWithRadius(double.Pi),
                Triangle<double>.CreateWithSides(3d, 4d, 5d),
                Rectangle<double>.CreateWithSides(3d, 5d),
            ];
            var expectedAreas = new HashSet<double> { double.Pow(double.Pi, 3), 6d, 15d };

            foreach (var shape in shapes)
            {
                Assert.True(expectedAreas.Contains(shape.Area));
            }
        }
    }
}
