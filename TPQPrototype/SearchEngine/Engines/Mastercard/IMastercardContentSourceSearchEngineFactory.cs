using System.Collections.Generic;
using TPQPrototype.Enums;
using TPQPrototype.SearchEngine.Engines.Mastercard.ContentSource;

namespace TPQPrototype.SearchEngine.Engines.Mastercard
{
    public interface IMastercardContentSourceSearchEngineFactory : IFactory
    {
        List<IMastercardContentSourceSearchEngine> GetEngines(List<ContentType> contentTypes);
    }
}
