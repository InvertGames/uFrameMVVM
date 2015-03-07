namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    using UnityEngine;
    
    
    public class GameView : GameViewBase {
        
        protected override Vector3 CalculatePosition() {
            base.CalculatePosition();
            return default(Vector3);
        }
        
        protected override void InitializeViewModel(ViewModel model) {
            base.InitializeViewModel(model);
        }
        
        public override void Bind() {
            base.Bind();
        }
    }
}
