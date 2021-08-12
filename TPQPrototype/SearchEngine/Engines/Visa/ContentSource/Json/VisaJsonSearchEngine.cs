using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Shared.Enums;
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
            var list = new List<SearchResponseModel>();
            // run your query here

            var content = await _serializer.Deserialize("");

            // perform your filtering
            list.Add(new SearchResponseModel()
            {
                Id = Guid.NewGuid(),
                OperatorType = OperatorType.Visa,
                ContentType = ContentType,
                Content = ""
            });

            //Fake IO simulation
            await Task.Delay(2000);

            return list;
        }
    }
}
