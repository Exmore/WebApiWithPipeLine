namespace PipeLine.AddInfoToFile.Interfaces
{
    public interface IStepsAdapter<TIn, TOut>
    {
        TOut Execute(TIn model);
    }
}
