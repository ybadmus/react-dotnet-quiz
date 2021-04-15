using Microsoft.EntityFrameworkCore;

namespace React.NET.Entities
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options)
           : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PossibleAnswer> PossibleAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>().ToTable("Entry");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<PossibleAnswer>().ToTable("PossibleAnswer");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
