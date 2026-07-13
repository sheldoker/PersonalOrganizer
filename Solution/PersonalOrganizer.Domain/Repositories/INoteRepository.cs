using PersonalOrganizer.Domain.Entities;
using System;

namespace PersonalOrganizer.Domain.Repositories
{
    public interface INoteRepository
    {
        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(Note note);
        Task<Note?> GetByIdAsync(int id);
        Task<IReadOnlyCollection<Note>> GetAllAsync();
    }
}
