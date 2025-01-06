using System.Numerics;

namespace Shapes.Core.Contracts
{
    public interface IShape<T> where T : INumberBase<T>
    {
        T Area { get; }
    }
}
