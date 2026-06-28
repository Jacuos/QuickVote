using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuickVote.Models;
using System.Linq;

[Route("[controller]")]
[ApiController]
public class AnswersController : ControllerBase
{
    private readonly QuickVoteContext _context;
    public AnswersController(QuickVoteContext context)
    {
        _context = context;
    }

    // GET: answers/5
    [HttpGet("{pollid}")]
    public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers(string? pollid)
    {
        /*var poll = await _context.Polls.FindAsync(pollid);

        if (poll == null)
        {
            return NotFound();
        }*/

        var answers = await _context.Answers.Where(a => a.PollID == pollid).ToArrayAsync();
        return answers;
    }

    // POST: answers
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<string>> PostAnswer(Answer answer)
    {
        var poll = await _context.Polls.FindAsync(answer.PollID);

        if (poll == null)
        {
            return NotFound();
        }

        _context.Answers.Add(answer);
        await _context.SaveChangesAsync();
        return answer.PollID;
    }
}
