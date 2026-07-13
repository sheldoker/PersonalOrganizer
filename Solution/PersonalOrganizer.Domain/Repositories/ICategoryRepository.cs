using PersonalOrganizer.Domain.Entities;

namespace PersonalOrganizer.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
        Task<Category?> GetByIdAsync(int id);
        Task<IReadOnlyCollection<Category>> GetAllAsync();
    }
}
