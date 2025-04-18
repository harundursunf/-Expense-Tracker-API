using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryLimit> CategoryLimits { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Role (bir kullanıcı bir role ait)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // User - Expense (bir kullanıcı birçok harcama yapabilir)
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.User)
                .WithMany(u => u.Expenses)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Category - Expense (bir kategoriye birçok harcama bağlı olabilir)
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Expenses)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Category - User (bir kullanıcı kendi kategorilerini oluşturur)
            modelBuilder.Entity<Category>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Category - CategoryLimit (bir kategoriye ait birden fazla limit olabilir)
            modelBuilder.Entity<CategoryLimit>()
                .HasOne(cl => cl.Category)
                .WithMany(c => c.Limits)
                .HasForeignKey(cl => cl.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Property Konfigürasyonları (isteğe bağlı)
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CategoryLimit>()
                .Property(cl => cl.LimitAmount)
                .HasColumnType("decimal(18,2)");
        }

    }
}
