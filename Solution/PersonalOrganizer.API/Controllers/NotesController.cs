using Microsoft.AspNetCore.Mvc;
using PersonalOrganizer.Domain.Entities;
using PersonalOrganizer.Domain.Repositories;

namespace PersonalOrganizer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetAll()
        {
            var notes = await _noteRepository.GetAllAsync();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetById(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note == null)
            {
                return NotFound($"Заметка с ID {id} не найдена.");
            }
            return Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult<Note>> Create([FromBody] CreateNoteDto dto)
        {
            var tempCategory = new Category("Общее", "Описание по умолчанию", "gray", "default-icon");

            var note = new Note(dto.Title, dto.Text, tempCategory);

            await _noteRepository.AddAsync(note);

            return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateNoteDto dto)
        {

            var note = await _noteRepository.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Заметка с Id{id} не найдена");
            }

            note.Update(dto.Title, dto.Text);

            await _noteRepository.UpdateAsync(note);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Заметка с Id{id} не найдена");
            }

            await _noteRepository.DeleteAsync(note);

            return NoContent();
        }

        [HttpPut("{id}/pin")]

        public async Task<IActionResult> Pin(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Заметка с Id{id} не найдена");
            }

            note.Pin();

            await _noteRepository.UpdateAsync(note);

            return Ok(note);
        }

        [HttpPut("{id}/unpin")]

        public async Task<IActionResult> Unpin(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Заметка с Id{id} не найдена");
            }

            note.Unpin();

            await _noteRepository.UpdateAsync(note);

            return Ok(note);
        }

        [HttpPut("{id}/archive")]

        public async Task<IActionResult> Arhcive(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Заметка с Id{id} не найдена");
            }

            note.Archive();

            await _noteRepository.UpdateAsync(note);

            return Ok(note);
        }

        [HttpPut("{id}/unarchive")]

        public async Task<IActionResult> Unarchive(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Заметка с Id{id} не найдена");
            }

            note.Unarchive();

            await _noteRepository.UpdateAsync(note);

            return Ok(note);
        }

        [HttpPost("{id}/tasks")]

        public async Task<IActionResult> AddTask(int id, [FromBody] CreatedTaskDto dto)
        {
            var note = await _noteRepository.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Заметка с Id {id} не найдена");
            }

            var task = new ToDo(dto.Title);

            note.AddTask(task);

            await _noteRepository.UpdateAsync(note);

            return Ok(note);
        }

        [HttpPost("{id}/tags")]

        public async Task<IActionResult> AddTag(int id, [FromBody] CreateTagDto dto)
        {
            var note = await _noteRepository.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Заметка с Id {id} не найдена");
            }
            var tag = new Tag(dto.Name);

            note.AddTag(tag);

            await _noteRepository.UpdateAsync(note);
            
            return Ok(note);


        }
    }

    public class CreateNoteDto
    {
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
    }

    public class UpdateNoteDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    public class CreatedTaskDto
    {
        public string Title { get; set; } = null!;
    }

    public class CreateTagDto
    {
        public string Name { get; set; } = null!;
    }
}