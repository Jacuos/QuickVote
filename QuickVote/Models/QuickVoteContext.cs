using Microsoft.EntityFrameworkCore;

namespace QuickVote.Models;

public class QuickVoteContext : DbContext
{
    public QuickVoteContext(DbContextOptions<QuickVoteContext> options)
        : base(options)
    {
    }

    public DbSet<Poll> Polls { get; set; } = null!;
    public DbSet<PollOption> PollOption { get; set; } = null!;
    public DbSet<Answer> Answers { get; set; } = null!;
}