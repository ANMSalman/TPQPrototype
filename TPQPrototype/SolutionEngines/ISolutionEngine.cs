using System.Threading.Tasks;
using TPQPrototype.Shared.Request;

namespace TPQPrototype.SolutionEngines
{
    public interface ISolutionEngine : IEngine
    {
        Task Solve(SolutionRequestModel request);
    }
}
