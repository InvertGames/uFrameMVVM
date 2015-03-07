using UnityEngine;

namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class StateNodeDrawer : GenericNodeDrawer<StateNode,StateNodeViewModel> {
        
        public StateNodeDrawer(StateNodeViewModel viewModel) : 
                base(viewModel) {
        }

        public override void Draw(IPlatformDrawer platform, float scale)
        {
            base.Draw(platform, scale);
            if (NodeViewModel.IsCurrentState)
            {

                var adjustedBounds = new Rect(Bounds.x - 9, Bounds.y + 1, Bounds.width + 19, Bounds.height + 9);
                platform.DrawStretchBox(adjustedBounds.Scale(Scale), CachedStyles.BoxHighlighter1, 20);

            }
        }
    }
}
