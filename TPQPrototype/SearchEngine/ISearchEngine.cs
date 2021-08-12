using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;

namespace TPQPrototype.SearchEngine
{
    public interface ISearchEngine : IEngine
    {
        Task<List<SearchResponseModel>> Search(SearchRequestModel request);
    }
}
