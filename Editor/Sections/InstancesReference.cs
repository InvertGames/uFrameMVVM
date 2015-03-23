namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class InstancesReference : InstancesReferenceBase {
        public override bool AllowInputs
        {
            get { return false; }
        }
        public override bool AllowOutputs
        {
            get { return false; }
        }
    }
    
    public partial interface IInstancesConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
