﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;

namespace TPQPrototype.SearchEngine.Aggregates
{
    public class AdminAggregator : ISearchEngine
    {
        private readonly ISearchEngine _searchEngine;

        public AdminAggregator(ISearchEngine searchEngine)
        {
            _searchEngine = searchEngine;
        }

        public async Task<List<SearchResponseModel>> Search(SearchRequestModel request)
        {
            var response = await _searchEngine.Search(request);

            // aggregate here

            return response;    //aggregated
        }
    }
}
