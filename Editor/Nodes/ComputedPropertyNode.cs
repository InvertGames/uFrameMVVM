namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ComputedPropertyNode : ComputedPropertyNodeBase {

        private string _type;
        [JsonProperty, NodeProperty(InspectorType.TypeSelection)]
        public string Type
        {
            get { return string.IsNullOrEmpty(_type) ? typeof(bool).Name : _type; }
            set { _type = value; }
        }

        public override IEnumerable<ISubPropertiesConnectable> PossibleSubProperties
        {
            get { return InputProperties.Select(p => p.RelatedTypeNode).OfType<ElementNode>().SelectMany(p => p.AllProperties).Cast<ISubPropertiesConnectable>(); }
        }

        //public override IEnumerable<IComputedPropertyConnectable> PossibleProperties
        //{
        //    get
        //    {
        //        return InputProperties.Select(p => p.RelatedTypeNode).OfType<ElementNode>().SelectMany(p => p.AllProperties).Cast<IComputedSubProperties>();
        //    }
        //}

        public IEnumerable<PropertiesChildItem> InputProperties
        {
            get { return this.InputsFrom<PropertiesChildItem>(); }
        }



        public override string RelatedTypeName
        {
            get
            {
                var type = this.OutputTo<IClassTypeNode>();
                if (type != null)
                {
                    return type.ClassName;
                }
                return string.IsNullOrEmpty(Type) ? "bool" : Type;
            }
        }
    }
    
    public partial interface IComputedPropertyConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
