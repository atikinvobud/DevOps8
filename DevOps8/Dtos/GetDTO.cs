namespace Backend;

public record GetDTO
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Body { get; set; }
}