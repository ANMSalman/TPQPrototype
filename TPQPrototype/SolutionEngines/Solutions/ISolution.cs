using System.Threading.Tasks;
using TPQPrototype.Entities;
using TPQPrototype.Shared.Enums;

namespace TPQPrototype.SolutionEngines.Solutions
{
    public interface ISolution
    {
        public (OperatorType, ContentType, Problem) SolutionFor { get; }
        Task Solve(ProcessingQueue record, string solution);
    }
}
