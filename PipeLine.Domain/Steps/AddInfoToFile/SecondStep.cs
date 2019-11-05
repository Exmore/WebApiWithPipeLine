using Microsoft.Extensions.Options;
using PipeLine.Domain.Abstract;
using PipeLine.Domain.Models.AddInfoToFile;
using PipeLine.Domain.Options;
using System;
using System.IO;
using System.Threading;

namespace PipeLine.Domain.Steps.AddInfoToFile
{
    public class SecondStep : IStep<SecondStepInModel, SecondStepResult>
    {
        private readonly AddInfoToFileOptions _options;

        public SecondStep(AddInfoToFileOptions options)
        {
            _options = options;
        }

        public SecondStepResult Execute(SecondStepInModel secondStepInModel)
        {
            //Main Action
            File.AppendAllText(_options.FilePath, $"Second Step Start of the {secondStepInModel} at {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")}\n");
            Thread.Sleep(secondStepInModel.DelayTime * 1000);
            File.AppendAllText(_options.FilePath, $"Second Step of the {secondStepInModel} has been done at {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")}\n");            

            return new SecondStepResult(new SecondStepOutModel
            {
                SomeString = secondStepInModel.SomeString,
                DelayTime = secondStepInModel.DelayTime
            });
        }
    }
}
