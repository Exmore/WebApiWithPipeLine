namespace PipeLine.Models.AddInfoToFileModels
{
    public class AddInfoToFileOutModel 
    {
        public string SomeString { get; set; }
        public int DelayTime { get; set; }

        public override string ToString()
        {
            return $"{SomeString} + {DelayTime}";
        }
    }
}
