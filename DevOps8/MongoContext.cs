using MongoDB.Driver;

namespace Backend;

public class MongoContext
{
    public IMongoDatabase database {get;}
    public MongoContext(string connectionString, string databaseName)
    {
        database = new MongoClient(connectionString).GetDatabase(databaseName);
        EnsureCollections();
    }
    private void EnsureCollections()
    {
        var collections = database.ListCollectionNames().ToList();
        if(!collections.Contains("Notes")) database.CreateCollection("Notes");
    }
    public IMongoCollection<Notes> Notes => database.GetCollection<Notes>("Notes");
}