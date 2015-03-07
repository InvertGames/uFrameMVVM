namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SubsystemNodeDrawer : GenericNodeDrawer<SubsystemNode,SubsystemNodeViewModel> {
        
        public SubsystemNodeDrawer(SubsystemNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
