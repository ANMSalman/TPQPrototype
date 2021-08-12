using System.Collections.Generic;
using TPQPrototype.Shared.Enums;

namespace TPQPrototype.SearchEngine.Engines
{
    public interface IOperatorSearchEngineFactory : IFactory
    {
        List<IOperatorSearchEngine> GetEngines(List<OperatorType> operators);
    }
}
