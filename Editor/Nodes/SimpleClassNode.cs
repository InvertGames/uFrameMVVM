namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SimpleClassNode : SimpleClassNodeBase,  IHandlersConnectable {
        public override string ClassName
        {
            get { return this.Name; }
        }
    }
    
    public partial interface ISimpleClassConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
