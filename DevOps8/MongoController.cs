using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Backend;

[ApiController]
[Route("todos")]
public class NotesController : ControllerBase
{
    private readonly IMongoRepository mongoRepository;
    public NotesController(IMongoRepository mongoRepository)
    {
        this.mongoRepository = mongoRepository;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        List<Notes> notes = await mongoRepository.GetAllNotes();
        List<GetDTO> dtos = new List<GetDTO>();
        foreach (var note in notes)
        {
            dtos.Add(note.ToDTO());
        }
        return Ok(dtos);
    }
    [HttpPost()]
    public async Task<IActionResult> CreateNote([FromBody] PostDTO postDTO)
    {
        Notes note =postDTO.ToEntity();
        await mongoRepository.AddNote(note);
        return Ok(note.Id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        Notes? note = await mongoRepository.GetNoteById(id);
        if(note is null) return NotFound();
        return Ok(note.ToDTO()); 
    }
    [HttpPut()]
    public async Task<IActionResult> UpdateById([FromBody] PutDTO putDTO)
    {
        Notes? note = await mongoRepository.GetNoteById(putDTO.Id);
        if(note is null) return NotFound();
        note.UpdateModel(putDTO);
        await mongoRepository.ChangeNote(note.Id, note);
        return Ok(note);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById([FromRoute] string id)
    {
        await mongoRepository.DeleteNote(id);
        return NoContent();
    }
}