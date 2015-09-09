namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ViewComponentNode : ViewComponentNodeBase {
        public ViewNode View
        {
            get { return this.InputFrom<ViewNode>(); }
        }

        public override void Validate(List<ErrorInfo> errors)
        {
            base.Validate(errors);
            if (View == null)
            {
                errors.AddError(string.Format("View must be connected to the {0} ViewComponent.",  this.Name), this);
            }
        }
    }
    
    public partial interface IViewComponentConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
