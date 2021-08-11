using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;

namespace TPQPrototype.SearchEngine.Engines.Visa
{
    public class VisaSearchEngine : IOperatorSearchEngine
    {
        public OperatorType OperatorType => OperatorType.Mastercard;


        private readonly IVisaContentSourceSearchEngineFactory _contentSearchEngineFactory;

        public VisaSearchEngine(IVisaContentSourceSearchEngineFactory contentSearchEngineFactory)
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
