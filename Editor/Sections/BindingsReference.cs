

namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;


    public class BindingsReference : BindingsReferenceBase, IBindingsConnectable
    {
        public override bool AllowInputs
        {
            get { return false; }
        }

        private uFrameBindingType _bindingType;
          [JsonProperty]
        public string BindingName { get; set; }
          public override string Name
          {
              get { return Title; }
              set { base.Name = value; }
          }
        public uFrameBindingType BindingType
        {
            get
            {
                return
                    _bindingType ?? (_bindingType = uFrameMVVM.BindingTypes.Where(p => p.Name == BindingName).Select(p => p.Instance).FirstOrDefault() as uFrameBindingType);
            }
            set { _bindingType = value; }
        }
        public override string Title
        {
            get
            {
                if (SourceItem == null)
                {
                    return "Error: Bindable Not Found";
                }
                return string.Format(BindingType.DisplayFormat, SourceItem.Name);
            }
        }

        public override string Group
        {
            get { return string.Format(BindingType.DisplayFormat, "{Item}"); }
        }
    }
    
    public partial interface IBindingsConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
