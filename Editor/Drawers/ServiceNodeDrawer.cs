namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ServiceNodeDrawer : GenericNodeDrawer<ServiceNode,ServiceNodeViewModel> {
        
        public ServiceNodeDrawer(ServiceNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
