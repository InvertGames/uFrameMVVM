namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class CommandNodeDrawer : GenericNodeDrawer<CommandNode,CommandNodeViewModel> {
        
        public CommandNodeDrawer(CommandNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
