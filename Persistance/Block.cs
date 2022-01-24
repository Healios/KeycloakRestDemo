using Core.Models.Company;
using Core.Models.Partner;
using Core.Models.Common;
using Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Persistance.Repositories;
using Persistance.Settings;

namespace Persistance
{
    public static class Block
    {
        /// <summary>
        /// Hooks up MongoDb.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            // Get database settings and add to DI.
            var section = configuration.GetSection("DatabaseSettings");
            services.Configure<DatabaseSettings>(section);

            // Add Mongodb client to DI.
            var databaseSettings = section.Get<DatabaseSettings>();
            services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(databaseSettings.ConnectionString));

            // Add repositories to DI.
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();

            // Map our C# models to Mongodb bson documents.
            BsonClassMap.RegisterClassMap<Company>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(cm => cm.Id)
                  .SetIgnoreIfDefault(true)
                  .SetIdGenerator(StringObjectIdGenerator.Instance)
                  .SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
            BsonClassMap.RegisterClassMap<PartnerReference>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(cm => cm.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });

            BsonClassMap.RegisterClassMap<Partner>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(cm => cm.Id)
                  .SetIgnoreIfDefault(true)
                  .SetIdGenerator(StringObjectIdGenerator.Instance)
                  .SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
            BsonClassMap.RegisterClassMap<Contact>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(cm => cm.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });

            return services;
        }
    }
}
