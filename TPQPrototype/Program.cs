using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TPQPrototype.Enums;
using TPQPrototype.SearchEngine;
using TPQPrototype.SearchEngine.Aggregates;
using TPQPrototype.SearchEngine.Engines;
using TPQPrototype.Shared;
using TPQPrototype.Shared.Request;

namespace TPQPrototype
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var collection = new ServiceCollection();

            AddServices<IContentSerializer>(collection);
            AddServices<IFactory>(collection);
            AddServices<IEngine>(collection);

            collection.AddScoped<ISearchEngine, SearchEngine.Engines.SearchEngine>();
            collection.Decorate<ISearchEngine, LoyaltyAggregator>();
            collection.Decorate<ISearchEngine, AdminAggregator>();

            Console.WriteLine("\nServices Registered");


            var services = collection.BuildServiceProvider();

            var request = new SearchRequestModel()
            {
                Networks = new List<long> { 99, 80200 },
                Operators = new List<OperatorType> { OperatorType.Mastercard, OperatorType.Visa },
                OperatorSearchParameters = new OperatorSearchParameters()
                {
                    ContentTypes = new List<ContentType> { ContentType.Json, ContentType.Xml, ContentType.Batch },
                    ContentSearchParameters = new ContentSearchParameters()
                    {
                        SearchText = "",
                        StartDate = DateTime.Now.AddDays(-5),
                        EndDate = DateTime.Now
                    }
                }
            };

            var engine = services.GetRequiredService<ISearchEngine>();


            Console.WriteLine("\nSearching...\n");

            var watch = new Stopwatch();
            watch.Start();

            var result = await engine.Search(request);

            watch.Stop();

            Console.WriteLine(JsonSerializer.Serialize(result));
            Console.WriteLine();
            Console.WriteLine($"Search Complete. Elapsed Time(milliseconds): {watch.ElapsedMilliseconds}");

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

        //private static void AddSerializers(IServiceCollection services)
        //{
        //    //TODO: need to find a way to register dynamically. May be using Scrutor

        //    services.AddScoped<IMastercardXmlContentSerializer, MastercardXmlContentSerializer>();
        //    services.AddScoped<IMastercardBatchContentSerializer, MastercardBatchContentSerializer>();

        //    services.AddScoped<IVisaJsonContentSerializer, VisaJsonContentSerializer>();
        //    services.AddScoped<IVisaXmlContentSerializer, VisaXmlContentSerializer>();
        //}
        //private static void AddFactories(IServiceCollection services)
        //{
        //    //TODO: need to find a way to register dynamically. May be using Scrutor

        //    services.AddScoped<IOperatorSearchEngineFactory, OperatorSearchEngineFactory>();
        //    services.AddScoped<IMastercardContentSourceSearchEngineFactory, MastercardContentSourceSearchEngineFactory>();
        //    services.AddScoped<IVisaContentSourceSearchEngineFactory, VisaContentSourceSearchEngineFactory>();
        //}
        //private static void AddEngines(IServiceCollection services)
        //{
        //    //TODO: need to find a way to register dynamically. May be using Scrutor

        //    services.AddScoped<IOperatorSearchEngine, MastercardSearchEngine>();
        //    services.AddScoped<IMastercardContentSourceSearchEngine, MastercardXmlSearchEngine>();
        //    services.AddScoped<IMastercardContentSourceSearchEngine, MastercardBatchSearchEngine>();


        //    services.AddScoped<IOperatorSearchEngine, VisaSearchEngine>();
        //    services.AddScoped<IVisaContentSourceSearchEngine, VisaXmlSearchEngine>();
        //    services.AddScoped<IVisaContentSourceSearchEngine, VisaJsonSearchEngine>();
        //}
    }

}
