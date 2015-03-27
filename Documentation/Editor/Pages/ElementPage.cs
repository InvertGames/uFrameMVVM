namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class ElementPage : ElementPageBase {
        
        public override void GetContent(Invert.Core.GraphDesigner.IDocumentationBuilder builder) {
            base.GetContent(builder);
            builder.Title2("What is it?");
            builder.Paragraph("ViewModels are the theoretical objects in your game.  " +
                              "They consist of data in the form of properties and collections, " +
                              "and also define the available commands for that object.  Because " +
                              "they are regular C# classes and do not inherit from Monobehaviour, " +
                              "ViewModels are very portable.  Although they do not require a View " +
                              "in order to exist, if you would like to represent a ViewModel's data " +
                              "in Unity, you would create a View and bind it to that ViewModel.");

            builder.Title2("Where does it exist in Unity?");
            builder.Paragraph("ViewModels don't technically exist until runtime, at which point they are " +
                              "instantiated into memory as needed.  If a View exists in your scene, at runtime " +
                              "it asks the SceneManager for the specific ViewModel it wants to bind to, at which " +
                              "point the SceneManager will return the ViewModel with the matching given identifier," +
                              " creating it if it doesn't exist.  When defining single instances of a particular " +
                              "ViewModel through the uFrame Editor window on a subsystem, these instances are also " +
                              "created at runtime and will be readily available in the SceneManager's Dependency " +
                              "Container for any Views requesting them.");

        }
    }

    public class ViewElementPage : ViewElementPageBase
    {
        
        public override void GetContent(Invert.Core.GraphDesigner.IDocumentationBuilder builder) {
            base.GetContent(builder);
        }
    }
}
