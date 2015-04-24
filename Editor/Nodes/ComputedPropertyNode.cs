using Invert.Core;

namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;


    public class ComputedPropertyNode : ComputedPropertyNodeBase, ITypedItem, IBindingsConnectable
    {
        public override bool AllowMultipleInputs
        {
            get { return true; }
        }

        private string _type;
        [JsonProperty]
        public string PropertyType
        {
            get { return string.IsNullOrEmpty(_type) ? typeof(bool).Name : _type; }
            set
            {
                TrackChange(new TypeChange(this,_type, value));
                _type = value;
            }
        }

        public override IEnumerable<IItem> PossibleSubProperties
        {
            get { return InputProperties.Select(p => p.RelatedTypeNode).OfType<ElementNode>().SelectMany(p => p.AllProperties).Cast<ISubPropertiesConnectable>().Cast<IItem>(); }
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

        public override string RelatedType
        {
            get { return PropertyType; }
            set { PropertyType= value; }
        }

        [NodeProperty(InspectorType.TypeSelection)]
        public string Type
        {
            get { return RelatedTypeName; }
            set { PropertyType = value; }
        }

        public override string RelatedTypeName
        {
            get
            {
                if (Graph!= null && Project != null)
                {
                    
                
                    var type = this.Project.AllGraphItems.OfType<IClassTypeNode>().FirstOrDefault(p=>p.Identifier == PropertyType) as IClassTypeNode;
                    if (type != null)
                    {
                        return type.ClassName;
                    }
                }
                return string.IsNullOrEmpty(PropertyType) ? typeof(Boolean).Name : PropertyType;
            }
            set { PropertyType = value; }
        }
    }
    
    public partial interface IComputedPropertyConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
