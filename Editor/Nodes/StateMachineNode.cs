namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class StateMachineNode : StateMachineNodeBase {
        public override void Validate(List<ErrorInfo> errors)
        {
            base.Validate(errors);
            if (Name.ToLower() == "startstate")
            {
                errors.AddError("StartState is reserved", Identifier, () =>
                {
                    Name = Graph.Name + "StartState";
                });
            }
            if (this.InputFrom<PropertiesChildItem>() == null)
            {
                errors.AddWarning(string.Format("StateMachine {0} is not used.", Name), this.Identifier);
            }
            if (StartStateOutputSlot == null) return;
            if (StartStateOutputSlot.OutputTo<StateNode>() == null)
            {
                errors.AddError("State Machine requires a start state.", this.Identifier);
            }
        }
        public IEnumerable<StateNode> States
        {
            get { return this.GetContainingNodes(Graph).OfType<StateNode>(); }
        }

    }
    
    public partial interface IStateMachineConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
