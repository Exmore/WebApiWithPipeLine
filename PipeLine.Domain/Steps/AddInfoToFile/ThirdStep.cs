using PipeLine.Domain.Abstract;
using PipeLine.Domain.Models.AddInfoToFile;
using System;
using System.IO;
using System.Threading;

namespace PipeLine.Domain.Steps.AddInfoToFile
{
    public class ThirdStep : IStep<ThirdStepInModel, ThirdStepResult>
    {
        private readonly string _filePath;
        
        public ThirdStep(string filePath)
        {
            _filePath = filePath;
        }

        public ThirdStepResult Execute(ThirdStepInModel thirdStepInModel)
        {
            //Main Action
            File.AppendAllText(_filePath, $"Third Step Start of the {thirdStepInModel} at {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")}\n");
            Thread.Sleep(thirdStepInModel.DelayTime * 1000);
            File.AppendAllText(_filePath, $"Third Step of the {thirdStepInModel} has been done at {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")}\n");

            return new ThirdStepResult(new ThirdStepOutModel
            {
                SomeString = thirdStepInModel.SomeString,
                DelayTime = thirdStepInModel.DelayTime
            });
        }
    }
}
