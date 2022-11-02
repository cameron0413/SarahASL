using SarahASL.Models;

namespace SarahASL.Services.Interfaces
{
    public interface IDictionaryService
    {
        Task<IEnumerable<Tag>> GetUserTagsAsync(string appUserId);
    }
}
