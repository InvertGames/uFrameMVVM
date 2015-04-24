namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class CollectionsChildItem : CollectionsChildItemBase {
        public override bool CanOutputTo(IConnectable input)
        {
            if (this.OutputTo<IClassTypeNode>() != null)
            {
                return false;
            }
            return base.CanOutputTo(input);
        }
        public override bool AllowInputs
        {
            get { return false; }
        }

        public override string DefaultTypeName
        {
            get { return typeof(string).Name; }
        }
    }
    
    public partial interface ICollectionsConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
