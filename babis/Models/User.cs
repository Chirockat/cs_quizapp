namespace babis.Models;

public enum Gender
{
    Male,
    Female,
    Other,
    DontWannaShare
}


public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Gender Gender { get; set; } 
}
