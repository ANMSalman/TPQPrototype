using TPQPrototype.Shared.Enums;
using TPQPrototype.SolutionEngines.Solutions;

namespace TPQPrototype.SolutionEngines
{
    public interface ISolutionProviderFactory : IFactory
    {
        ISolution GetSolution(OperatorType operatorType, ContentType contentType, Problem problem);
    }
}
