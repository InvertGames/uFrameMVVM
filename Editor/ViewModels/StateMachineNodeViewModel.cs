using Invert.Core.GraphDesigner;

namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class StateMachineNodeViewModel : StateMachineNodeViewModelBase {
        
        public StateMachineNodeViewModel(StateMachineNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }

        public override INodeStyleSchema StyleSchema
        {
            get { return MinimalisticStyleSchema; } 
        }
    }
}
