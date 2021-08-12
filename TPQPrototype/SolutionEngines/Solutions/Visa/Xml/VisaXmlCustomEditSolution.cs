using System;
using System.Threading.Tasks;
using TPQPrototype.Entities;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Serializers.Visa;

namespace TPQPrototype.SolutionEngines.Solutions.Visa.Xml
{
    public class VisaXmlCustomEditSolution : ISolution
    {
        private readonly IVisaXmlContentSerializer _serializer;

        public VisaXmlCustomEditSolution(IVisaXmlContentSerializer serializer)
        {
            _serializer = serializer;
        }

        public (OperatorType, ContentType, Problem) SolutionFor => (OperatorType.Visa, ContentType.Xml, Problem.CustomEdit);
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
