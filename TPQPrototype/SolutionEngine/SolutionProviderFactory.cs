using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TPQPrototype.Shared.Enums;
using TPQPrototype.SolutionEngine.Solutions;

namespace TPQPrototype.SolutionEngine
{
    public class SolutionProviderFactory : ISolutionProviderFactory
    {
        private readonly IReadOnlyDictionary<(OperatorType, ContentType, Problem), ISolution> _solutions;

        public SolutionProviderFactory(IServiceProvider serviceProvider)
        {
            _solutions = serviceProvider.GetServices<ISolution>()
                .ToImmutableDictionary(x => x.SolutionFor, x => x);
        }
        public ISolution GetSolution(OperatorType operatorType, ContentType contentType, Problem problem)
        {
            return _solutions.FirstOrDefault(x =>
                x.Key.Item1 == operatorType && x.Key.Item2 == contentType && x.Key.Item3 == problem).Value;
        }
    }
}
