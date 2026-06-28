using System.ComponentModel.DataAnnotations;

namespace QuickVote.Models
{
    public class PollDTO
    {
        public string? Question { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        public PollOption[]? Options { get; set; }
    }
}
