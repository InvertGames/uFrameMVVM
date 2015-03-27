using UnityEngine;

namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    
    
    public class AwesomeService : AwesomeServiceBase {
        
        public override void Setup() {
            base.Setup();
        
            this.OnEvent<object>()
                .Subscribe(_ => UnityEngine.Debug.Log(string.Format("{0} Event was published.", _.GetType().Name)));
        }

   
    }

   
}
