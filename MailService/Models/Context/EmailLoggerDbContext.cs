using Microsoft.EntityFrameworkCore;

namespace MailService.Models.Context
{
    public class EmailLoggerDbContext : DbContext
    {
        public EmailLoggerDbContext(DbContextOptions options) : base(options) { }
        internal DbSet<EmailInfo> EmailsInfo { get; set; }
        internal DbSet<Recipient> Recipients { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailInfo>().HasKey(u => u.Id);
            
            modelBuilder.Entity<Recipient>().HasKey(u => u.Id);

            modelBuilder.Entity<Recipient>()
                .HasOne(p => p.EmailInfo)
                .WithMany(t => t.Recipients)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<EmailInfo>()
                .HasMany(c => c.Recipients)
                .WithOne(e => e.EmailInfo);
        }
    }
}

