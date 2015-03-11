namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class HeadTrainerViewModel : HeadTrainerViewModelBase {
        
        public HeadTrainerViewModel(HeadTrainerControllerBase controller, bool initialize = true) : 
                base(controller, initialize) {
        }
        
        public override void Bind() {
            base.Bind();
            
        }
        
    }
}
