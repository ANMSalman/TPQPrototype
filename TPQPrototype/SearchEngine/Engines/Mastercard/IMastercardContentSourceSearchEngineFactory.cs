using System.Collections.Generic;
using TPQPrototype.Enums;
using TPQPrototype.SearchEngine.Engines.Mastercard.ContentSource;

namespace TPQPrototype.SearchEngine.Engines.Mastercard
{
    public interface IMastercardContentSourceSearchEngineFactory
    {
        List<IMastercardContentSourceSearchEngine> GetEngines(List<ContentType> contentTypes);
    }
}
