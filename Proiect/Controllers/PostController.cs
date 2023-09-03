
using DAL.Models;
using DAL.Models.DTO;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Proiect.Services.CategoryService;
using Proiect.Services.PostService;
using System.Security.Claims;
using System.Xml.Linq;


namespace Proiect.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public PostController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        /*    [HttpGet]
            [Route("categories/names")]
            [EnableCors("AllowAll")]*/

        //public async Task<IActionResult> GetAllCategories()
        //    {
        //   var categories = await _categoryService.GetAllCategories();
        //    return Ok(categories);
        //    }
        /*
                [Authorize(Roles = "Admin")]
                [HttpGet]
                [Route("/category/{categoryName}")]
                [EnableCors("AllowAll")]*/



        /*
                [HttpGet("{id}")]
                public async Task<IActionResult> GetPostById(Guid id)
                {
                    var category = await _postService.GetPostById(id);
                    if (category == null)
                        return NotFound();

                    return Ok(category);
                }
        */
        [Authorize(Roles = "Admin")]
        [EnableCors("AllowAll")]
        [HttpPost("new-post")]
        public async Task<IActionResult> CreatePost([FromBody] PostDto post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var categoryId = await _categoryService.GetCategoryIdByName(post.CategoryName);

            string userIdClaimValue = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdClaimValue, out Guid userId))
            {
                var newPost = new Post
                {
                    Title = post.Title,
                    Content = post.Content,
                    ImageURL = post.ImageURL,
                    UserId = userId

                };
               
                var createdPost = await _postService.CreatePost(newPost, (Guid)categoryId);
                return CreatedAtAction(nameof(GetPostById), new { id = createdPost.Id }, createdPost);


            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [Authorize(Roles = "Admin")]
        [EnableCors("AllowAll")]
        [HttpDelete("delete-post/{postId}")]
        public IActionResult DeletePost(string postId)
        {
            try
            {
                if (!Guid.TryParse(postId, out Guid id))
                {
                    return BadRequest("Invalid postId format"); 
                }

              
                var deleted = _postService.DeletePost(id);

                if (deleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the post."); 
            }
        }
        [EnableCors("AllowAll")]
        [HttpPost("save-post/{postId}")]
        public IActionResult SavePost(string postId)
        {
            try
            {
                if (!Guid.TryParse(postId, out Guid id))
                {
                    return BadRequest("Invalid postId format");
                }
                string userIdClaimValue = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!Guid.TryParse(userIdClaimValue, out Guid userId))
                {
                    return BadRequest("Invalid userId format"); 
                }

               
                var saved = _postService.SavePost(id, userId);

                if (saved)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the post."); 
            }
        }

        [EnableCors("AllowAll")]
        [HttpGet("{postId}")]
        public async Task<ActionResult<Post>> GetPostById(string postId)
        {
            if (!Guid.TryParse(postId, out Guid id))
            {
                return BadRequest("Invalid postId format");
            }
            var post = await _postService.FindPostById(id);

            if (post == null)
            {
                return NotFound(); 
            }

            return Ok(post);
        }

      

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var deleted = _postService.DeletePost(id);
            // if (!deleted)
            //    return NotFound();

            return NoContent();
        }


        [HttpGet]
        [Route("comments/{postId}")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> GetCommentsByPostIdAsync(string postId)
        {
            try
            {
              
                if (!Guid.TryParse(postId, out Guid id))
                {
                    return BadRequest("Invalid postId format"); // 400 Bad Request
                }
                var comments = await _postService.GetCommentsByPostId(id);

                return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [EnableCors("AllowAll")]
        [HttpPost("newcomment")]

        public async Task<IActionResult> CreateComment([FromBody] CommentDto comm)
        {
            string userIdClaimValue = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdClaimValue, out Guid userId))
            {
                if (!Guid.TryParse(comm.PostId, out Guid id))
                {
                    return BadRequest("Invalid postId format"); 
                }
                var newComment = new Comment
                { 
                    Content = comm.Content,
                    PostId =id,
                    UserId = userId 
                };
               
                var createdComm = await _postService.CreateComm(newComment);
                return CreatedAtAction(nameof(GetPostById), new { id = createdComm.Id }, createdComm);


            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}

