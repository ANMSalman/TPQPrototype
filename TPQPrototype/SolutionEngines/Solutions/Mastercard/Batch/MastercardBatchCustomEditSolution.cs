using System;
using System.Threading.Tasks;
using TPQPrototype.Entities;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Serializers.Mastercard;

namespace TPQPrototype.SolutionEngines.Solutions.Mastercard.Batch
{
    public class MastercardBatchCustomEditSolution : ISolution
    {
        private readonly IMastercardBatchContentSerializer _serializer;

        public MastercardBatchCustomEditSolution(IMastercardBatchContentSerializer serializer)
        {
            _serializer = serializer;
        }

        public (OperatorType, ContentType, Problem) SolutionFor => (OperatorType.Mastercard, ContentType.Batch, Problem.CustomEdit);
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
