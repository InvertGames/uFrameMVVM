namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class MVVMGraph : MVVMGraphBase {

        public Type NewType(string newType)
        {
            return this.GetType().Assembly.GetType("Invert.uFrame.MVVM." + newType);
        }

        public bool IsType(string type, string name)
        {
            return type.StartsWith("Invert.uFrame.MVVM." + name) || type.StartsWith(name);
        }
        public override Type FindType(string t)
        {
            if (IsType(t, "SceneManagerNode"))
            {
                return NewType("SceneTypeNode");
            }
            return null;
        }
    }
}
