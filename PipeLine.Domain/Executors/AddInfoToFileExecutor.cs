using PipeLine.AddInfoToFile.Interfaces;
using PipeLine.AddInfoToFile.Models;
using PipeLine.Interfaces;

namespace PipeLine.Domain.Executors
{
    public class AddInfoToFileExecutor : IAddInfoToFileExecutor<AddInfoToFileInModel>
    {
        private readonly IPipeLine<AddInfoToFileInModel, AddInfoToFileResult> _pipeline;

        public AddInfoToFileExecutor(IAddInfoToFileBuilder<AddInfoToFileInModel, AddInfoToFileResult> builder)
        {
            _pipeline = builder.Build();
        }

        public void Execute(AddInfoToFileInModel inModel)
        {
            _pipeline.Execute(inModel);
        }
    }
}
