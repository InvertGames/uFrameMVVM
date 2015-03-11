namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class DailyWorkoutResultsScreenViewModel : DailyWorkoutResultsScreenViewModelBase {
        
        public DailyWorkoutResultsScreenViewModel(DailyWorkoutResultsScreenControllerBase controller, bool initialize = true) : 
                base(controller, initialize) {
        }
        
        public override void Bind() {
            base.Bind();
        }
    }
}
