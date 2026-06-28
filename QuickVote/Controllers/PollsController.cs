using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickVote.Models;

[Route("[controller]")]
[ApiController]
public class PollsController : ControllerBase
{
    private readonly QuickVoteContext _context;
    public PollsController(QuickVoteContext context)
    {
        _context = context;
    }

    // GET: api/Poll
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Poll>>> GetPoll()
    {
        return await _context.Polls.ToListAsync();
    }

    // GET: api/Poll/5
    [HttpGet("{pollid}")]
    public async Task<ActionResult<Poll>> GetPoll(string? pollid)
    {
        var poll = await _context.Polls.FindAsync(pollid);

        if (poll == null)
        {
            return NotFound();
        }

        return poll;
    }

    // PUT: api/Poll/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{pollid}")]
    public async Task<IActionResult> PutPoll(string? pollid, Poll poll)
    {
        if (pollid != poll.PollID)
        {
            return BadRequest();
        }

        _context.Entry(poll).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PollExists(pollid))
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

    // POST: api/Poll
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Poll>> PostPoll(PollDTO pollDTO)
    {
        var poll = new Poll
        {
            PollID = Guid.NewGuid().ToString(),
            Question = pollDTO.Question,
            EndDate = pollDTO.EndDate
        };
        var options = pollDTO.Options?.Select(o => new PollOption
        {
            PollID = poll.PollID,
            Description = o.Description
        }).ToArray();
        _context.Polls.Add(poll);
        if(options is not null)
            _context.PollOption.AddRange(options);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPoll", new { pollid = poll.PollID }, pollDTO);
    }

    // DELETE: api/Poll/5
    [HttpDelete("{pollid}")]
    public async Task<IActionResult> DeletePoll(string? pollid)
    {
        var poll = await _context.Polls.FindAsync(pollid);
        if (poll == null)
        {
            return NotFound();
        }

        _context.Polls.Remove(poll);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PollExists(string? pollid)
    {
        return _context.Polls.Any(e => e.PollID == pollid);
    }
}
