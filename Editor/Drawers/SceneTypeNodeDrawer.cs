namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SceneTypeNodeDrawer : GenericNodeDrawer<SceneTypeNode,SceneTypeNodeViewModel> {
        
        public SceneTypeNodeDrawer(SceneTypeNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
