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
        public static IIncludableQueryable<Routine, Exercise?> IncludeWorkoutTemplateTree(this DbSet<Routine> routines)
        {
            return routines
                .Include(r => r.WorkoutTemplates)
                    .ThenInclude(template => template.TemplateExerciseContainers)
                    .ThenInclude(templateExerciseContainer => templateExerciseContainer.TemplateMultiExercises)
                    .ThenInclude(multiExerciseSet => multiExerciseSet.MultiExerciseSets)
                    .ThenInclude(exerciseSet => exerciseSet.Exercise)
                .Include(r => r.WorkoutTemplates)
                    .ThenInclude(template => template.TemplateExerciseContainers)
                    .ThenInclude(templateExerciseContainer => templateExerciseContainer.TemplateSingleExercise)
                    .ThenInclude(TemplateSingleExercise => TemplateSingleExercise.TemplateSets)
                .Include(r => r.WorkoutTemplates)
                    .ThenInclude(template => template.TemplateExerciseContainers)
                    .ThenInclude(templateExerciseContainer => templateExerciseContainer.TemplateSingleExercise)
                    .ThenInclude(TemplateSingleExercise => TemplateSingleExercise.Exercise);


        }
        public static IIncludableQueryable<WorkoutTemplate, Exercise?> IncludeExerciseTree(this DbSet<WorkoutTemplate> workoutTemplates)
        {
            return workoutTemplates
                    .Include(template => template.TemplateExerciseContainers)
                        .ThenInclude(templateExerciseContainer => templateExerciseContainer.TemplateMultiExercises)
                        .ThenInclude(multiExerciseSet => multiExerciseSet.MultiExerciseSets)
                        .ThenInclude(exerciseSet => exerciseSet.Exercise)
                    .Include(template => template.TemplateExerciseContainers)
                        .ThenInclude(templateExerciseContainer => templateExerciseContainer.TemplateSingleExercise)
                        .ThenInclude(TemplateSingleExercise => TemplateSingleExercise.TemplateSets)
                    .Include(template => template.TemplateExerciseContainers)
                        .ThenInclude(templateExerciseContainer => templateExerciseContainer.TemplateSingleExercise)
                        .ThenInclude(TemplateSingleExercise => TemplateSingleExercise.Exercise); ;
        }
    }
}
