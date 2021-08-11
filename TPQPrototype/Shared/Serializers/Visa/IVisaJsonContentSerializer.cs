using System.Threading.Tasks;
using TPQPrototype.Shared.Models.Visa;

namespace TPQPrototype.Shared.Serializers.Visa
{
    public interface IVisaJsonContentSerializer : IContentSerializer
    {
        Task<VisaJsonContentModel> Deserialize(string content);
        Task<string> Serialize(VisaJsonContentModel model);
    }
}
