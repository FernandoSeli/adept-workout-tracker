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
        public static void AddOrUpdateWorkoutTemplate(this List<WorkoutTemplate> workoutTemplates,
            WorkoutTemplate newWorkoutTemplate)
        {
            if (newWorkoutTemplate != default)
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

        public static void AddOrUpdateRoutine(this List<Routine> routines,
            Routine newRoutine)
        {
            if (newRoutine != default)
            {
                var oldRoutine = routines.FirstOrDefault(x => x.Id == newRoutine.Id);
                if (oldRoutine != default)
                {
                    oldRoutine = newRoutine;
                }
                else
                {
                    routines.Add(newRoutine);
                }
            }
        }
    }
}
