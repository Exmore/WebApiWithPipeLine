using PipeLine.Domain.Abstract;
using PipeLine.Domain.Models.AddInfoToFile;

namespace PipeLine.Domain.Adapters.AddInfoToFile
{
    public class SecondStepAdapter : IStepsAdapter<SecondStepResult, ThirdStepInModel>
    {
        public ThirdStepInModel Execute(SecondStepResult model)
        {
            return new ThirdStepInModel
            {
                SomeString = model.Value.SomeString,
                DelayTime = model.Value.DelayTime
            };
        }
    }
}