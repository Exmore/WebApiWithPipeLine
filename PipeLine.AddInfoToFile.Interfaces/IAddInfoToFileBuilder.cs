using PipeLine.Interfaces;

namespace PipeLine.AddInfoToFile.Interfaces
{
    public interface IAddInfoToFileBuilder<TIn,TOut>
    {
        IPipeLine<TIn, TOut> Build();
    }
    asds
}
