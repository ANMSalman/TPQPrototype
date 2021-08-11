using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using TPQPrototype.Enums;
using TPQPrototype.SearchEngine;
using TPQPrototype.SearchEngine.Aggregates;
using TPQPrototype.SearchEngine.Engines;
using TPQPrototype.SearchEngine.Engines.Mastercard;
using TPQPrototype.SearchEngine.Engines.Mastercard.ContentSource;
using TPQPrototype.SearchEngine.Engines.Mastercard.ContentSource.Batch;
using TPQPrototype.SearchEngine.Engines.Mastercard.ContentSource.Xml;
using TPQPrototype.SearchEngine.Engines.Visa;
using TPQPrototype.SearchEngine.Engines.Visa.ContentSource;
using TPQPrototype.SearchEngine.Engines.Visa.ContentSource.Json;
using TPQPrototype.SearchEngine.Engines.Visa.ContentSource.Xml;
using TPQPrototype.Shared.Request;
using TPQPrototype.Shared.Serializers.Mastercard;
using TPQPrototype.Shared.Serializers.Visa;

namespace TPQPrototype
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var collection = new ServiceCollection();

            AddSerializers(collection);
            AddFactories(collection);
            AddEngines(collection);

            collection.AddScoped<ISearchEngine, SearchEngine.Engines.SearchEngine>();
            collection.Decorate<ISearchEngine, LoyaltyAggregator>();
            collection.Decorate<ISearchEngine, AdminAggregator>();

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

            var watch = new Stopwatch();
            watch.Start();

            var result = await engine.Search(request);

            watch.Stop();

            Console.WriteLine(JsonSerializer.Serialize(result));
            Console.WriteLine();
            Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}");

        }
        private static void AddSerializers(IServiceCollection services)
        {
            //TODO: need to find a way to register dynamically. May be using Scrutor

            services.AddScoped<IMastercardXmlContentSerializer, MastercardXmlContentSerializer>();
            services.AddScoped<IMastercardBatchContentSerializer, MastercardBatchContentSerializer>();

            services.AddScoped<IVisaJsonContentSerializer, VisaJsonContentSerializer>();
            services.AddScoped<IVisaXmlContentSerializer, VisaXmlContentSerializer>();
        }
        private static void AddFactories(IServiceCollection services)
        {
            //TODO: need to find a way to register dynamically. May be using Scrutor

            services.AddScoped<IOperatorSearchEngineFactory, OperatorSearchEngineFactory>();
            services.AddScoped<IMastercardContentSourceSearchEngineFactory, MastercardContentSourceSearchEngineFactory>();
            services.AddScoped<IVisaContentSourceSearchEngineFactory, VisaContentSourceSearchEngineFactory>();
        }
        private static void AddEngines(IServiceCollection services)
        {
            //TODO: need to find a way to register dynamically. May be using Scrutor

            services.AddScoped<IOperatorSearchEngine, MastercardSearchEngine>();
            services.AddScoped<IMastercardContentSourceSearchEngine, MastercardXmlSearchEngine>();
            services.AddScoped<IMastercardContentSourceSearchEngine, MastercardBatchSearchEngine>();


            services.AddScoped<IOperatorSearchEngine, VisaSearchEngine>();
            services.AddScoped<IVisaContentSourceSearchEngine, VisaXmlSearchEngine>();
            services.AddScoped<IVisaContentSourceSearchEngine, VisaJsonSearchEngine>();
        }
    }

}
