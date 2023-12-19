using Herond.Common.Utils;
using MongoDB.Driver;

namespace Herond.Common.DBContext;

public class BaseMongoDbContext
{
    protected BaseMongoDbContext(string connectionString, string mongoDbName)
    {
        Guard.ThrowIf(GetType().Name, connectionString).Null();

        ConnectionStr = connectionString;
        Client = new MongoClient(connectionString);
        MongoDatabase = Client.GetDatabase(mongoDbName);
    }

    protected MongoClient Client { get; }
    protected string ConnectionStr { get; }
    protected IMongoDatabase MongoDatabase { get; }
    
    protected async Task UsingSessionTransaction(Func<IClientSessionHandle, Task> func)
    {
        using var session = await Client.StartSessionAsync();
        session.StartTransaction();
        try
        {
            await func(session);
            await session.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error commit transaction to MongoDB: " + e.Message);
            await session.AbortTransactionAsync();
        }
    }
}