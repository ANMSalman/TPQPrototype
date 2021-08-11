﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TPQPrototype.Enums;
using TPQPrototype.SearchEngine.Engines.Visa.ContentSource;

namespace TPQPrototype.SearchEngine.Engines.Visa
{
    public class VisaContentSourceSearchEngineFactory : IVisaContentSourceSearchEngineFactory
    {
        private readonly IReadOnlyDictionary<ContentType, IVisaContentSourceSearchEngine> _searchEngines;

        public VisaContentSourceSearchEngineFactory()
        {
            var searchEngineType = typeof(IVisaContentSourceSearchEngine);

            _searchEngines = searchEngineType.Assembly.GetExportedTypes()
                .Where(x => searchEngineType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IVisaContentSourceSearchEngine>()
                .ToImmutableDictionary(x => x.ContentType, x => x);
        }

        public List<IVisaContentSourceSearchEngine> GetEngines(List<ContentType> contentTypes)
        {
            return _searchEngines.Where(se => contentTypes.Contains(se.Key))
                .Select(x => x.Value).ToList();
        }
    }
}