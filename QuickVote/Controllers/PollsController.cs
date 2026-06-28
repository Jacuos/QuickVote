using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuickVote.Models;
using System.Linq;

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
    public async Task<ActionResult<IEnumerable<PollDTO>>> GetPoll()
    {
        var polls = await _context.Polls.ToArrayAsync();
        var pollsDTOs = new PollDTO[polls.Length];
        for(int i=0;i<polls.Length;i++)
        {
            pollsDTOs[i] = new PollDTO { Poll = polls[i]};
            PollOption[] currentOptions = await _context.PollOption.Where(o => o.PollID == polls[i].PollID).ToArrayAsync();
            pollsDTOs[i].Options = currentOptions;
        }
        return pollsDTOs;
    }

    // GET: api/Poll/5
    [HttpGet("{pollid}")]
    public async Task<ActionResult<PollDTO>> GetPoll(string? pollid)
    {
        var poll = await _context.Polls.FindAsync(pollid);

        if (poll == null)
        {
            return NotFound();
        }

        var pollDTO = new PollDTO { Poll = poll};
        PollOption[] currentOptions = await _context.PollOption.Where(o=>o.PollID==poll.PollID).ToArrayAsync();
        pollDTO.Options = currentOptions;

        return pollDTO;
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
            Question = pollDTO.Poll.Question,
            EndDate = pollDTO.Poll.EndDate
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

        pollDTO.Poll.PollID = poll.PollID;
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

        var options = await _context.PollOption.Where(o => o.PollID == poll.PollID).ToArrayAsync();
        _context.PollOption.RemoveRange(options);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PollExists(string? pollid)
    {
        return _context.Polls.Any(e => e.PollID == pollid);
    }
}
