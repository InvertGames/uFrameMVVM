namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class StateNodeViewModel : StateNodeViewModelBase {
        
        public StateNodeViewModel(StateNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }   public bool IsCurrentState { get; set; }
    }
}
