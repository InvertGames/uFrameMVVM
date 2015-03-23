// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    using UnityEngine;
    
    
    public class AwesomeServiceBase : UnityEngine.MonoBehaviour, ISystemService {
        
        private IEventAggregator _EventAggregator;
        
        [InjectAttribute()]
        public IEventAggregator EventAggregator {
            get {
                return _EventAggregator;
            }
            set {
                _EventAggregator = value;
            }
        }
        
        public virtual void Setup() {
            this.OnEvent<NewSimpleClassNode>().Subscribe(this.NewSimpleClassNodeHandler);
            this.OnEvent<LoginCommand>().Subscribe(this.LoginHandler);
        }
        
        public virtual void NewSimpleClassNodeHandler(NewSimpleClassNode data) {
        }
        
        public virtual void LoginHandler(LoginCommand data) {
        }

        public void Dispose()
        {
            
        }
    }
}