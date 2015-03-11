namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class WellnessSurveyScreenViewModel : WellnessSurveyScreenViewModelBase {
        
        public WellnessSurveyScreenViewModel(WellnessSurveyScreenControllerBase controller, bool initialize = true) : 
                base(controller, initialize) {
        }
        
        public override void Bind() {
            base.Bind();
        }
    }
}
