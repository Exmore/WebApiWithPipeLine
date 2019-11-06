namespace PipeLine.AddInfoToFile.Models
{
    public class SaveWordsToFileOutModel
    {
        public string SavingResult { get; set; }

        public override string ToString()
        {
            return SavingResult;
        }
    }
}
