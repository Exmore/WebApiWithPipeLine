using System.Collections.Generic;

namespace PipeLine.AddInfoToFile.Models
{
    public class SeparateWordsOutModel
    {
        public string SenderName { get; set; }
        public List<string> GoodWords { get; set; }

        public List<string> BadWords { get; set; }
    }
}
