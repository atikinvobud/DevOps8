namespace Backend;

public record PostDTO
{
    public required string Title { get; set; }
    public required string Body { get; set; }
}