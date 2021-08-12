using System.Collections.Generic;
using TPQPrototype.SearchEngine.Engines.Mastercard.ContentSource;
using TPQPrototype.Shared.Enums;

namespace TPQPrototype.SearchEngine.Engines.Mastercard
{
    public interface IMastercardContentSourceSearchEngineFactory : IFactory
    {
        List<IMastercardContentSourceSearchEngine> GetEngines(List<ContentType> contentTypes);
    }
}
