namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    
    
    public class GameContextController : GameContextControllerBase {
        
        public override void Setup() {
            base.Setup();
            // This is called when the controller is created
        }
        
        public override void InitializeGameContext(GameContextViewModel viewModel) {
            base.InitializeGameContext(viewModel);
            // This is called when a GameContextViewModel is created
        }
    }
}
