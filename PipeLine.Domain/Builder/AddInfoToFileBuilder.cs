﻿using PipeLine.Domain.Abstract;
using PipeLine.Domain.Adapters.AddInfoToFile;
using PipeLine.Domain.Models.AddInfoToFile;
using PipeLine.Domain.Steps.AddInfoToFile;
using PipeLine.Interfaces;
using PipeLine.Models.AddInfoToFileModels;
using PipeLine.StandardPipeLine;

namespace PipeLine.Domain.Builder
{
    public class AddInfoToFileBuilder: IAddInfoToFileBuilder
    {
        private readonly string _filePath;
        public AddInfoToFileBuilder()
        {
            _filePath = "Information.txt";
        }

        //TODO вынести в DI
        public IPipeLine<AddInfoToFileInModel, ThirdStepResult> Build()
        {
            var firstStep = new FirstStep(_filePath);
            var adapter = new FirstStepAdapter();
            var secondStep = new SecondStep(_filePath);
            var adapter2 = new SecondStepAdapter();
            var thirdStep = new ThirdStep(_filePath);

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
