namespace babis.Models;

public class UserQuizResult
{
    public int Id { get; set; } 
    public required User user { get; set; }
    public required Category Category { get; set; }
    public int Score { get; set; }
    public DateTime Date { get; set; }
}