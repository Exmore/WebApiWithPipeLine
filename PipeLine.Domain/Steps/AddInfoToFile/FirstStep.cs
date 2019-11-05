using PipeLine.Domain.Abstract;
using PipeLine.Domain.Models.AddInfoToFile;
using PipeLine.Models.AddInfoToFileModels;
using System;
using System.IO;
using System.Threading;

namespace PipeLine.Domain.Steps.AddInfoToFile
{
    public class FirstStep : IStep<AddInfoToFileInModel, FirstStepResult>
    {
        private readonly string _filePath;

        public FirstStep(string filePath)
        {
            _filePath = filePath;
        }

        public FirstStepResult Execute(AddInfoToFileInModel firstStepInModel)
        {
            //Main Action            
            File.AppendAllText(_filePath, $"First Step Start of the {firstStepInModel} at {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")}\n");
            Thread.Sleep(firstStepInModel.DelayTime * 1000);
            File.AppendAllText(_filePath, $"First Step of the {firstStepInModel} has been done at {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")}\n");

            return new FirstStepResult(new FirstStepOutModel
            {
                SomeString = firstStepInModel.SomeString,
                DelayTime = firstStepInModel.DelayTime
            });
        }
    }
}
