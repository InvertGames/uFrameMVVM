namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    
    
    public class GameViewModel : GameViewModelBase {
        
        private System.IDisposable _FullNameDisposable;
        
        public GameViewModel(GameControllerBase controller, bool initialize = true) : 
                base(controller, initialize) {
        }
        
        public override void Bind() {
            base.Bind();
        }
        
        public override String ComputeFullName() {
            base.ComputeFullName();
            return default(String);
        }
    }
}
