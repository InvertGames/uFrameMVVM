namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ViewComponentNodeDrawer : GenericNodeDrawer<ViewComponentNode,ViewComponentNodeViewModel> {
        
        public ViewComponentNodeDrawer(ViewComponentNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
