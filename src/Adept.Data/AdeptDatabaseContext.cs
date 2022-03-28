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
        public DbSet<WorkoutLogExerciseSet> LogExerciseSets { get; set; } = default!;
        public DbSet<WorkoutLogExercise> LogExercises { get; set; } = default!;
        public DbSet<WorkoutTemplateExerciseSet> TemplateExerciseSets { get; set; } = default!;
        public DbSet<WorkoutTemplateExercise> TemplateExercises { get; set; } = default!;

        public AdeptDatabaseContext(DbContextOptions<AdeptDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}