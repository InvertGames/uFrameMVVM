namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class StateNode : StateNodeBase {
        public override bool AllowMultipleInputs
        {
            get { return true; }
        }

        public override void Validate(List<ErrorInfo> errors)
        {
            base.Validate(errors);
            foreach (var item in StateTransitions)
            {
                if (item.OutputTo<StateNode>() == null)
                {
                    errors.AddError("Transition is not connected to a state", item.Node);
                }
            }
        }
    }
    
    public partial interface IStateConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
