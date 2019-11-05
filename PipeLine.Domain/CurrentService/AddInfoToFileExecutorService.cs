using PipeLine.Domain.Builder;
using PipeLine.Domain.Models.AddInfoToFile;
using PipeLine.Interfaces;
using PipeLine.Models.AddInfoToFileModels;

namespace PipeLine.Domain
{
    public static class AddInfoToFileExecutorService
    {
        private static readonly IPipeLine<AddInfoToFileInModel, ThirdStepResult> _pipeline;
        
        static AddInfoToFileExecutorService()
        {
            //TODO переделать
            var builder = new AddInfoToFileBuilder();
            _pipeline = builder.Build();
        }

        public static void Execute(AddInfoToFileInModel inModel)
        {
            _pipeline.Execute(inModel);
        }
    }
}
