using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace CVA.Infrastructure.Mongo;

/// <summary>
/// Provides configuration for dependency injection related to the MongoDB database.
/// </summary>
public static class DiConfig
{
    /// <summary>
    /// Registers MongoDB services and configurations into the dependency injection container.
    /// This includes the MongoDB client, database options, and user repository.
    /// </summary>
    /// <param name="services">The collection of service descriptors where the MongoDB services will be registered.</param>
    /// <param name="mongoOptions">The configuration options used to establish MongoDB connections and identify the target database.</param>
    public static void RegisterMongo(this IServiceCollection services, MongoOptions mongoOptions)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        if (!BsonClassMap.IsClassMapRegistered(typeof(User)))
        {
            BsonClassMap.RegisterClassMap<User>(classMap =>
            {
                classMap.AutoMap();
                classMap.MapIdMember(user => user.Id);
            });
        }

        if (!BsonClassMap.IsClassMapRegistered(typeof(Work)))
        {
            BsonClassMap.RegisterClassMap<Work>(classMap =>
            {
                classMap.AutoMap();
            });
        }

        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoOptions.Connection));
        services.AddSingleton(mongoOptions);
        services.AddScoped<IUserRepository, UserMongoRepository>();
    }
}