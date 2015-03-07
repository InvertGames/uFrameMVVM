namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ViewNode : ViewNodeBase, IViewComponentConnectable {
        public override IEnumerable<IBindingsConnectable> PossibleBindings
        {
            get
            {
                //yield break;
                foreach (var item in Element.PersistedItems.OfType<IBindableTypedItem>())
                {
                    foreach (var mapping in uFrameMVVM.BindingTypes)
                    {
                        var bindableType = mapping.Instance as uFrameBindingType;
                        if (bindableType == null) continue;
                        if (!bindableType.CanBind(item)) continue;
                        if (
                            Bindings.FirstOrDefault(p => p.BindingName == mapping.Name && p.BindingType == bindableType) !=
                            null) continue;

                        yield return new BindingsReference()
                        {
                            Node = this, 
                            SourceIdentifier = item.Identifier,
                            BindingName = mapping.Name,
                            BindingType = bindableType,
                            Name = string.Format(bindableType.DisplayFormat, item.Name)
                        };

                    }
                }
            }
        }

        public override void Validate(List<ErrorInfo> errors)
        {
            base.Validate(errors);
            if (Element == null)
            {
                errors.AddError("This view must have an element.", this.Identifier, () =>
                {
                    var node = Project.NodeItems.OfType<IDiagramFilter>()
                        .FirstOrDefault(p => p.GetContainingNodes(this.Project).Contains(this)) as ElementNode;
                    if (node != null)
                    {
                        Graph.AddConnection(node, this);
                    }

                });
            }
        }

        public ElementNode Element
        {
            get
            {

                var elementNode = this.InputFrom<ElementNode>();
                if (elementNode == null)
                {
                    var baseView = BaseNode as ViewNode;
                    if (baseView != null)
                    {
                        return baseView.Element;
                    }

                }
                else
                {
                    return elementNode;
                }

                return null;
            }
        }

        public IEnumerable<PropertiesChildItem> SceneProperties
        {
            get
            {
                return ScenePropertiesInputSlot.InputsFrom<PropertiesChildItem>();
            }
        }

    }
    
    public partial interface IViewConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
