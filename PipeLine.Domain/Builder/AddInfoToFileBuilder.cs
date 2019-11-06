using Microsoft.Extensions.Options;
using PipeLine.Domain.Abstract;
using PipeLine.Domain.Adapters.AddInfoToFile;
using PipeLine.Domain.Models.AddInfoToFile;
using PipeLine.Domain.Options;
using PipeLine.Domain.Steps.AddInfoToFile;
using PipeLine.Interfaces;
using PipeLine.Models.AddInfoToFileModels;

namespace PipeLine.Domain.Builder
{
    public class AddInfoToFileBuilder: IAddInfoToFileBuilder
    {
        private readonly AddInfoToFileOptions _options;

        //TODO mb need to fix
        private readonly IPipeLine<AddInfoToFileInModel, AddInfoToFileResult> _pipeLine;

        public AddInfoToFileBuilder(
            IOptions<AddInfoToFileOptions> options, 
            IPipeLine<AddInfoToFileInModel, AddInfoToFileResult> pipeLine)
        {
            _options = options.Value;
            _pipeLine = pipeLine;
        }

        //TODO вынести в DI
        public IPipeLine<AddInfoToFileInModel, AddInfoToFileResult> Build()
        {
            var firstStep = new FirstStep(_options);
            var adapter = new FirstStepAdapter();
            var secondStep = new SecondStep(_options);
            var adapter2 = new SecondStepAdapter();
            var thirdStep = new ThirdStep(_options);

            _pipeLine
            .AddStep<AddInfoToFileInModel, FirstStepResult>(model => firstStep.Execute(model))
            .AddStep<FirstStepResult, SecondStepInModel>(model => adapter.Execute(model))
            .AddStep<SecondStepInModel, SecondStepResult>(model => secondStep.Execute(model))
            .AddStep<SecondStepResult, ThirdStepInModel>(model => adapter2.Execute(model))
            .AddStep<ThirdStepInModel, AddInfoToFileResult>(model => thirdStep.Execute(model))
            .CreatePipeline();

            return _pipeLine;
        }
    }
}
