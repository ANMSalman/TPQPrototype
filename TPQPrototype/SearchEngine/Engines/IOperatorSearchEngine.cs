using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;

namespace TPQPrototype.SearchEngine.Engines
{
    public interface IOperatorSearchEngine : IEngine
    {
        OperatorType OperatorType { get; }
        Task<List<SearchResponseModel>> Search(OperatorSearchParameters parameters);
    }
}
