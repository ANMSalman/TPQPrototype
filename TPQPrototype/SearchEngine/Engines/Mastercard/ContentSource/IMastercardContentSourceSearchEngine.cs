using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;

namespace TPQPrototype.SearchEngine.Engines.Mastercard.ContentSource
{
    public interface IMastercardContentSourceSearchEngine : IEngine
    {
        public ContentType ContentType { get; }
        Task<List<SearchResponseModel>> Search(ContentSearchParameters parameters);
    }
}
