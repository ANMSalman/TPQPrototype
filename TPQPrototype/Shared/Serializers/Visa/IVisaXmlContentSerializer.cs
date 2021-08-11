using System.Threading.Tasks;
using TPQPrototype.Shared.Models.Visa;

namespace TPQPrototype.Shared.Serializers.Visa
{
    public interface IVisaXmlContentSerializer
    {
        Task<VisaXmlContentModel> Deserialize(string content);
        Task<string> Serialize(VisaXmlContentModel model);
    }
}
