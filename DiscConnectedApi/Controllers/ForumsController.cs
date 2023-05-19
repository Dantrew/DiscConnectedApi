using Microsoft.AspNetCore.Mvc;

namespace DiscConnectedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumsController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Models.Forum>> GetProducts()
        {
            var forums = await DAL.ForumManager.GetAllForums();
            return forums;
        }

        [HttpGet("{id}")]
        public async Task<Models.Forum> GetOneProduct(int id)
        {
            var forum = await DAL.ForumManager.GetOneForum(id);

            return forum;
        }

        [HttpPost]
        public async Task Post([FromBody] Models.Forum forum)
        {
            await DAL.ForumManager.CreateForum(forum);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Models.Forum forum)
        {
            await DAL.ForumManager.UpdateForum(forum, id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await DAL.ForumManager.DeleteForum(id);
        }

    }
}
