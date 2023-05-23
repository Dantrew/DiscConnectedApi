using DiscConnectedApi.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DiscConnectedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumsController : ControllerBase
    {
        private readonly ForumManager _forumManager;
        public ForumsController(ForumManager forumManager)
        {
            _forumManager = forumManager;
        }


        [HttpGet]
        public async Task<IEnumerable<Models.Forum>> GetForums()
        {
            var forums = await _forumManager.GetAllForums();
            return forums;
        }

        [HttpGet("{id}")]
        public async Task<Models.Forum> GetOneForum(int id)
        {
            var forum = await _forumManager.GetOneForum(id);

            return forum;
        }

        [HttpPost]
        public async Task Post([FromBody] Models.Forum forum)
        {
            await _forumManager.CreateForum(forum);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Models.Forum forum)
        {
            await _forumManager.UpdateForum(forum, id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _forumManager.DeleteForum(id);
        }

    }
}
