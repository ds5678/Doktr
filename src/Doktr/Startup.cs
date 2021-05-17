using System;
using Doktr.Services;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Doktr
{
    public static class Startup
    {
        public static IServiceProvider ConfigureServices(DoktrConfiguration configuration, ILogger logger)
        {
            var collection = new ServiceCollection();

            collection.AddSingleton(configuration);
            collection.AddSingleton(logger);

            collection.AddSingleton<IAssemblyRepositoryService, AssemblyRepositoryService>();
            collection.AddSingleton<IMetadataResolutionService, MetadataResolutionService>();
            collection.AddTransient<IGraphBuilderService, GraphBuilderService>();
            
            return collection.BuildServiceProvider();
        }
    }
}