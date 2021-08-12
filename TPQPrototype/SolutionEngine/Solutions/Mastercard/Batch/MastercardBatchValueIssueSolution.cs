using System;
using System.Threading.Tasks;
using TPQPrototype.Entities;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Serializers.Mastercard;

namespace TPQPrototype.SolutionEngine.Solutions.Mastercard.Batch
{
    public class MastercardBatchValueIssueSolution : ISolution
    {
        private readonly IMastercardBatchContentSerializer _serializer;

        public MastercardBatchValueIssueSolution(IMastercardBatchContentSerializer serializer)
        {
            _serializer = serializer;
        }

        public (OperatorType, ContentType, Problem) SolutionFor => (OperatorType.Mastercard, ContentType.Batch, Problem.ValueIssue);
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
