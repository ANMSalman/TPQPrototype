using System.Collections.Generic;
using TPQPrototype.Enums;
using TPQPrototype.SearchEngine.Engines.Visa.ContentSource;

namespace TPQPrototype.SearchEngine.Engines.Visa
{
    public interface IVisaContentSourceSearchEngineFactory
    {
        List<IVisaContentSourceSearchEngine> GetEngines(List<ContentType> contentTypes);
    }
}
