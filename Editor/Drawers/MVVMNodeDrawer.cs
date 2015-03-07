namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class MVVMNodeDrawer : GenericNodeDrawer<MVVMNode,MVVMNodeViewModel> {
        
        public MVVMNodeDrawer(MVVMNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
