// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    using System.CodeDom;
    
    
    [TemplateClass(Location=TemplateLocation.DesignerFile, AutoInherit=true, ClassNameFormat="{0}Command")]
    public class CommandClassTemplateBase : IClassTemplate<CommandNode> {
        
        private Invert.Core.GraphDesigner.TemplateContext<CommandNode> _Ctx;
        
        public virtual string OutputPath {
            get {
                return "";
            }
        }
        
        public virtual bool CanGenerate {
            get {
                return true;
            }
        }
        
        public Invert.Core.GraphDesigner.TemplateContext<CommandNode> Ctx {
            get {
                return _Ctx;
            }
            set {
                _Ctx = value;
            }
        }
        
        public virtual void TemplateSetup() {
            if (Ctx.IsDesignerFile) {
                Ctx.CurrentDeclaration.BaseTypes.Clear();
                Ctx.CurrentDeclaration.BaseTypes.Add(new CodeTypeReference("ViewModelCommand"));
            }
        }
    }
}
