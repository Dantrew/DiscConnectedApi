using DiscConnectedApi.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DiscConnectedApi.DAL
{
    public class ForumData
    {
        private readonly MyDbContext _context;
        public ForumData(MyDbContext context)
        {
            _context = context;
        }

        //public async Task<List<Models.Forum>> GetForums()
        //{
        //    List<Models.Forum> forums = new();

            //using (var context = new MyDbContext())
            //{
                //forums = await _context.Forum.ToListAsync();
            //}


        //    return forums;
        //}

    }
}
