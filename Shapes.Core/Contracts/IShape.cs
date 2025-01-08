using System.Numerics;

namespace Shapes.Core.Contracts
{
    /// <summary>
    /// Represents a geometric shape which props possible values constrained by type
    /// <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of all shape's props. MUST implements the <see cref="INumberBase{T}"/> interface.</typeparam>
    public interface IShape<T> where T : INumberBase<T>
    {
        /// <summary>Gets the shape's area.</summary>
        T Area { get; }
    }
}
