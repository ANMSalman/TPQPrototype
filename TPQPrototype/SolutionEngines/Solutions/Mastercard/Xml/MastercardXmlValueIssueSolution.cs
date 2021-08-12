using System;
using System.Threading.Tasks;
using TPQPrototype.Entities;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Serializers.Mastercard;

namespace TPQPrototype.SolutionEngines.Solutions.Mastercard.Xml
{
    public class MastercardXmlValueIssueSolution : ISolution
    {
        private readonly IMastercardXmlContentSerializer _serializer;

        public MastercardXmlValueIssueSolution(IMastercardXmlContentSerializer serializer)
        {
            _serializer = serializer;
        }

        public (OperatorType, ContentType, Problem) SolutionFor => (OperatorType.Mastercard, ContentType.Xml, Problem.ValueIssue);
        public async Task Solve(ProcessingQueue record, string solution)
        {
            var obj = await _serializer.Deserialize(record.Content);

            // apply changes

            //fake work simulation

            Console.WriteLine($"Solving: {SolutionFor}");
            await Task.Delay(2000);
        }
    }
}
