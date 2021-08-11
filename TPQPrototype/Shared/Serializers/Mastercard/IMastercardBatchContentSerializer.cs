using System.Threading.Tasks;
using TPQPrototype.Shared.Models.Mastercard;

namespace TPQPrototype.Shared.Serializers.Mastercard
{
    public interface IMastercardBatchContentSerializer : IContentSerializer
    {
        Task<MastercardBatchContentModel> Deserialize(string content);
        Task<string> Serialize(MastercardBatchContentModel model);
    }
}
