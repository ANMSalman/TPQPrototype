using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;
using TPQPrototype.Shared.Serializers.Mastercard;

namespace TPQPrototype.SearchEngine.Searchers.Mastercard
{
    public class MastercardBatchSearcher : ISearcher
    {
        private readonly IMastercardBatchContentSerializer _serializer;

        public MastercardBatchSearcher(IMastercardBatchContentSerializer serializer)
        {
            _serializer = serializer;
        }
        public (OperatorType, ContentType) SearcherFor => (OperatorType.Mastercard, ContentType.Batch);
        public async Task<List<SearchResponseModel>> Search(SearchParameters parameters)
        {
            var list = new List<SearchResponseModel>();
            // run your query here

            var content = await _serializer.Deserialize("");

            // perform your filtering
            list.Add(new SearchResponseModel()
            {
                Id = Guid.NewGuid(),
                OperatorType = OperatorType.Mastercard,
                ContentType = ContentType.Batch,
                Content = ""
            });

            //Fake IO simulation
            await Task.Delay(2000);

            return list;
        }
    }
}
