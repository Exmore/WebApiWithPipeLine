namespace PipeLine.Domain.Abstract
{
    public interface IStepsAdapter<TIn, TOut>
    {
        TOut Execute(TIn model);
    }
}
