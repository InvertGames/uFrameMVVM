namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    
    
    public class AwesomeService : AwesomeServiceBase {
        
        public override void Setup() {
            base.Setup();
            UnityEngine.Debug.Log("Setup invoked");
            this.OnEvent<object>()
                .Subscribe(_ => UnityEngine.Debug.Log(string.Format("{0} Event was published.", _.GetType().Name)));
        }
        
        public override void NewSimpleClassNodeHandler(NewSimpleClassNode data) {
            base.NewSimpleClassNodeHandler(data);
        }
        
        public override void LoginHandler(LoginCommand data) {
            base.LoginHandler(data);
            UnityEngine.Debug.Log("Login Command invoked");
        }
    }
}
