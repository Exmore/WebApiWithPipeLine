namespace PipeLine.Domain.Models.AddInfoToFile
{
    public class FirstStepOutModel
    {
        public string SomeString { get; set; }
        public int DelayTime { get; set; }

        public override string ToString()
        {
            return $"{SomeString} + {DelayTime}";
        }
    }
}
