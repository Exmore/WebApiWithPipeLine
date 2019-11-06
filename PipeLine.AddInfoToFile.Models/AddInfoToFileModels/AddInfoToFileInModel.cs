namespace PipeLine.AddInfoToFile.Models
{
    public class AddInfoToFileInModel
    {
        public string InputString { get; set; }
        public string SenderName { get; set; }

        public override string ToString()
        {
            return $"{InputString} + {SenderName}";
        }
    }
}
