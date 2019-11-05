using PipeLine.Interfaces;
using System;
using System.Collections.Generic;

namespace PipeLine.Domain.Models.AddInfoToFile
{
    public class ThirdStepResult : IResultContainer<ThirdStepOutModel>
    {
        private readonly List<ApplicationException> _appErrors;

        public ThirdStepResult(ThirdStepOutModel result)
        {
            _appErrors = new List<ApplicationException>();
            Value = result;
        }
        public ThirdStepOutModel Value { get; }

        public bool HasErrors => _appErrors.Count > 0;

        public bool NoErrors => _appErrors.Count == 0;

        public IList<ApplicationException> Errors => _appErrors;

        public void AddError(ApplicationException e)
        {
            _appErrors.Add(e);
        }

        public void AddErrors(IEnumerable<ApplicationException> errors)
        {
            foreach (var error in errors)
            {
                _appErrors.Add(error);
            }
        }
    }
}
