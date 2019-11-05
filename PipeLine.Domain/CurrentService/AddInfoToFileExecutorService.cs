using PipeLine.Domain.Abstract;
using PipeLine.Domain.Builder;
using PipeLine.Domain.Models.AddInfoToFile;
using PipeLine.Interfaces;
using PipeLine.Models.AddInfoToFileModels;

namespace PipeLine.Domain
{
    public static class AddInfoToFileExecutorService
    {
        private static IPipeLine<AddInfoToFileInModel, ThirdStepResult> _pipeline;       

        public static void Execute(IAddInfoToFileBuilder builder, AddInfoToFileInModel inModel)
        {
            if (_pipeline == null)
                _pipeline = builder.Build();

            _pipeline.Execute(inModel);
        }
    }
}
