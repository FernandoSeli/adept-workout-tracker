﻿using Adept.Data.Model;
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
        public DbSet<WorkoutLogSet> LogExerciseSets { get; set; } = default!;
        public DbSet<WorkoutLogExercise> LogExercises { get; set; } = default!;
        public DbSet<WorkoutTemplateSet> TemplateExerciseSets { get; set; } = default!;
        public DbSet<WorkoutTemplateExercise> TemplateExercises { get; set; } = default!;
        public DbSet<CurrentRoutine> CurrentRoutine { get; set; } = default!;

        public AdeptDatabaseContext(DbContextOptions<AdeptDatabaseContext> options)
            : base(options)
        {
            base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}