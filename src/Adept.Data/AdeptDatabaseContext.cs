using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data
{
    public class AdeptDatabaseContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; } = default!;

        public DbSet<Exercise> Exercises { get; set; } = default!;
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; } = default!;

        public DbSet<Routine> Routines { get; set; } = default!;
        public DbSet<CurrentRoutine> CurrentRoutine { get; set; } = default!;

        public DbSet<WorkoutLog> WorkoutLogs { get; set; } = default!;
        public DbSet<LogExerciseContainer> LogExerciseContainers { get; set; } = default!;
        public DbSet<LogSingleExercise> LogSingleExercises { get; set; } = default!;
        public DbSet<LogSingleExerciseSet> LogSingleExerciseSet { get; set; } = default!;
        public DbSet<LogMultiExercise> LogMultiExercises { get; set; } = default!;
        public DbSet<LogMultiExerciseSet> LogMultiExerciseSets { get; set; } = default!;

        public DbSet<WorkoutTemplate> WorkoutTemplates { get; set; } = default!;
        public DbSet<TemplateExerciseContainer> TemplateExerciseContainers { get; set; } = default!;
        public DbSet<TemplateSingleExercise> TemplateSingleExercises { get; set; } = default!;
        public DbSet<TemplateSingleExerciseSet> TemplateSingleExerciseSet { get; set; } = default!;
        public DbSet<TemplateMultiExercise> TemplateMultiExercises { get; set; } = default!;
        public DbSet<TemplateMultiExerciseSet> TemplateMultiExerciseSets { get; set; } = default!;


        public AdeptDatabaseContext(DbContextOptions<AdeptDatabaseContext> options)
            : base(options)
        {
            base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<WorkoutTemplateExercise>()
            //    .HasDiscriminator(b => b.IsMultiExercise)
            //    .HasValue<WorkoutTemplateSingleExercise>(false)
            //    .HasValue<WorkoutTemplateMultiExercise>(true);
            //modelBuilder.Entity<WorkoutTemplateMultiExercise>()
            //    .HasOne(p => p.WorkoutTemplate)
            //    .WithMany(x =>x.WorkoutTemplateMultiExercises)
            //    .HasForeignKey(p => p.WorkoutTemplateId);
            //modelBuilder.Entity<WorkoutTemplateSingleExercise>()
            //    .HasOne(p => p.WorkoutTemplate)
            //    .WithMany(x => x.WorkoutTemplateSingleExercises)
            //    .HasForeignKey(p => p.WorkoutTemplateId);


            //modelBuilder.Entity<WorkoutLogExercise>()
            //    .HasDiscriminator(b => b.IsMultiExercise)
            //    .HasValue<WorkoutLogSingleExercise>(false)
            //    .HasValue<WorkoutLogMultiExercise>(true);
            //modelBuilder.Entity<WorkoutLogMultiExercise>()
            //    .HasOne(p => p.WorkoutLog)
            //    .WithMany(x => x.WorkoutLogMultiExercises)
            //    .HasForeignKey(p => p.WorkoutLogId);
            //modelBuilder.Entity<WorkoutLogSingleExercise>()
            //    .HasOne(p => p.WorkoutLog)
            //    .WithMany(x => x.WorkoutLogSingleExercises)
            //    .HasForeignKey(p => p.WorkoutLogId);
        }
    }
}