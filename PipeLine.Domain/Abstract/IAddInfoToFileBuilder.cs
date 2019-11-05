using PipeLine.Domain.Models.AddInfoToFile;
using PipeLine.Interfaces;
using PipeLine.Models.AddInfoToFileModels;

namespace PipeLine.Domain.Abstract
{
    public interface IAddInfoToFileBuilder
    {
        IPipeLine<AddInfoToFileInModel, ThirdStepResult> Build();
    }
}
