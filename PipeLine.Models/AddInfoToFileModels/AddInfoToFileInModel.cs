namespace PipeLine.Models.AddInfoToFileModels
{
    public class AddInfoToFileInModel
    {
        public string SomeString { get; set; }
        public int DelayTime { get; set; }

        public override string ToString()
        {
            return $"{SomeString} + {DelayTime}";
        }
    }
}
