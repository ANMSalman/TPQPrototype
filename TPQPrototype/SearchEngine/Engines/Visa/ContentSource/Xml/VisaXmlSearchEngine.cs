using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;
using TPQPrototype.Shared.Serializers.Visa;

namespace TPQPrototype.SearchEngine.Engines.Visa.ContentSource.Xml
{
    public class VisaXmlSearchEngine : IVisaContentSourceSearchEngine
    {
        private readonly IVisaXmlContentSerializer _serializer;

        public VisaXmlSearchEngine(IVisaXmlContentSerializer serializer)
        {
            _serializer = serializer;
        }

        public ContentType ContentType => ContentType.Xml;
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
