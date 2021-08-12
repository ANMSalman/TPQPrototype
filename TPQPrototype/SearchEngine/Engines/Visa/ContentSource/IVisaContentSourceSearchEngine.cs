using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;

namespace TPQPrototype.SearchEngine.Engines.Visa.ContentSource
{
    public interface IVisaContentSourceSearchEngine : IEngine
    {
        public ContentType ContentType { get; }
        Task<List<SearchResponseModel>> Search(ContentSearchParameters parameters);
    }
}
