using System.IO;
using Invert.Core.GraphDesigner;
using UnityEditor;
using UnityEngine;

namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public abstract class uFrameMVVMPage : uFrameMVVMPageBase {
        
        public override void GetContent(Invert.Core.GraphDesigner.IDocumentationBuilder _) {
            base.GetContent(_);
        }
        public uFrameMVVMKernel EnsureScaffoldKernel(IDocumentationBuilder builder, IProjectRepository projectRepository, Action<IDocumentationBuilder> stepContent = null)
        {

            var project = projectRepository as DefaultProjectRepository;
            
            var path = AssetDatabase.GetAssetPath(project);
            var prefabName = project.Name + "Kernel.prefab";
            var prefabNameWithPath = path.Replace(project.name + ".asset", prefabName);
     
            
            var go = AssetDatabase.LoadAssetAtPath(prefabNameWithPath, typeof(GameObject)) as GameObject;
            var component = go == null ? null : go.GetComponent<uFrameMVVMKernel>();
            builder.ShowTutorialStep(new TutorialStep("Now create the we need to create the kernel.", () =>
            {

                if (component == null)
                {
                    return "The Kernel Prefab has not been created yet.  Please press 'Scaffold/Update Kernel'.";
                }
                return null;
            })
            {
                StepContent = stepContent
            });
            return component;
        }
        public TComponentType EnsureComponentInSceneStep<TComponentType>(IDocumentationBuilder builder, DiagramNode node, Action<IDocumentationBuilder> stepContent = null) where TComponentType : UnityEngine.Object
        {
            var view =
                UnityEngine.Object.FindObjectsOfType<TComponentType>()
                    .FirstOrDefault(p => p.GetType().FullName == node.FullName);

            builder.ShowTutorialStep(new TutorialStep(string.Format("Now we need to add the {0} to the scene.", typeof(TComponentType).Name), () =>
            {

                if (view == null)
                {
                    return string.Format("The {0} component has not been added to the scene. Create an empty game-object, and add the {0} Component to it.", node.Name);
                }
                return null;
            })
            {
                StepContent = stepContent
            });
            return view;
        }
        public TutorialStep CreateSceneCommand(SceneTypeNode node, Action<IDocumentationBuilder> stepContent = null)
        {
            return new TutorialStep("Now we need to create a scene from our scene manager.", () =>
            {
                if (!EditorApplication.currentScene.EndsWith(node.Name + ".unity"))
                {
                    return
                        "The scene hasn't been created yet.  Navigate to the scene manager, right-click on it, and select CreateScene.  If you have already created the scene, please open it now.";
                }
                return null;
            })
            {
                StepContent = stepContent
            };
        }

    }


}
