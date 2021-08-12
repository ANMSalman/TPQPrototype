using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;

namespace TPQPrototype.SearchEngine
{
    public class SearchEngine : ISearchEngine
    {
        private readonly ISearcherProviderFactory _searcherProviderFactory;

        public SearchEngine(ISearcherProviderFactory searcherProviderFactory)
        {
            _searcherProviderFactory = searcherProviderFactory;
        }

        public async Task<List<SearchResponseModel>> Search(SearchRequestModel request)
        {
            var response = new List<SearchResponseModel>();

            var tasks = new List<Task<List<SearchResponseModel>>>();

            foreach (var requestOperator in request.Operators)
            {
                foreach (var requestContentType in request.ContentTypes)
                {
                    var searcher = _searcherProviderFactory.GetSearcher(requestOperator, requestContentType);

                    if (searcher is not null)
                    {
                        tasks.Add(searcher.Search(request.SearchParameters));
                    }
                }
            }

            await Task.WhenAll(tasks);

            response.AddRange(tasks.SelectMany(x => x.Result));

            return response;
        }
    }
}
