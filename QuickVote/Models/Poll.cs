using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace QuickVote.Models;

[PrimaryKey(nameof(ID))]
public class Poll
{
    [Required]
    public string? ID{get;set;}
    public string? Question{get;set;}
    public string[]? Options{get;set;}

    [DataType(DataType.DateTime)]
    public DateTime EndDate{get;set;}

    public int[]? CollectedAnswersIDs{get;set;}
}