using MicroContent.CompanyProduct.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MicroContent.CompanyProduct.API;

public class MongoDbContext
{
    private readonly IMongoDatabase _database = null;

    public MongoDbContext(IOptions<Settings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        if (client != null)
            _database = client.GetDatabase(settings.Value.Database);
    }

    public IMongoCollection<Commons.CompanyProduct> Products
    {
        get { return _database.GetCollection<Commons.CompanyProduct>("Products");}
    }
}