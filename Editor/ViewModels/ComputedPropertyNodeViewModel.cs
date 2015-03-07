namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class ComputedPropertyNodeViewModel : ComputedPropertyNodeViewModelBase {
        
        public ComputedPropertyNodeViewModel(ComputedPropertyNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
}
