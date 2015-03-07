namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ViewNodeDrawer : GenericNodeDrawer<ViewNode,ViewNodeViewModel> {
        
        public ViewNodeDrawer(ViewNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
