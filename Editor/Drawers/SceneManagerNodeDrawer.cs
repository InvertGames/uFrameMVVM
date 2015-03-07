namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SceneManagerNodeDrawer : GenericNodeDrawer<SceneManagerNode,SceneManagerNodeViewModel> {
        
        public SceneManagerNodeDrawer(SceneManagerNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
