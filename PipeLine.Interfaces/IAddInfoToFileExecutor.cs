namespace PipeLine.Interfaces
{
    public interface IAddInfoToFileExecutor<TIn>
    {
        void Execute(TIn inModel);
    }
}
