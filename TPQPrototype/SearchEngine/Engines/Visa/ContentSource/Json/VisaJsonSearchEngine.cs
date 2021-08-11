using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;
using TPQPrototype.Shared.Serializers.Visa;

namespace TPQPrototype.SearchEngine.Engines.Visa.ContentSource.Json
{
    public class VisaJsonSearchEngine : IVisaContentSourceSearchEngine
    {
        private readonly IVisaJsonContentSerializer _serializer;

        public VisaJsonSearchEngine(IVisaJsonContentSerializer serializer)
        {
            _serializer = serializer;
        }

        public ContentType ContentType => ContentType.Json;
        public async Task<List<SearchResponseModel>> Search(ContentSearchParameters parameters)
        {
            // run your query here

            var content = _serializer.Deserialize("");

            // perform your filtering

            await Task.CompletedTask;

            return new List<SearchResponseModel>();
        }
    }
}
