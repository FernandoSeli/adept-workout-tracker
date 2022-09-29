using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Data.Extension
{
    public static class DataExtension
    {
        public static IIncludableQueryable<Routine, Exercise> IncludeWorkoutTemplateTree(this DbSet<Routine> routines)
        {
            return routines
                .Include(r => r.WorkoutTemplates)
                    .ThenInclude(template => template.WorkoutTemplateMultiExercises)
                    .ThenInclude(templateExercise => templateExercise.MultiExerciseSets)
                    .ThenInclude(multiExerciseSet => multiExerciseSet.ExerciseSets)
                    .ThenInclude(exerciseSet => exerciseSet.Exercise)
                .Include(r => r.WorkoutTemplates)
                    .ThenInclude(template => template.WorkoutTemplateSingleExercises)
                        .ThenInclude(templateExercise => templateExercise.TemplateSets)
                .Include(r => r.WorkoutTemplates)
                    .ThenInclude(template => template.WorkoutTemplateSingleExercises)
                        .ThenInclude(templateExercise => templateExercise.Exercise);


        }
        public static IIncludableQueryable<WorkoutTemplate, Exercise> IncludeExerciseTree(this DbSet<WorkoutTemplate> workoutTemplates)
        {
            return workoutTemplates
                    .Include(template => template.WorkoutTemplateMultiExercises)
                        .ThenInclude(templateExercise => templateExercise.MultiExerciseSets)
                        .ThenInclude(multiExerciseSet => multiExerciseSet.ExerciseSets)
                        .ThenInclude(exerciseSet => exerciseSet.Exercise)
                    .Include(template => template.WorkoutTemplateSingleExercises)
                            .ThenInclude(templateExercise => templateExercise.TemplateSets)
                    .Include(template => template.WorkoutTemplateSingleExercises)
                            .ThenInclude(templateExercise => templateExercise.Exercise);
        }
    }
}
