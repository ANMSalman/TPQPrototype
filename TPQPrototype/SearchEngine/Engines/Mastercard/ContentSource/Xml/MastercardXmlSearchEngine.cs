using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;
using TPQPrototype.Shared.Serializers.Mastercard;

namespace TPQPrototype.SearchEngine.Engines.Mastercard.ContentSource.Xml
{
    public class MastercardXmlSearchEngine : IMastercardContentSourceSearchEngine
    {
        private readonly IMastercardXmlContentSerializer _serializer;

        public MastercardXmlSearchEngine(IMastercardXmlContentSerializer serializer)
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
