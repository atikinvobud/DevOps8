namespace Backend;

public static class NotesExtensions
{
    public static GetDTO ToDTO(this Notes note)
    {
        return new GetDTO()
        {
            Id  = note.Id,
            Title = note.Title,
            Body = note.Body
        };
    }

    public static Notes ToEntity(this PostDTO postDTO)
    {
        return new Notes()
        {
            Title = postDTO.Title,
            Body = postDTO.Body
        };
    }

    public static void UpdateModel(this Notes note, PutDTO putDTO)
    {
        note.Title = putDTO.Title ?? note.Title;
        note.Body = putDTO.Body ?? note.Body;
    }
}