namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ElementNode : ElementNodeBase, IViewConnectable, IInstancesConnectable {
        
        public override void Validate(List<ErrorInfo> errors)
        {
            base.Validate(errors);
            var ps = ChildItemsWithInherited.ToArray();
            foreach (var p1 in ps)
            {
                foreach (var p2 in ps)
                {
                    if (p1.Name == p2.Name && p1 != p2)
                    {
                        errors.AddError(string.Format("Duplicate \"{0}\"", p1.Name), this.Identifier);
                    }
                }
            }

        }

        public virtual System.Collections.Generic.IEnumerable<ComputedPropertyNode> ComputedProperties
        {
            get
            {
                return this.ChildItems.OfType<PropertiesChildItem>()
                    .SelectMany(p => p.OutputsTo<ComputedPropertyNode>())
                    .Distinct();
            }
        }
        public IEnumerable<ITypedItem> AllProperties
        {
            get
            {
                foreach (var item in ComputedProperties)
                    yield return item;
                foreach (var item in Properties)
                    yield return item;
            }
        }
        public IEnumerable<ITypedItem> AllPropertiesWithInherited
        {
            get
            {
                var baseElement = BaseNode as ElementNode;
                if (baseElement != null)
                {
                    foreach (var property in baseElement.AllProperties)
                    {
                        yield return property;
                    }
                    foreach (var property in baseElement.AllPropertiesWithInherited)
                    {
                        yield return property;
                    }
                }
            }
        }

        //[Invert.Core.GraphDesigner.ProxySection("Properties", SectionVisibility.Always, OrderIndex = 1)]
        public virtual System.Collections.Generic.IEnumerable<PropertiesChildItem> InheritedProperties
        {
            get
            {
                var baseElement = BaseNode as ElementNode;
                if (baseElement != null)
                {
                    foreach (var property in baseElement.InheritedProperties)
                    {
                        yield return property;
                    }
                }
                else
                {

                }
                foreach (var item in Properties)
                {
                    yield return item;
                }
            }
        }

        //[Invert.Core.GraphDesigner.ProxySection("Collections", SectionVisibility.Always, OrderIndex = 2)]
        public virtual System.Collections.Generic.IEnumerable<CollectionsChildItem> InheritedCollections
        {
            get
            {
                var baseElement = BaseNode as ElementNode;
                if (baseElement != null)
                {
                    foreach (var property in baseElement.InheritedCollections)
                    {
                        yield return property;
                    }
                }
                foreach (var item in Collections)
                {
                    yield return item;
                }
            }
        }
        //[Invert.Core.GraphDesigner.ProxySection("Commands", SectionVisibility.Always, OrderIndex = 3)]
        public virtual System.Collections.Generic.IEnumerable<CommandsChildItem> InheritedCommands
        {
            get
            {
                var baseElement = BaseNode as ElementNode;
                if (baseElement != null)
                {

                    foreach (var property in baseElement.InheritedCommands)
                    {
                        yield return property;
                    }
                }
                foreach (var item in Commands)
                {
                    yield return item;
                }
            }
        }

        public override string ClassName
        {
            get { return this.Name + "ViewModel"; }
        }
    }
    
    public partial interface IElementConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
