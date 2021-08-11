using System.Threading.Tasks;
using TPQPrototype.Shared.Models.Mastercard;

namespace TPQPrototype.Shared.Serializers.Mastercard
{
    public interface IMastercardXmlContentSerializer : IContentSerializer
    {
        Task<MastercardXmlContentModel> Deserialize(string content);
        Task<string> Serialize(MastercardXmlContentModel model);
    }
}
