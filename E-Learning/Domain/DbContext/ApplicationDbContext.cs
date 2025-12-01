using E_Learning.Domain.Comon;
using E_Learning.Domain.Entities;
using E_Learning.Helper.CustomAttributes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Infrastructure.Persistence;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    #region override func SaveChanges ef core
    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now;
                entry.Entity.CreatedBy = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
                entry.Entity.IsDeleted = false;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.Now;
                entry.Entity.UpdatedBy = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.Entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
        return base.SaveChanges();
    }
    #endregion

    #region DbSets
    public DbSet<Product> Products { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseListening> ExerciseListenings { get; set; }
    public DbSet<ExercisesReading> ExercisesReadings { get; set; }
    public DbSet<ExerciseSubmission> ExerciseSubmissions { get; set; }
    public DbSet<ExerciseSubmissionDetail> ExerciseSubmissionDetails { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.ClrType.GetProperties())
            {
                var maxLengthAttr = property.GetCustomAttributes(typeof(CustomMaxLengthAttribute), false)
                                            .FirstOrDefault() as CustomMaxLengthAttribute;
                if (maxLengthAttr != null)
                {
                    modelBuilder.Entity(entityType.ClrType)
                                .Property(property.Name)
                                .HasMaxLength(maxLengthAttr.Length);
                }

                if (property.GetCustomAttributes(typeof(CustomRequiredAttribute), false).Any())
                {
                    modelBuilder.Entity(entityType.ClrType)
                                .Property(property.Name)
                                .IsRequired();
                }
            }
        }

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(b => b.Description);
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.ToTable("Exercise");

            entity.Property(e => e.Skill)
                  .HasConversion<int>();
            entity.Property(e => e.AttemptCount)
                  .HasDefaultValue(0);
            entity.HasMany(e => e.ExerciseListenings)
                  .WithOne(el => el.Exercise)
                  .HasForeignKey(el => el.ExerciseId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.ExerciseReadings)
                 .WithOne(el => el.Exercise)
                 .HasForeignKey(el => el.ExerciseId)
                 .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ExerciseListening>(entity =>
        {
            entity.ToTable("ExerciseListening");

            entity.HasOne(e => e.Exercise)
                  .WithMany(e => e.ExerciseListenings)
                  .HasForeignKey(e => e.ExerciseId);
        });
        modelBuilder.Entity<ExercisesReading>(entity =>
        {
            entity.ToTable("ExercisesReading");
            entity.HasOne(e => e.Exercise)
                  .WithMany(e => e.ExerciseReadings)
                  .HasForeignKey(e => e.ExerciseId);
        });
        modelBuilder.Entity<ExerciseSubmission>(entity =>
        {
            entity.ToTable("ExerciseSubmission");
            entity.HasOne<Exercise>()
                  .WithMany()
                  .HasForeignKey(e => e.ExerciseId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ExerciseSubmissionDetail>(entity =>
        {
            entity.ToTable("ExerciseSubmissionDetail");
            entity.HasOne<ExerciseSubmission>()
                  .WithMany(s => s.Details)
                  .HasForeignKey(e => e.SubmissionId)
                  .OnDelete(DeleteBehavior.Cascade);
        });


    }
}