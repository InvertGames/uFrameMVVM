namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class Element : ElementBase {
    

        public override string Name
        {
            get
            {
                var node = this.Node as ViewNode;
                
                if (node != null)
                {
                    var element = node.Element;
                    if (element != null)
                    {
                        return "Element: " + element.Name;
                    }
                    
                }
              
                return "Element";
            }
            set { base.Name = value; }
        }
    }
    
    public partial interface IElementConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
