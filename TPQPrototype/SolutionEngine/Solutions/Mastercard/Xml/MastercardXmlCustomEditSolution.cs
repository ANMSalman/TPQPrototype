using System;
using System.Threading.Tasks;
using TPQPrototype.Entities;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Serializers.Mastercard;

namespace TPQPrototype.SolutionEngine.Solutions.Mastercard.Xml
{
    public class MastercardXmlCustomEditSolution : ISolution
    {
        private readonly IMastercardXmlContentSerializer _serializer;

        public MastercardXmlCustomEditSolution(IMastercardXmlContentSerializer serializer)
        {
            _serializer = serializer;
        }

        public (OperatorType, ContentType, Problem) SolutionFor => (OperatorType.Mastercard, ContentType.Xml, Problem.CustomEdit);
        public async Task Solve(ProcessingQueue record, string solution)
        {
            var obj = await _serializer.Deserialize(record.Content);
            var editedObj = await _serializer.Deserialize(solution);

            // apply changes
            // validations

            //fake work simulation

            Console.WriteLine($"Solving: {SolutionFor}");
            await Task.Delay(2000);
        }
    }
}
