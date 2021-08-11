using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;

namespace TPQPrototype.SearchEngine.Engines.Mastercard
{
    public class MastercardSearchEngine : IOperatorSearchEngine
    {
        public OperatorType OperatorType => OperatorType.Mastercard;


        private readonly IMastercardContentSourceSearchEngineFactory _contentSearchEngineFactory;

        public MastercardSearchEngine(IMastercardContentSourceSearchEngineFactory contentSearchEngineFactory)
        {
            _contentSearchEngineFactory = contentSearchEngineFactory;
        }

        public async Task<List<SearchResponseModel>> Search(OperatorSearchParameters parameters)
        {
            var response = new List<SearchResponseModel>();

            var engines = _contentSearchEngineFactory.GetEngines(parameters.ContentTypes);

            foreach (var searchEngine in engines)
            {
                var result = await searchEngine.Search(parameters.ContentSearchParameters);

                response.AddRange(result);
            }

            return response;
        }
    }
}
