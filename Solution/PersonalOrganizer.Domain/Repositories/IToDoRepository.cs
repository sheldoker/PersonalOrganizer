using PersonalOrganizer.Domain.Entities;

namespace PersonalOrganizer.Domain.Repositories
{
    public interface IToDoRepository
    {
        Task AddAsync(ToDo toDo);
        Task UpdateAsync(ToDo toDo);
        Task DeleteAsync(ToDo toDo);
        Task<ToDo?> GetByIdAsync(int id);
        Task<IReadOnlyCollection<ToDo>> GetAllAsync();
    }
}
