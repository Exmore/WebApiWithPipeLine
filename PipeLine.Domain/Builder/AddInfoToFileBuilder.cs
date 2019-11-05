using Microsoft.Extensions.Options;
using PipeLine.Domain.Abstract;
using PipeLine.Domain.Adapters.AddInfoToFile;
using PipeLine.Domain.Models.AddInfoToFile;
using PipeLine.Domain.Options;
using PipeLine.Domain.Steps.AddInfoToFile;
using PipeLine.Interfaces;
using PipeLine.Models.AddInfoToFileModels;
using PipeLine.StandardPipeLine;

namespace PipeLine.Domain.Builder
{
    public class AddInfoToFileBuilder: IAddInfoToFileBuilder
    {
        private readonly AddInfoToFileOptions _options;
        public AddInfoToFileBuilder(IOptions<AddInfoToFileOptions> options)
        {
            _options = options.Value;
        }

        //TODO вынести в DI
        public IPipeLine<AddInfoToFileInModel, ThirdStepResult> Build()
        {
            var firstStep = new FirstStep(_options);
            var adapter = new FirstStepAdapter();
            var secondStep = new SecondStep(_options);
            var adapter2 = new SecondStepAdapter();
            var thirdStep = new ThirdStep(_options);

            var pipeline = new StandardPipeLine<AddInfoToFileInModel, ThirdStepResult>()
                    .AddStep<AddInfoToFileInModel, FirstStepResult>(model => firstStep.Execute(model))
                    .AddStep<FirstStepResult, SecondStepInModel>(model => adapter.Execute(model))
                    .AddStep<SecondStepInModel, SecondStepResult>(model => secondStep.Execute(model))
                    .AddStep<SecondStepResult, ThirdStepInModel>(model => adapter2.Execute(model))
                    .AddStep<ThirdStepInModel, ThirdStepResult>(model => thirdStep.Execute(model))
                    .CreatePipeline();

            return pipeline;
        }
    }
}
