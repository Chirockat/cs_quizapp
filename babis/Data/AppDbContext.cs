using babis.Models;
using Microsoft.EntityFrameworkCore;

namespace babis.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<UserQuizResult> UserQuizResults { get; set; }

    //Ogarnianie Gender zeby sie wyswietlala jako string w bazie danych
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .Property(u => u.Gender)
            .HasConversion<string>();
    }
}
