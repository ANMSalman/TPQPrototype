using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;

namespace TPQPrototype.SearchEngine.Engines
{
    public class SearchEngine : ISearchEngine
    {
        private readonly IOperatorSearchEngineFactory _operatorSearchEngineFactory;

        public SearchEngine(IOperatorSearchEngineFactory operatorSearchEngineFactory)
        {
            this._operatorSearchEngineFactory = operatorSearchEngineFactory;
        }

        public async Task<List<SearchResponseModel>> Search(SearchRequestModel request)
        {
            var response = new List<SearchResponseModel>();

            var engines = _operatorSearchEngineFactory.GetEngines(request.Operators);

            foreach (var searchEngine in engines)
            {
                var result = await searchEngine.Search(request.OperatorSearchParameters);

                response.AddRange(result);
            }

            return response;
        }
    }
}
