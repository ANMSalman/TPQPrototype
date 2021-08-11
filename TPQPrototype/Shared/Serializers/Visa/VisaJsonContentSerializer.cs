using System.Threading.Tasks;
using TPQPrototype.Shared.Models.Visa;

namespace TPQPrototype.Shared.Serializers.Visa
{
    public class VisaJsonContentSerializer : IVisaJsonContentSerializer
    {
        public async Task<VisaJsonContentModel> Deserialize(string content)
        {
            // perform deserialization here

            await Task.CompletedTask;

            return new VisaJsonContentModel();
        }
        public async Task<string> Serialize(VisaJsonContentModel model)
        {
            // perform serialization here

            await Task.CompletedTask;

            return "";
        }
    }
}
