using Invert.Core;

namespace Invert.uFrame.MVVM
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;


    public class ElementNode : ElementNodeBase, IViewConnectable, IInstancesConnectable, IClassRefactorable
    {
        public IEnumerable<ElementNode> RelatedElements
        {
            get
            {
                return this.GetParentNodes()
                    .OfType<SubsystemNode>()
                    .SelectMany(p => p.GetContainingNodesInProject(p.Project))
                    .OfType<ElementNode>()
                    .Distinct();
            }
        }
        public override void Validate(List<ErrorInfo> errors)
        {
            base.Validate(errors);
            var ps = ChildItemsWithInherited.OfType<ITypedItem>().ToArray();
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
        public IEnumerable<InstancesReference> RegisteredInstances
        {
            get
            {
                return
                    Graph.AllGraphItems.OfType<InstancesReference>().Where(p => p.SourceIdentifier == this.Identifier);
            }
        }
        public override IEnumerable<IItem> PossibleHandlers
        {
            get { return this.Project.AllGraphItems.OfType<IClassTypeNode>().Where(p => !(p is CommandNode)).Cast<IItem>(); }
        }
        public IEnumerable<ITypedItem> AllProperties
        {
            get
            {
                foreach (var item in ComputedProperties)
                    yield return item;
                foreach (var item in LocalProperties)
                    yield return item;
            }
        }

        //public override IEnumerable<IHandlersConnectable> PossibleHandlers
        //{
        //    get { return base.PossibleHandlers; }
        //}

        public IEnumerable<ITypedItem> BindableProperties
        {
            get
            {
                foreach (var item in ComputedProperties)
                    yield return item;
                foreach (var item in LocalProperties)
                    yield return item;
                foreach (var item in LocalCollections)
                    yield return item;
                foreach (var item in LocalCommands)
                    yield return item;

                var baseElement = BaseNode as ElementNode;
                if (baseElement != null)
                {
                    foreach (var item in baseElement.BindableProperties)
                    {
                        yield return item;
                    }
                }
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

        [Invert.Core.GraphDesigner.Section("Properties", SectionVisibility.Always, OrderIndex = 0, IsNewRow = true)]
        public override System.Collections.Generic.IEnumerable<PropertiesChildItem> Properties
        {
            get
            {
                if (Graph.CurrentFilter == this)
                {
                    var baseElement = BaseNode as ElementNode;
                    if (baseElement != null)
                    {
                        foreach (var property in baseElement.Properties)
                        {
                            yield return property;
                        }
                    }
                    else
                    {

                    }
                }
                foreach (var item in LocalProperties)
                {
                    yield return item;
                }
            }
        }

        [Invert.Core.GraphDesigner.Section("Collections", SectionVisibility.Always, OrderIndex = 1, IsNewRow = true)]
        public override System.Collections.Generic.IEnumerable<CollectionsChildItem> Collections
        {
            get
            {
                if (Graph.CurrentFilter == this)
                {
                    var baseElement = BaseNode as ElementNode;
                    if (baseElement != null)
                    {
                        foreach (var property in baseElement.Collections)
                        {
                            yield return property;
                        }
                    }
                }
                foreach (var item in LocalCollections)
                {
                    yield return item;
                }
            }
        }
        [Invert.Core.GraphDesigner.Section("Commands", SectionVisibility.Always, OrderIndex = 3, IsNewRow = true)]
        public override System.Collections.Generic.IEnumerable<CommandsChildItem> Commands
        {
            get
            {
                if (Graph.CurrentFilter == this)
                {
                    var baseElement = BaseNode as ElementNode;
                    if (baseElement != null)
                    {

                        foreach (var property in baseElement.Commands)
                        {
                            yield return property;
                        }
                    }
                }
                foreach (var item in LocalCommands)
                {
                    yield return item;
                }
            }
        }

        public IEnumerable<ITypedItem> AllCommandHandlers
        {
            get
            {
                foreach (var item in LocalCommands)
                {
                    yield return item;
                }
                foreach (var item in Handlers.Where(p=>p.SourceItem is CommandsChildItem))
                {
                    yield return item.SourceItem as CommandsChildItem;
                }
            }
        }
        public IEnumerable<PropertiesChildItem> LocalProperties
        {
            get { return PersistedItems.OfType<PropertiesChildItem>(); }
        }
        public IEnumerable<CollectionsChildItem> LocalCollections
        {
            get { return PersistedItems.OfType<CollectionsChildItem>(); }
        }
        public IEnumerable<CommandsChildItem> LocalCommands
        {
            get { return PersistedItems.OfType<CommandsChildItem>(); }
        }
        public override string ClassName
        {
            get { return this.Name + "ViewModel"; }
        }
        public IEnumerable<string> ClassNameFormats
        {
            get
            {
                yield return "{0}ViewModel";
                yield return "{0}Controller";
            }
        }
    }

    public partial interface IElementConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable
    {
    }
}
