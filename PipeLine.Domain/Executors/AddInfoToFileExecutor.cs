using PipeLine.Domain.Models.AddInfoToFile;
using PipeLine.Domain.PipeLine;
using PipeLine.Interfaces;
using System.Threading.Tasks;
using System;
using PipeLine.Domain.Builder;
using PipeLine.Models.AddInfoToFileModels;

namespace PipeLine.Domain.Executors
{
    public class AddInfoToFileExecutor : IStepsExecutor<AddInfoToFileInModel>
    {
        private readonly TPLPipelineWithAwaitAttempt<AddInfoToFileInModel, ThirdStepResult> _pipeline;

        public AddInfoToFileExecutor()
        {
            var stepsBuilder = new AddInfoToFileBuilder();
            _pipeline = stepsBuilder.Build();
        }

        public async void Execute(AddInfoToFileInModel inModel)
        {
            var task = new Task(() =>
            {
                try
                {
                    _pipeline.Execute(inModel);
                }
                catch (Exception e)
                {
                }
            });

            task.Start();

            await task;
        }
    }
}
