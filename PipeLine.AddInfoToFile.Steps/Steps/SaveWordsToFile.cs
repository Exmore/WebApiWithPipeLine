using Microsoft.Extensions.Options;
using PipeLine.AddInfoToFile.Interfaces;
using PipeLine.AddInfoToFile.Models;
using PipeLine.AddInfoToFile.Steps.Options;
using System;
using System.IO;
using System.Threading;

namespace PipeLine.AddInfoToFile.Steps
{
    public class SaveWordsToFile : IStep<SaveWordsToFileInModel, SaveWordsToFileResult>
    {
        private readonly SaveWordsToFileOptions _options;

        public SaveWordsToFile(IOptions<SaveWordsToFileOptions> options)
        {
            _options = options.Value;
        }
        
        public SaveWordsToFileResult Execute(SaveWordsToFileInModel inModel)
        {
            Thread.Sleep(_options.DelayTime * 1000);

            File.AppendAllText(_options.FilePath, GetMessageToSave(inModel));

            return new SaveWordsToFileResult(new SaveWordsToFileOutModel
            {
                SavingResult = $"Информация от {inModel.WordsToSave}. Успешно сохранена."
            });
        }

        private string GetMessageToSave(SaveWordsToFileInModel inModel)
        {
            return
                $"Сообщение от {inModel.SenderName}. Сохранено в {DateTime.Now}\n" +
                $"Список слов:\n" +
                $"{string.Join("\n", inModel.WordsToSave)}" +
                $"\n";
        }
    }
}
