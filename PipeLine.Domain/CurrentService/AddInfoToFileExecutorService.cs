using PipeLine.Domain.Builder;
using PipeLine.Domain.Models.AddInfoToFile;
using PipeLine.Domain.PipeLine;
using PipeLine.Models.AddInfoToFileModels;

namespace PipeLine.Domain
{
    public static class AddInfoToFileExecutorService
    {
        private static readonly TPLPipelineWithAwaitAttempt<AddInfoToFileInModel, ThirdStepResult> _pipeline;
        
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
