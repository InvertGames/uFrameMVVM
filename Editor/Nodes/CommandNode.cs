namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;

    public interface ICommandClassItem : IDiagramNodeItem
    {
        
    }
    public class CommandNode : CommandNodeBase, ICommandClassItem, IClassTypeNode
    {
        public override string ClassName
        {
            get { return Name + "Command"; }
        }
        
        public override void Validate(List<ErrorInfo> errors)
        {
            base.Validate(errors);
            if (this.ReferenceOf<CommandsChildItem>() == null)
            {
                errors.AddError("This node must be linked to a Element Command, if you want a generic command use a 'SimpleClass'.", Identifier);
            }
        }
    }
    
    public partial interface ICommandConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
