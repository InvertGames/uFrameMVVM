namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SceneProperties : ScenePropertiesBase {
        public override string Name
        {
            get { return "Scene Properties"; }
            set { base.Name = value; }
        }
    }
    
    public partial interface IScenePropertiesConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
