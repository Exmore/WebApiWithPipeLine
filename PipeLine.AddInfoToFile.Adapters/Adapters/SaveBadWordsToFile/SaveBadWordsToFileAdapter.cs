using PipeLine.AddInfoToFile.Interfaces;
using PipeLine.AddInfoToFile.Models;

namespace PipeLine.AddInfoToFile.Adapters
{
    public class SaveBadWordsToFileAdapter : IStepsAdapter<SeparateWordsResult, SaveWordsToFileInModel>
    {
        public SaveWordsToFileInModel Execute(SeparateWordsResult inResult)
        {
            var res = inResult.Value;

            return new SaveWordsToFileInModel
            {
                SenderName = res.SenderName,
                WordsToSave = res.BadWords               
            };
        }
    }
}
