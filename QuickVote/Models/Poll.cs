using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace QuickVote.Models;
public class Poll
{
    [Key]
    public string? PollID { get; set; }
    public string? Question { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }
}