namespace babis.Models;

public class Question
{
    public int Id { get; set; }
    public string QuestionContent { get; set; } = string.Empty;
    public List<string> Options { get; set; } = new();
    public int CorrectAnswer { get; set; }
    public required Category Category { get; set; }
}