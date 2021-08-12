using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TPQPrototype.SearchEngine;
using TPQPrototype.SearchEngine.Aggregates;
using TPQPrototype.SearchEngine.Searchers;
using TPQPrototype.Shared;
using TPQPrototype.Shared.Enums;
using TPQPrototype.Shared.Request;
using TPQPrototype.SolutionEngine;
using TPQPrototype.SolutionEngine.Solutions;

namespace TPQPrototype
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var collection = new ServiceCollection();

            AddServices<IContentSerializer>(collection);
            AddServices<IFactory>(collection);

            AddServices<ISearcher>(collection);
            collection.AddScoped<ISearchEngine, SearchEngine.SearchEngine>();
            collection.Decorate<ISearchEngine, LoyaltyAggregator>();
            collection.Decorate<ISearchEngine, AdminAggregator>();

            AddServices<ISolution>(collection);
            collection.AddScoped<ISolutionEngine, SolutionEngine.SolutionEngine>();


            var services = collection.BuildServiceProvider();

            Console.WriteLine("\nServices Registered");


            var watch = new Stopwatch();

            Console.WriteLine("\nSearching...\n");

            var searchRequest = new SearchRequestModel()
            {
                Networks = new List<long> { 99, 80200 },
                Operators = new List<OperatorType> { OperatorType.Mastercard, OperatorType.Visa },

                ContentTypes = new List<ContentType> { ContentType.Json, ContentType.Xml, ContentType.Batch },
                SearchParameters = new SearchParameters()
                {
                    SearchText = "",
                    StartDate = DateTime.Now.AddDays(-5),
                    EndDate = DateTime.Now
                }
            };

            var searchEngine = services.GetRequiredService<ISearchEngine>();
            watch.Start();

            var result = await searchEngine.Search(searchRequest);

            watch.Stop();

            Console.WriteLine(JsonSerializer.Serialize(result));
            Console.WriteLine();
            Console.WriteLine($"Search Complete. Elapsed Time(milliseconds): {watch.ElapsedMilliseconds}");


            Console.WriteLine("\n\nSolving...\n");

            var solutionRequest = new SolutionRequestModel
            {
                Ids = new List<Guid>(),
                Problem = Problem.MIdIssue,
                Solution = ""
            };

            watch.Reset();

            var solutionEngine = services.GetRequiredService<ISolutionEngine>();

            watch.Start();

            await solutionEngine.Solve(solutionRequest);

            watch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Solution Complete. Elapsed Time(milliseconds): {watch.ElapsedMilliseconds}");

        }
        private static void AddServices<T>(IServiceCollection collection)
        {
            var type = typeof(T);

            var services = type.Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces().Contains(type) && !x.IsAbstract && x.IsClass)
                .Select(x => new
                {
                    Interface = x.GetInterfaces().FirstOrDefault(),
                    Implementation = x
                })
                .ToList();

            foreach (var service in services)
            {
                Console.WriteLine($"Registering : {service.Interface.Name} : {service.Implementation.Name}");
                collection.AddScoped(service.Interface, service.Implementation);
            }
        }
    }

}
