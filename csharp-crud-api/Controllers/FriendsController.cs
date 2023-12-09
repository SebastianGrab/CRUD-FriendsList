using Data;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace csharp_crud_api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class FriendsController : ControllerBase
{
  private readonly FriendContext _context;

  public FriendsController(FriendContext context)
  {
    _context = context;
  }

  // GET: api/friends
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Friend>>> GetFriends()
  {
    return await _context.Friends.ToListAsync();
  }

  // GET: api/friends/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Friend>> GetFriend(int id)
  {
    var friend = await _context.Friends.FindAsync(id);

    if (friend == null)
    {
      return NotFound();
    }

    return friend;
  }

  // POST: api/friends
  [HttpPost]
  public async Task<ActionResult<Friend>> PostFriend(Friend friend)
  {
    _context.Friends.Add(friend);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetFriend), new { id = friend.Id }, friend);
  }

  // PUT: api/friends/5
  [HttpPut("{id}")]
  public async Task<IActionResult> PutFriend(int id, Friend friend)
  {
    if (id != friend.Id)
    {
      return BadRequest();
    }

    _context.Entry(friend).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!FriendExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }

    return NoContent();
  }

  // DELETE: api/friends/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteFriend(int id)
  {
    var friend = await _context.Friends.FindAsync(id);
    if (friend == null)
    {
      return NotFound();
    }

    _context.Friends.Remove(friend);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool FriendExists(int id)
  {
    return _context.Friends.Any(e => e.Id == id);
  }

  // dummy method to test the connection
  [HttpGet("hello")]
  public string Test()
  {
    return "Hello World!";
  }
}
