using Adept.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Data.Extension
{
    public static class ListExtension
    {
        public static void AddUpdateOrDeleteWorkoutTemplate(this List<WorkoutTemplate> workoutTemplates,
            WorkoutTemplate newWorkoutTemplate,
            bool deleted)
        {
            if (newWorkoutTemplate != default)
            {
                if (deleted)
                {
                    workoutTemplates.Remove(newWorkoutTemplate);
                }
                else
                {
                    var oldWorkoutTemplate = workoutTemplates.FirstOrDefault(x => x.Id == newWorkoutTemplate.Id);
                    if (oldWorkoutTemplate != default)
                    {
                        oldWorkoutTemplate = newWorkoutTemplate;
                    }
                    else
                    {
                        workoutTemplates.Add(newWorkoutTemplate);
                    }
                }
            }
        }

        public static void AddUpdateOrDeleteRoutine(this List<Routine> routines,
            Routine routine,
            bool deleted)
        {
            if (routine != default)
            {
                if (deleted)
                {
                    routines.Remove(routine);
                }
                else
                {
                    var oldRoutine = routines.FirstOrDefault(x => x.Id == routine.Id);
                    if (oldRoutine != default)
                    {
                        oldRoutine = routine;
                    }
                    else
                    {
                        routines.Add(routine);
                    }
                }
            }
        }
    }
}
