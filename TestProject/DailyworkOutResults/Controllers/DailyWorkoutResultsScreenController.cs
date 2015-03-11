namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class DailyWorkoutResultsScreenController : DailyWorkoutResultsScreenControllerBase {
        
        public override void InitializeDailyWorkoutResultsScreen(DailyWorkoutResultsScreenViewModel viewModel) {
            base.InitializeDailyWorkoutResultsScreen(viewModel);
        }

        public override void Register(DailyWorkoutResultsScreenViewModel viewModel)
        {
            base.Register(viewModel);
            viewModel.FirstName = "BLABLABLABLA";
        }
    }
}
