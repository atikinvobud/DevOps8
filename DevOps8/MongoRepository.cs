using MongoDB.Driver;

namespace Backend;

public class MongoRepository : IMongoRepository
{
    private readonly MongoContext mongoContext;

    public MongoRepository(MongoContext mongoContext)
    {
        this.mongoContext = mongoContext;
    }

    public async Task AddNote(Notes note)
    {
        await mongoContext.Notes.InsertOneAsync(note);
    }

    public async Task ChangeNote(string id, Notes note)
    {
        var filter = Builders<Notes>.Filter.Eq(n => n.Id, id);
        await mongoContext.Notes.ReplaceOneAsync(filter, note);
    }

    public async Task DeleteNote(string id)
    {
        var filter = Builders<Notes>.Filter.Eq(n => n.Id, id);
        await mongoContext.Notes.DeleteOneAsync(filter);
    }

    public async Task<List<Notes>> GetAllNotes()
    {
        return await mongoContext.Notes.Find(_ => true).ToListAsync();
    }

    public async Task<Notes?> GetNoteById(string id)
    {
        var filter = Builders<Notes>.Filter.Eq(n => n.Id, id);
        return await mongoContext.Notes.Find(filter).FirstOrDefaultAsync();
    }
}
