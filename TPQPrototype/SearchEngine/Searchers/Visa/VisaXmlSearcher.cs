using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Response;
using TPQPrototype.Shared.Serializers.Visa;

namespace TPQPrototype.SearchEngine.Searchers.Visa
{
    public class VisaXmlSearcher : ISearcher
    {
        private readonly IVisaXmlContentSerializer _serializer;

        public VisaXmlSearcher(IVisaXmlContentSerializer serializer)
        {
            _serializer = serializer;
        }

        public (OperatorType, ContentType) SearcherFor => (OperatorType.Visa, ContentType.Xml);
        public async Task<List<SearchResponseModel>> Search(SearchParameters parameters)
        {
            var list = new List<SearchResponseModel>();
            // run your query here

            var content = await _serializer.Deserialize("");

            // perform your filtering
            list.Add(new SearchResponseModel()
            {
                Id = Guid.NewGuid(),
                OperatorType = OperatorType.Visa,
                ContentType = ContentType.Xml,
                Content = ""
            });

            //Fake IO simulation
            await Task.Delay(2000);

            return list;
        }
    }
}
