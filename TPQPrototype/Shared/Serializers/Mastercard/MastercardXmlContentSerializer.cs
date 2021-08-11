using System.Threading.Tasks;
using TPQPrototype.Shared.Models.Mastercard;

namespace TPQPrototype.Shared.Serializers.Mastercard
{
    public class MastercardXmlContentSerializer : IMastercardXmlContentSerializer
    {
        public async Task<MastercardXmlContentModel> Deserialize(string content)
        {
            // perform deserialization here

            await Task.CompletedTask;

            return new MastercardXmlContentModel();
        }

        public async Task<string> Serialize(MastercardXmlContentModel model)
        {
            // perform serialization here

            await Task.CompletedTask;

            return "<></>";
        }
    }
}
