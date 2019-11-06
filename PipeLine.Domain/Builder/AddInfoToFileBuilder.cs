using PipeLine.AddInfoToFile.Adapters;
using PipeLine.AddInfoToFile.Interfaces;
using PipeLine.AddInfoToFile.Models;
using PipeLine.Interfaces;

namespace PipeLine.Domain.Builder
{
    /// <summary>
    /// Добавляет информацию в файл. Состоит из 2 шагов и 2 адаптеров.
    /// </summary>
    public class AddInfoToFileBuilder: IAddInfoToFileBuilder<AddInfoToFileInModel, AddInfoToFileResult>
    {
        private readonly IPipeLine<AddInfoToFileInModel, AddInfoToFileResult> _pipeLine;

        private readonly IStepsAdapter<AddInfoToFileInModel, SeparateWordsInModel> _firstStepAdapter;
        private readonly IStep<SeparateWordsInModel, SeparateWordsResult> _separateWords;
        private readonly IStepsAdapter<SeparateWordsResult, SaveWordsToFileInModel> _removeBadWordsToSaveWordsToFileAdapter;
        private readonly IStep<SaveWordsToFileInModel, SaveWordsToFileResult> _saveWordsToFile;

        public AddInfoToFileBuilder(
            IPipeLine<AddInfoToFileInModel, AddInfoToFileResult> pipeLine,
            IStepsAdapter<AddInfoToFileInModel, SeparateWordsInModel> firstStepAdapter,
            IStep<SeparateWordsInModel, SeparateWordsResult> separateWords,
            IStepsAdapter<SeparateWordsResult, SaveWordsToFileInModel> removeBadWordsToSaveWordsToFileAdapter,
            IStep<SaveWordsToFileInModel, SaveWordsToFileResult> saveWordsToFile)
        {
            _pipeLine = pipeLine;
            _firstStepAdapter = firstStepAdapter;
            _separateWords = separateWords;
            _removeBadWordsToSaveWordsToFileAdapter = removeBadWordsToSaveWordsToFileAdapter;
            _saveWordsToFile = saveWordsToFile;
        }

        public IPipeLine<AddInfoToFileInModel, AddInfoToFileResult> Build()
        {                        
            var saveWordsResultToAddInfoToFileResultAdapter = new SaveWordsResultToAddInfoToFileResultAdapter();

            _pipeLine
                .AddStep<AddInfoToFileInModel, SeparateWordsInModel>(model => _firstStepAdapter.Execute(model))
                .AddStep<SeparateWordsInModel, SeparateWordsResult>(model=> _separateWords.Execute(model))
                .AddStep<SeparateWordsResult, SaveWordsToFileInModel>(model=> _removeBadWordsToSaveWordsToFileAdapter.Execute(model))
                .AddStep<SaveWordsToFileInModel, SaveWordsToFileResult>(model=> _saveWordsToFile.Execute(model))
                .AddStep<SaveWordsToFileResult, AddInfoToFileResult>(model=>saveWordsResultToAddInfoToFileResultAdapter.Execute(model))                
                .CreatePipeline();

            return _pipeLine;
        }
    }
}
