using System.Threading.Tasks;

namespace PipeLine.Domain.PipeLine
{
    public class TC<TInput, TOutput>
    {
        public TC(TInput input, TaskCompletionSource<TOutput> tcs)
        {
            Input = input;
            TaskCompletionSource = tcs;
        }
        public TInput Input { get; set; }
        public TaskCompletionSource<TOutput> TaskCompletionSource { get; set; }
    }
}
