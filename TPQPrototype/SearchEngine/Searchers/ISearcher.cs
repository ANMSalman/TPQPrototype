using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;

namespace TPQPrototype.SearchEngine.Searchers
{
    public interface ISearcher
    {
        public (OperatorType, ContentType) SearcherFor { get; }
        Task<List<SearchResponseModel>> Search(SearchParameters parameters);
    }
}
