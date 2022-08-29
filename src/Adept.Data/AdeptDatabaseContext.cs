using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data
{
    public class AdeptDatabaseContext : DbContext
    {

        public DbSet<Exercise> Exercises { get; set; } = default!;
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; } = default!;
        public DbSet<Routine> Routines { get; set; } = default!;
        public DbSet<WorkoutLog> WorkoutLogs { get; set; } = default!;
        public DbSet<WorkoutTemplate> WorkoutTemplates { get; set; } = default!;
        public DbSet<WorkoutLogSet> LogSets { get; set; } = default!;
        public DbSet<WorkoutLogExerciseSet> LogExerciseSets { get; set; } = default!;
        public DbSet<WorkoutLogExercise> LogExercises { get; set; } = default!;

        public DbSet<WorkoutLogMultiExerciseSet> LogMultiExercises { get; set; } = default!;
        public DbSet<WorkoutTemplateSet> TemplateSets { get; set; } = default!;
        public DbSet<WorkoutTemplateExerciseSet> TemplateExerciseSets { get; set; } = default!;
        public DbSet<WorkoutTemplateExercise> TemplateExercises { get; set; } = default!;
        public DbSet<WorkoutTemplateMultiExercise> TemplateMultiExercises { get; set; } = default!;
        public DbSet<WorkoutTemplateMultiExerciseSet> TemplateMultiExerciseSets { get; set; } = default!;
        public DbSet<WorkoutTemplateSingleExercise> TemplateSingleExercises { get; set; } = default!;
        public DbSet<Setting> Settings { get; set; } = default!;
        public DbSet<CurrentRoutine> CurrentRoutine { get; set; } = default!;

        public AdeptDatabaseContext(DbContextOptions<AdeptDatabaseContext> options)
            : base(options)
        {
            base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkoutTemplateExercise>()
                    .HasDiscriminator(b => b.IsMultiExercise)
                    .HasValue<WorkoutTemplateSingleExercise>(false)
                    .HasValue<WorkoutTemplateMultiExercise>(true);
            modelBuilder.Entity<WorkoutTemplateMultiExercise>()
                .HasOne(p => p.WorkoutTemplate)
                .WithMany(x =>x.WorkoutTemplateMultiExercises)
                .HasForeignKey(p => p.WorkoutTemplateId);
            modelBuilder.Entity<WorkoutTemplateSingleExercise>()
                .HasOne(p => p.WorkoutTemplate)
                .WithMany(x => x.WorkoutTemplateSingleExercises)
                .HasForeignKey(p => p.WorkoutTemplateId);
        }
    }
}