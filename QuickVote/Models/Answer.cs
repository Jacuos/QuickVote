using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace QuickVote.Models;

public class Answer
{

    [Key]
    public int? AnswerID { get; set; }
    public string? PollID { get; set; }
    public int OptionID { get; set; }
    public string? VoterName { get; set; }
}