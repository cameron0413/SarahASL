using Microsoft.EntityFrameworkCore;
using SarahASL.Data;
using SarahASL.Models;
using SarahASL.Services.Interfaces;

namespace SarahASL.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly ApplicationDbContext _context;

        public DictionaryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetUserTagsAsync(string appUserId)
        {
            List<Tag> tags = new List<Tag>();
            try
            {
                tags = await _context.Tag!
                                     .Where(t => t.AslUserId == appUserId)
                                     .OrderBy(t => t.Name)
                                     .ToListAsync();

                
            }
            catch (Exception)
            {

                throw;
            }
            return tags;
        }
    }
}
