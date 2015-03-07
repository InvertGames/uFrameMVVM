namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SimpleClassNodeDrawer : GenericNodeDrawer<SimpleClassNode,SimpleClassNodeViewModel> {
        
        public SimpleClassNodeDrawer(SimpleClassNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
