using System.Threading.Tasks;
using TPQPrototype.Shared.Models.Mastercard;

namespace TPQPrototype.Shared.Serializers.Mastercard
{
    public class MastercardBatchContentSerializer : IMastercardBatchContentSerializer
    {
        public async Task<MastercardBatchContentModel> Deserialize(string content)
        {
            // perform deserialization here

            await Task.CompletedTask;

            return new MastercardBatchContentModel();
        }
        public async Task<string> Serialize(MastercardBatchContentModel model)
        {
            // perform serialization here

            await Task.CompletedTask;

            return "";
        }
    }
}
