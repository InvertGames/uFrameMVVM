namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;


    public class CommandsChildItem : CommandsChildItemBase, ICommandClassItem, IClassTypeNode
    {
        [InspectorProperty]
        public bool Publish
        {
            get { return this["Publish"]; }
            set { this["Publish"] = value; }
        }

        public CommandNode OutputCommand
        {
            get
            {
                return this.RelatedTypeNode as CommandNode;
            }
        }

        public override bool AllowInputs
        {
            get { return false; }
        }

        public string ClassName
        {
            get { return this.Name + "Command"; }
        }
        public override string Name
        {
            get
            {
                var oc = OutputCommand;
                if (oc != null)
                {
                    return oc.Name;
                }
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }
        public override void BeginEditing()
        {
            if (OutputCommand != null)
            {
                IsEditing = false;
                return;
            }
            base.BeginEditing();
        }
        public override void Validate(List<ErrorInfo> info)
        {
            base.Validate(info);
            var otherCommand =
                Node.Repository.All<CommandsChildItem>()
                    .FirstOrDefault(p => p != this && p.Name == this.Name && p.OutputCommand == null);

            if (otherCommand != null)
            {
                info.AddError(string.Format("The command {0} is already being used on node {1}.", this.Name, otherCommand.Node.Name),this.Identifier,
                    () =>
                    {
                        Name = this.Node.Name + this.Name;
                    });
            }
        }
        public override bool CanOutputTo(IConnectable input)
        {
            if (this.OutputTo<IClassTypeNode>() != null)
            {
                return false;
            }
            if (input is HandlersReference) return false;
            return base.CanOutputTo(input);
        }
    }
    
    public partial interface ICommandsConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
