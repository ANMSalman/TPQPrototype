using System.Threading.Tasks;
using TPQPrototype.Shared.Models.Visa;

namespace TPQPrototype.Shared.Serializers.Visa
{
    public class VisaXmlContentSerializer : IVisaXmlContentSerializer
    {
        public async Task<VisaXmlContentModel> Deserialize(string content)
        {
            // perform deserialization here

            await Task.CompletedTask;

            return new VisaXmlContentModel();
        }

        public async Task<string> Serialize(VisaXmlContentModel model)
        {
            // perform serialization here

            await Task.CompletedTask;

            return "<></>";
        }
    }
}
