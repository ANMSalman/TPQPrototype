using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;

namespace TPQPrototype.SearchEngine.Engines.Visa
{
    public class VisaSearchEngine : IOperatorSearchEngine
    {
        public OperatorType OperatorType => OperatorType.Visa;


        private readonly IVisaContentSourceSearchEngineFactory _contentSearchEngineFactory;

        public VisaSearchEngine(IVisaContentSourceSearchEngineFactory contentSearchEngineFactory)
        {
            _contentSearchEngineFactory = contentSearchEngineFactory;
        }

        public async Task<List<SearchResponseModel>> Search(OperatorSearchParameters parameters)
        {
            var response = new List<SearchResponseModel>();

            var engines = _contentSearchEngineFactory.GetEngines(parameters.ContentTypes);

            var tasks = engines.Select(x => x.Search(parameters.ContentSearchParameters)).ToList();

            await Task.WhenAll(tasks);

            response.AddRange(tasks.SelectMany(x => x.Result));

            return response;
        }
    }
}
