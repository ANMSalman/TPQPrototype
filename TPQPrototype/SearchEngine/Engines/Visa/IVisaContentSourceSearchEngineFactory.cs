using System.Collections.Generic;
using TPQPrototype.SearchEngine.Engines.Visa.ContentSource;
using TPQPrototype.Shared.Enums;

namespace TPQPrototype.SearchEngine.Engines.Visa
{
    public interface IVisaContentSourceSearchEngineFactory : IFactory
    {
        List<IVisaContentSourceSearchEngine> GetEngines(List<ContentType> contentTypes);
    }
}
