namespace PipeLine.AddInfoToFile.Interfaces
{
    public interface IStep<TIn, TOut>
    {
        TOut Execute(TIn model);
    }
}
