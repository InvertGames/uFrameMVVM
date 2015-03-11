namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    
    
    public class HeadTrainerScene : HeadTrainerSceneBase {
        public override void Setup()
        {
            Container.RegisterInstance(HeadTrainer.LoginFlowProperty);
            base.Setup();
            

        }
    }
}
