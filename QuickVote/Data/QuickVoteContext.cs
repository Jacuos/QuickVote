using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickVote.Models;

namespace QuickVote.Data
{
    public class QuickVoteContext : DbContext
    {
        public QuickVoteContext (DbContextOptions<QuickVoteContext> options)
            : base(options)
        {
        }

        public DbSet<QuickVote.Models.Poll> Poll { get; set; } = default!;
    }
}
