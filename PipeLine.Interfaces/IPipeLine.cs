using System;
using System.Threading.Tasks;

namespace PipeLine.Interfaces
{
    public interface IPipeLine<TIn, TOut>
    {
        IPipeLine<TIn, TOut> AddStep<TLocalIn, TLocalOut>(Func<TLocalIn, TLocalOut> stepFunc);
        IPipeLine<TIn, TOut> CreatePipeline();
        Task<TOut> Execute(TIn input);
    }
}
