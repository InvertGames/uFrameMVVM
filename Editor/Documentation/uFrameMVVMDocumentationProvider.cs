using System.IO;
using Invert.Core;
using UnityEditor;
using UnityEngine;

namespace Invert.uFrame.MVVM
{
    using System;
    using System.Linq;
    using Invert.Core.GraphDesigner;


    public class uFrameMVVMDocumentationProvider : uFrameMVVMDocumentationProviderBase
    {
        public override Type RootPageType
        {
            get { return typeof(uFrameMVVMPageBase); }
        }

        public override void GetPages(System.Collections.Generic.List<Invert.Core.GraphDesigner.DocumentationPage> rootPages)
        {
         
            base.GetPages(rootPages);
        }

    }
}
