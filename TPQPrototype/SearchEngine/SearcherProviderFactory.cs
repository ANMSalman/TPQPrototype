using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TPQPrototype.SearchEngine.Searchers;
using TPQPrototype.Shared.Enums;

namespace TPQPrototype.SearchEngine
{
    public class SearcherProviderFactory : ISearcherProviderFactory
    {
        private readonly IReadOnlyDictionary<(OperatorType, ContentType), ISearcher> _searchers;

        public SearcherProviderFactory(IServiceProvider serviceProvider)
        {
            _searchers = serviceProvider.GetServices<ISearcher>()
                .ToImmutableDictionary(x => x.SearcherFor, x => x);
        }
        public ISearcher GetSearcher(OperatorType operatorType, ContentType contentType)
        {
            return _searchers.FirstOrDefault(x =>
                x.Key.Item1 == operatorType && x.Key.Item2 == contentType).Value;
        }
    }
}
