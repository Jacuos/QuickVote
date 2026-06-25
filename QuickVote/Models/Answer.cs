using Microsoft.EntityFrameworkCore;

namespace QuickVote.Models;

[PrimaryKey(nameof(AnswerID))]
public class Answer{
    public int? AnswerID{get;set;}
    public int OptionID{get;set;}
    public string? VoterName{get;set;}
}