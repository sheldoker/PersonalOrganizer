using PersonalOrganizer.Domain.Repositories;
using PersonalOrganizer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using PersonalOrganizer.Domain.Entities;

namespace PersonalOrganizer.Infrastructure.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext _context;

        public ToDoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ToDo toDo)
        {
            _context.ToDos.Add(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ToDo toDo)
        {
            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<ToDo>> GetAllAsync()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<ToDo?> GetByIdAsync(int id)
        {
            return await _context.ToDos.FindAsync(id);
        }

        public async Task UpdateAsync(ToDo toDo)
        {
            _context.ToDos.Update(toDo);
            await _context.SaveChangesAsync();
        }
    }
}
