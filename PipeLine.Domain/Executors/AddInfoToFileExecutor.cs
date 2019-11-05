using PipeLine.Interfaces;
using PipeLine.Models.AddInfoToFileModels;
using PipeLine.Domain.Abstract;

namespace PipeLine.Domain.Executors
{
    public class AddInfoToFileExecutor : IAddInfoToFileExecutor<AddInfoToFileInModel>
    {

        private readonly IAddInfoToFileBuilder _builder;
        public AddInfoToFileExecutor(IAddInfoToFileBuilder builder)
        {
            _builder = builder;
        }


        public void Execute(AddInfoToFileInModel inModel)
        {
            AddInfoToFileExecutorService.Execute(_builder, inModel);
        }
    }    
}
