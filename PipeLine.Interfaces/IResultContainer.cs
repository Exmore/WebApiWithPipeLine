using System;
using System.Collections.Generic;

namespace PipeLine.Interfaces
{
    public interface IResultContainer<T>
    {
        T Value { get; }
        bool HasErrors { get; }
        bool NoErrors { get; }
        IList<ApplicationException> Errors { get; }
        void AddErrors(IEnumerable<ApplicationException> errors);
        void AddError(ApplicationException e);
    }
}
