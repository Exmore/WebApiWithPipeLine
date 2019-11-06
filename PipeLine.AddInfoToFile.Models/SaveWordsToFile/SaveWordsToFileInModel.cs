using System.Collections.Generic;

namespace PipeLine.AddInfoToFile.Models
{
    public class SaveWordsToFileInModel
    {
        public string SenderName { get; set; }
        public List<string> WordsToSave { get; set; }

        public override string ToString()
        {
            return $"{string.Join(" ", WordsToSave)}";
        }
    }
}
