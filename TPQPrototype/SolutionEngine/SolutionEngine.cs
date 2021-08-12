using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TPQPrototype.Entities;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Request;

namespace TPQPrototype.SolutionEngine
{
    public class SolutionEngine : ISolutionEngine
    {
        private readonly ISolutionProviderFactory _solutionProviderFactory;

        public SolutionEngine(ISolutionProviderFactory solutionProviderFactory)
        {
            _solutionProviderFactory = solutionProviderFactory;
        }


        public async Task Solve(SolutionRequestModel request)
        {
            //Get Id related data from the database
            var records = new ProcessingQueue[]
            {
                new ProcessingQueue
                {
                    Id = Guid.NewGuid(),
                    OperatorType = OperatorType.Mastercard,
                    ContentType = ContentType.Xml,
                    Content = ""
                },
                new ProcessingQueue
                {
                    Id = Guid.NewGuid(),
                    OperatorType = OperatorType.Mastercard,
                    ContentType = ContentType.Batch,
                    Content = ""
                },
                new ProcessingQueue
                {
                    Id = Guid.NewGuid(),
                    OperatorType = OperatorType.Mastercard,
                    ContentType = ContentType.Xml,
                    Content = ""
                },
                new ProcessingQueue
                {
                    Id = Guid.NewGuid(),
                    OperatorType = OperatorType.Visa,
                    ContentType = ContentType.Xml,
                    Content = ""
                },
                new ProcessingQueue
                {
                    Id = Guid.NewGuid(),
                    OperatorType = OperatorType.Visa,
                    ContentType = ContentType.Json,
                    Content = ""
                },
            };

            var tasks = new List<Task>();

            foreach (var item in records)
            {
                var solution =
                    _solutionProviderFactory.GetSolution(item.OperatorType, item.ContentType, request.Problem);

                if (solution is null)
                {
                    // should throw an exception saying Solution not found
                    continue;
                }

                tasks.Add(solution.Solve(item, request.Solution));
            }

            await Task.WhenAll(tasks);

            //DBContext is Scoped. So Call SaveChanges() here to preserve ACID.
        }
    }
}
