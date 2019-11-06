using System.Collections.Generic;

namespace PipeLine.AddInfoToFile.Steps.Options
{
    public class SeparateWordsOptions
    {
        public int DelayTime { get; set; }

        public List<string> BadWords { get; set; }
    }
}
