using Invert.Core;

namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ViewNode : ViewNodeBase, IViewComponentConnectable, IClassRefactorable {
        public override IEnumerable<IItem> PossibleBindings
        {
            get
            {
                //yield break;
                foreach (var item in Element.BindableProperties)
                {
                    foreach (var mapping in uFrameMVVM.BindingTypes)
                    {
                        
                        var bindableType = mapping.Instance as uFrameBindingType;
                        if (bindableType == null) continue;
                        if (!bindableType.CanBind(item)) continue;
                        if (
                            Bindings.FirstOrDefault(p => p.BindingName == mapping.Name
                                && p.BindingType == bindableType && p.SourceIdentifier == item.Identifier) != null)
                            continue;

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
                        Graph.AddConnection(node, this.ElementInputSlot);
                    }

                });
            }
        }

        public ElementNode Element
        {
            get
            {

                var elementNode = ElementInputSlot.InputFrom<ElementNode>();
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
                return ScenePropertiesInputSlot.InputsFrom<PropertiesChildItem>().Distinct();
            }
        }

        public IEnumerable<string> ClassNameFormats
        {
            get
            {
                yield return "{0}";
                yield return "{0}Base";
            }
        }
    }
    
    public partial interface IViewConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
