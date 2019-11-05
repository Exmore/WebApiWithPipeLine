namespace PipeLine.Domain.Models.AddInfoToFile
{
    public class ThirdStepInModel
    {
        public string SomeString { get; set; }
        public int DelayTime { get; set; }

        public override string ToString()
        {
            return $"{SomeString} + {DelayTime}";
        }
    }
}
