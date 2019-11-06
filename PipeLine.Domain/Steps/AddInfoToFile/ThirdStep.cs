using Microsoft.Extensions.Options;
using PipeLine.Domain.Abstract;
using PipeLine.Domain.Models.AddInfoToFile;
using PipeLine.Domain.Options;
using PipeLine.Models.AddInfoToFileModels;
using System;
using System.IO;
using System.Threading;

namespace PipeLine.Domain.Steps.AddInfoToFile
{
    public class ThirdStep : IStep<ThirdStepInModel, AddInfoToFileResult>
    {
        private readonly AddInfoToFileOptions _options;
        
        public ThirdStep(AddInfoToFileOptions options)
        {
            _options = options;
        }

        public AddInfoToFileResult Execute(ThirdStepInModel thirdStepInModel)
        {
            //Main Action
            File.AppendAllText(_options.FilePath, $"Third Step Start of the {thirdStepInModel} at {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")}\n");
            Thread.Sleep(thirdStepInModel.DelayTime * 1000);
            File.AppendAllText(_options.FilePath, $"Third Step of the {thirdStepInModel} has been done at {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")}\n");

            return new AddInfoToFileResult(new AddInfoToFileOutModel
            {
                SomeString = thirdStepInModel.SomeString,
                DelayTime = thirdStepInModel.DelayTime
            });
        }
    }
}
