namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SubsystemNode : SubsystemNodeBase {

        public virtual IEnumerable<InstancesReference> AvailableInstances
        {
            get
            {
                foreach (var item in Instances)
                {
                    yield return item;
                }
                foreach (var item in ImportedSystems)
                {
                    foreach (var instance in item.Instances)
                    {
                        yield return instance;
                    }
                }

            }
        }

        public IEnumerable<SubsystemNode> ImportedSystems
        {
            get
            {
                foreach (var item in ImportInputSlot.Items.OfType<Export>().Select(p => p.Node).OfType<SubsystemNode>())
                {
                    yield return item;
                    foreach (var x in item.ImportedSystems)
                    {
                        yield return x;
                    }
                }
            }
        }

        public IEnumerable<SubsystemNode> ImportedSystemsWithThis
        {
            get
            {
                yield return this;
                foreach (var item in ImportInputSlot.Items.OfType<Export>().Select(p => p.Node).OfType<SubsystemNode>())
                {
                    yield return item;
                    foreach (var x in item.ImportedSystems)
                    {
                        yield return x;
                    }
                }
            }
        }

    }
    
    public partial interface ISubsystemConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
