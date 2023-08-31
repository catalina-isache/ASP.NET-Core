using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Proiect.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

using DAL.Models.DTO;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }                                                           
    [HttpGet("user")]
    [EnableCors("AllowAll")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }
    [HttpGet("is-admin")]
    [EnableCors("AllowAll")]
    public async Task<IActionResult> IsAdmin()
    {
        
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null)
        {
            return BadRequest("User ID claim not found in token.");
        }

        var userId = Guid.Parse(userIdClaim.Value); // Get the user's ID from the token
        int x = await _userService.UserRole(userId); // Fetch the user's role from the database

        bool isAdmin = (x == 0);
        return Ok(isAdmin);
    }


    [HttpPost("create-user")]
    [EnableCors("AllowAll")]
    public async Task<IActionResult> CreateUser(UserAuthRequestDto user)
    {
        await _userService.Create(user);
        return Ok();
    }

    [HttpPost("login-user")]
    [EnableCors("AllowAll")]
    public IActionResult LoginUser(UserAuthRequestDto user)
    {
        var response = _userService.Authenticate(user);
        if (response == null)
        {
            return BadRequest("Username or password is invalid!");
        }
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null)
        {
            Console.WriteLine("here");
        }

        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("create-post")]
    public async Task<IActionResult> CreatePost(Post post)
    {
        // your logic to create post
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete-post/{postId}")]
    public async Task<IActionResult> DeletePost(Guid postId)
    {
        // your logic to delete post
        return Ok();
    }

    [Authorize(Roles = "User, Admin")]
    [HttpPost("create-comment")]
    public async Task<IActionResult> CreateComment(Comment comment)
    {
        // your logic to create comment
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete-comment/{commentId}")]
    public async Task<IActionResult> DeleteComment(Guid commentId)
    {
        // your logic to delete comment
        return Ok();
    }
}