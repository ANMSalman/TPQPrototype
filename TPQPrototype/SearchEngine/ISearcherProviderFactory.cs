using TPQPrototype.SearchEngine.Searchers;
using TPQPrototype.Shared.Enums;

namespace TPQPrototype.SearchEngine
{
    public interface ISearcherProviderFactory : IFactory
    {
        ISearcher GetSearcher(OperatorType operatorType, ContentType contentType);
    }
}
