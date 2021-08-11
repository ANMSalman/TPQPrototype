using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;
using TPQPrototype.Shared.Serializers.Mastercard;

namespace TPQPrototype.SearchEngine.Engines.Mastercard.ContentSource.Batch
{
    public class MastercardBatchSearchEngine : IMastercardContentSourceSearchEngine
    {
        private readonly IMastercardBatchContentSerializer _serializer;

        public MastercardBatchSearchEngine(IMastercardBatchContentSerializer serializer)
        {
            _serializer = serializer;
        }

        public ContentType ContentType => ContentType.Batch;
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
