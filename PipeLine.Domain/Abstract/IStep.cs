namespace PipeLine.Domain.Abstract
{
    public interface IStep<TIn, TOut>
    {
        TOut Execute(TIn model);
    }
}
