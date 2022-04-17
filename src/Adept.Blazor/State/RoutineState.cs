using Adept.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Blazor.State
{
    public class RoutineState
    {

        public Routine SelectedRoutine { get; private set; }

        public event Action OnChange;

        public void SetSelectedRoutine(Routine routine)
        {
            SelectedRoutine = routine;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
