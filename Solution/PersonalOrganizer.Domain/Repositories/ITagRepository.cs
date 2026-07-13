

using PersonalOrganizer.Domain.Entities;

namespace PersonalOrganizer.Domain.Repositories
{
    public interface ITagRepository
    {
        Task AddAsync(Tag tag);
        Task UpdateAsync(Tag tag);
        Task DeleteAsync(Tag tag);
        Task<Tag?> GetByIdAsync(int id);
        Task<IReadOnlyCollection<Tag>> GetAllAsync();
    }
}
