using PipeLine.Domain.Abstract;
using PipeLine.Domain.Models.AddInfoToFile;

namespace PipeLine.Domain.Adapters.AddInfoToFile
{
    public class FirstStepAdapter : IStepsAdapter<FirstStepResult, SecondStepInModel>
    {
        public SecondStepInModel Execute(FirstStepResult firstStepOutModel)
        {
            return new SecondStepInModel
            {
                SomeString = firstStepOutModel.Value.SomeString,
                DelayTime = firstStepOutModel.Value.DelayTime
            };
        }
    }
}
