using CVA.Tests.Integration.Network;

namespace CVA.Tests.Integration.Fixtures;

public class MongoFixture : IAsyncLifetime
{
    private readonly INetwork _network;
    private readonly MongoDbContainer _container;

    public MongoFixture()
    {
        _network = Initializer.Init();
        _container = (MongoDbContainer)Mongo.Initializer.Init(_network);
    }

    public string ConnectionString => _container.GetConnectionString();

    public async Task InitializeAsync()
    {
        await _network.CreateAsync();
        await _container.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _container.DisposeAsync();
        await _network.DisposeAsync();
    }
}