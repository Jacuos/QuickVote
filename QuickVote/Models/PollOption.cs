using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace QuickVote.Models;

public class PollOption
{

    [Key]
    public int OptionID { get; set; }
    public string? PollID { get; set; }
    public string? Description { get; set; }
}