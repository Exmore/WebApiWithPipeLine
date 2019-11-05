namespace PipeLine.Interfaces
{
    public interface IStepsExecutor<TIn>
    {
        void Execute(TIn inModel);
    }
}
