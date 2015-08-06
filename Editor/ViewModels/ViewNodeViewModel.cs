using Invert.Core.GraphDesigner;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Invert.uFrame.MVVM {
    
    public class ViewNodeViewModel : ViewNodeViewModelBase {

        public ViewNodeViewModel(ViewNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }


        public override string IconName
        {
            get { return "ViewIcon"; }
        }

        public override Color IconTint
        {
            get { return HeaderColor + new Color(0.2f, 0.2f, 0.2f, -0.1f); }
        }

        public override INodeStyleSchema StyleSchema
        {
            get { return MinimalisticStyleSchema; }
        }
    }

}
