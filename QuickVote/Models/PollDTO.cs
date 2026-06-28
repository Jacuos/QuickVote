using System.ComponentModel.DataAnnotations;

namespace QuickVote.Models
{
    public class PollDTO
    {
        public required Poll Poll { get; set; }
        public PollOption[]? Options { get; set; }
    }
}
