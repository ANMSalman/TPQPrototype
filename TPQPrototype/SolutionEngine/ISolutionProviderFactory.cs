using TPQPrototype.Shared.Enums;
using TPQPrototype.SolutionEngine.Solutions;

namespace TPQPrototype.SolutionEngine
{
    public interface ISolutionProviderFactory : IFactory
    {
        ISolution GetSolution(OperatorType operatorType, ContentType contentType, Problem problem);
    }
}
