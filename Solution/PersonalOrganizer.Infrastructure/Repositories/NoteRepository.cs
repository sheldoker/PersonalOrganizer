using PersonalOrganizer.Domain.Entities;
using PersonalOrganizer.Domain.Repositories;
using PersonalOrganizer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace PersonalOrganizer.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;

        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Note note)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Note>> GetAllAsync()
        {
            return await _context.Notes
                .Include(n => n.Category)
                .Include(n => n.Tags)
                .Include(n => n.Tasks)
                .ToListAsync();
        }

        public async Task<Note?> GetByIdAsync(int id)
        {
            return await _context.Notes
                .Include(n => n.Category)
                .Include(n => n.Tags)
                .Include(n => n.Tasks)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }
    }
}
