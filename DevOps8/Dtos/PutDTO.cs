namespace Backend;

public record PutDTO
{
    public required string Id { get; set; }
    public string? Title{ get; set; }
    public string? Body { get; set; }
}