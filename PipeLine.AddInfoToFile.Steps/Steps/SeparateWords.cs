using Microsoft.Extensions.Options;
using PipeLine.AddInfoToFile.Interfaces;
using PipeLine.AddInfoToFile.Models;
using PipeLine.AddInfoToFile.Steps.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace PipeLine.AddInfoToFile.Steps
{
    public class SeparateWords : IStep<SeparateWordsInModel, SeparateWordsResult>
    {
        private readonly SeparateWordsOptions _options;

        public SeparateWords(IOptions<SeparateWordsOptions> options)
        {
            _options = options.Value;
        }

        public SeparateWordsResult Execute(SeparateWordsInModel inModel)
        {
            // Имитация долгой работы
            Thread.Sleep(_options.DelayTime * 1000);                            

            var parsedArray = SeparateString(inModel.InputString);
            var badWords = GetBadWords(parsedArray);
            var goodWords = GetGoodWords(parsedArray, badWords);

            return new SeparateWordsResult(new SeparateWordsOutModel
            {
                SenderName = inModel.SenderName,
                BadWords = badWords,
                GoodWords = goodWords
            });
        }

        private List<string> GetBadWords(IEnumerable<string> words)
        {
            var badWordsList = _options.BadWords;
            return badWordsList.Intersect(words).ToList();
        }

        private List<string> GetGoodWords(IEnumerable<string> words, IEnumerable<string> foundedBadWordsList)
        {            
            return words.Except(foundedBadWordsList).ToList();
        }

        
        private string[] SeparateString(string inputString)
        {
            return Regex.Matches(inputString, @""".*?""|[^\s]+").Cast<Match>().Select(m => m.Value).ToArray();
        }
    }
}
