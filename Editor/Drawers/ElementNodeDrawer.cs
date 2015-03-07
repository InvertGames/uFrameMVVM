namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ElementNodeDrawer : GenericNodeDrawer<ElementNode,ElementNodeViewModel> {
        
        public ElementNodeDrawer(ElementNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
