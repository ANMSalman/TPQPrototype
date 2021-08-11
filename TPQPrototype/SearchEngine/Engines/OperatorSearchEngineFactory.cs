﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TPQPrototype.Enums;

namespace TPQPrototype.SearchEngine.Engines
{
    public class OperatorSearchEngineFactory : IOperatorSearchEngineFactory
    {
        private readonly IReadOnlyDictionary<OperatorType, IOperatorSearchEngine> _searchEngines;

        public OperatorSearchEngineFactory()
        {
            var searchEngineType = typeof(IOperatorSearchEngine);

            _searchEngines = searchEngineType.Assembly.GetExportedTypes()
                .Where(x => searchEngineType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IOperatorSearchEngine>()
                .ToImmutableDictionary(x => x.OperatorType, x => x);
        }

        public List<IOperatorSearchEngine> GetEngines(List<OperatorType> operators)
        {
            return _searchEngines.Where(se => operators.Contains(se.Key))
                .Select(x => x.Value).ToList();
        }
    }
}