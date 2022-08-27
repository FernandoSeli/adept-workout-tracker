using Adept.Blazor.Shared.Dialogs;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Blazor.Helper
{
    public class DialogHelper
    {
        private IDialogService _dialogService;

        public DialogHelper(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public async Task<(Routine? Routine, bool Deleted)> OpenRoutineDialogAsync(Routine routine)
        {
            var parameters = new DialogParameters();
            parameters.Add("Routine", routine);
            var dialog = _dialogService.Show<RoutineDialog>("", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                return await dialog.GetReturnValueAsync<(Routine? Routine, bool Deleted)>();
            }
            return default;
        }
        public async Task<(WorkoutTemplate? WorkoutTemplate, bool Deleted)> OpenWorkoutTemplateDialogAsync(WorkoutTemplate workoutTemplate)
        {
            var parameters = new DialogParameters();
            parameters.Add("WorkoutTemplate", workoutTemplate);
            var dialog = _dialogService.Show<WorkoutTemplateDialog>("", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                return await dialog.GetReturnValueAsync<(WorkoutTemplate? Routine, bool Deleted)>();
            }
            return default;
        }
    }
}
