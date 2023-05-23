using DiscConnectedApi.DbContext;
using DiscConnectedApi.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DiscConnectedApi.DAL
{
    public class ForumManager

    {
        private readonly MyDbContext _context;
        public ForumManager(MyDbContext context)
        {
            _context = context;
        }

        internal async Task CreateForum(Forum forum)
        {
            var newForum = new Forum
            {
                Name = forum.Name,
                Date = DateTime.Now,
            };
            await _context.Forum.AddAsync(newForum);
            await _context.SaveChangesAsync();
        }

        internal async Task DeleteForum(int id)
        {
            var deleteForum = await _context.Forum.Where(f => f.Id == id).FirstOrDefaultAsync();
            _context.Forum.Remove(deleteForum);
            await _context.SaveChangesAsync();
        }
        
        internal async Task<List<Forum>> GetAllForums()
        {
            return await _context.Forum.ToListAsync();
        }

        internal async Task<Forum> GetOneForum(int id)
        {
            var existingForum = _context.Forum.Where(p => p.Id == id).SingleOrDefault();

            if (existingForum != null)
            {
                return existingForum;
            }
            else
            {
                return null;
            }
        }

        internal async Task UpdateForum(Forum forum, int id)
        {
            var existingForum = await _context.Forum.FirstOrDefaultAsync(p => p.Id == id);
            if (existingForum != null)
            {
                existingForum.Name = forum.Name;

                var validationContext = new ValidationContext(existingForum, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(existingForum, validationContext, validationResults, validateAllProperties: true);

                if (!isValid)
                {
                    string validationErrors = string.Join(", ", validationResults.Select(v => v.ErrorMessage));
                    Console.WriteLine($"Validation errors: {validationErrors}");
                }
                else
                {
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
