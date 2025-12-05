namespace Backend;

public interface IMongoRepository
{
    Task AddNote(Notes note);
    Task<List<Notes>> GetAllNotes();
    Task<Notes?> GetNoteById(string id);
    Task ChangeNote(string id, Notes note);
    Task DeleteNote(string id);
}