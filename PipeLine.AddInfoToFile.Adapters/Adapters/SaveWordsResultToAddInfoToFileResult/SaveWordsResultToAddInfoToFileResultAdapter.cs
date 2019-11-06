using PipeLine.AddInfoToFile.Interfaces;
using PipeLine.AddInfoToFile.Models;

namespace PipeLine.AddInfoToFile.Adapters
{
    public class SaveWordsResultToAddInfoToFileResultAdapter : IStepsAdapter<SaveWordsToFileResult, AddInfoToFileResult>
    {
        public AddInfoToFileResult Execute(SaveWordsToFileResult inResult)
        {            
            var res = inResult.Value;

            return new AddInfoToFileResult(
                new AddInfoToFileOutModel
                {
                    ResultString = res.SavingResult
                });
        }
    }
}
