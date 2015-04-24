namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class HandlersReference : HandlersReferenceBase {
        public override bool AllowOutputs
        {
            get { return false; }
        }

        public override bool AllowInputs
        {
            get { return false; }
        }
    }
    
    public partial interface IHandlersConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
