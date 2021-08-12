using System.Threading.Tasks;
using TPQPrototype.Shared.Request;

namespace TPQPrototype.SolutionEngine
{
    public interface ISolutionEngine
    {
        Task Solve(SolutionRequestModel request);
    }
}
