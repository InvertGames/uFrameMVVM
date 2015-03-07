namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class TestElementViewModel : TestElementViewModelBase {
        
        public TestElementViewModel(TestElementControllerBase controller, bool initialize = true) : 
                base(controller, initialize) {
        }
        
        public override void Bind() {
            base.Bind();
        }
    }
}
