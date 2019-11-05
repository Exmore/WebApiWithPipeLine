using System.Threading.Tasks;

namespace PipeLine.Interfaces
{
    public interface IPipeLine<TIn, TOut>
    {
        Task<TOut> Execute(TIn input);
    }
}
