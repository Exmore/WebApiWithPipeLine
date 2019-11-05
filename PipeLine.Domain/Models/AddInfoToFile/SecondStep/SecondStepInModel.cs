namespace PipeLine.Domain.Models.AddInfoToFile
{
    public class SecondStepInModel
    {
        public string SomeString { get; set; }
        public int DelayTime { get; set; }

        public override string ToString()
        {
            return $"{SomeString} + {DelayTime}";
        }
    }
}
