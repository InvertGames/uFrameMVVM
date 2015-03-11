namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;


    public class PropertiesChildItem : PropertiesChildItemBase, ISubPropertiesConnectable
    {
        public override string DefaultTypeName
        {
            get { return typeof(string).Name; }
        }
    }
    
    public partial interface IPropertiesConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
