using Invert.Core;

namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ServiceNode : ServiceNodeBase {
        public override bool AllowInputs
        {
            get { return false; }
        }

        public override bool AllowOutputs
        {
            get { return false; }
        }

        public override IEnumerable<IItem> PossibleHandlers
        {
            get { return this.Project.AllGraphItems.OfType<IClassTypeNode>().Where(p=>!(p is CommandNode)).Cast<IItem>(); }
        }


        public override void Document(IDocumentationBuilder docs)
        {
            base.Document(docs);
            
        }
    }
    
    public partial interface IServiceConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
