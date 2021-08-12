using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Shared.Enums;
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
            var list = new List<SearchResponseModel>();
            // run your query here

            var content = await _serializer.Deserialize("");

            // perform your filtering
            list.Add(new SearchResponseModel()
            {
                Id = Guid.NewGuid(),
                OperatorType = OperatorType.Mastercard,
                ContentType = ContentType,
                Content = ""
            });

            //Fake IO simulation
            await Task.Delay(2000);

            return list;
        }
    }
}
