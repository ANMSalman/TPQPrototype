using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TPQPrototype.Enums;
using TPQPrototype.SearchEngine.Engines.Mastercard.ContentSource;

namespace TPQPrototype.SearchEngine.Engines.Mastercard
{
    public class MastercardContentSourceSearchEngineFactory : IMastercardContentSourceSearchEngineFactory
    {
        private readonly IReadOnlyDictionary<ContentType, IMastercardContentSourceSearchEngine> _searchEngines;

        public MastercardContentSourceSearchEngineFactory(IServiceProvider serviceProvider)
        {
            //var searchEngineType = typeof(IMastercardContentSourceSearchEngine);

            //_searchEngines = searchEngineType.Assembly.GetExportedTypes()
            //    .Where(x => searchEngineType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            //    .Select(Activator.CreateInstance)
            //    .Cast<IMastercardContentSourceSearchEngine>()
            //    .ToImmutableDictionary(x => x.ContentType, x => x);

            _searchEngines = serviceProvider.GetServices<IMastercardContentSourceSearchEngine>()
                .ToImmutableDictionary(x => x.ContentType, x => x);
        }

        public List<IMastercardContentSourceSearchEngine> GetEngines(List<ContentType> contentTypes)
        {
            return _searchEngines.Where(se => contentTypes.Contains(se.Key))
                .Select(x => x.Value).ToList();
        }
    }
}
