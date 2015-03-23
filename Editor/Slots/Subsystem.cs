namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class Subsystem : SubsystemBase {
        public override bool AllowMultipleInputs
        {
            get { return false; }
        }
        
    }
    
    public partial interface ISubsystemConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
