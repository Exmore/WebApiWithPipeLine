using PipeLine.AddInfoToFile.Interfaces;
using PipeLine.AddInfoToFile.Models;

namespace PipeLine.AddInfoToFile.Adapters
{
    public class StartInfoToSeparateWordsAdapter : IStepsAdapter<AddInfoToFileInModel, SeparateWordsInModel>
    {
        public SeparateWordsInModel Execute(AddInfoToFileInModel inModel)
        {
            return new SeparateWordsInModel
            {
                SenderName = inModel.SenderName,
                InputString = inModel.InputString
            };
        }
    }
}
