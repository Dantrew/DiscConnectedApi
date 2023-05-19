using DiscConnectedApi.DbContext;
using DiscConnectedApi.Models;
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

        public static List<Models.Forum> Forums { get; set; }

        internal static async Task CreateForum(Forum forum)
        {
            if (Forums is null)
            {
                await ForumData.GetForums();
            }

            Forums.Add(forum);
        }

        internal static async Task DeleteForum(int id)
        {
            if (Forums is null)
            {
                await ForumData.GetForums();
            }

            Forums.RemoveAt(id-1);
        }

        internal static async Task<List<Forum>> GetAllForums()
        {
            if (Forums == null || !Forums.Any())
            {
                Forums = await ForumData.GetForums();
            }

            return Forums;
        }

        internal static async Task<Forum> GetOneForum(int id)
        {
            if (Forums == null || !Forums.Any())
            {
                Forums = await ForumData.GetForums();
            }

            var existingForum = Forums.Where(p => p.Id == id).SingleOrDefault();

            if (existingForum != null)
            {
                return existingForum;
            }
            else
            {
                return null;
            }
        }

        internal static async Task UpdateForum(Forum forum, int id)
        {
            if (Forums is null)
            {
                Forums = await ForumData.GetForums();
            }

            var existingForum = Forums.FirstOrDefault(p => p.Id == id);
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
            }
        }
    }
}
