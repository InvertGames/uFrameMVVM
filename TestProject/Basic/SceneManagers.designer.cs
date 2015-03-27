// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    
    
    public class DemoSceneBase : SceneManager {
        
        private HeadTrainerViewModel _HeadTrainer;
        
        private HeadTrainerController _HeadTrainerController;
        
        public DemoSceneSettings _DemoSceneSettings = new DemoSceneSettings();
        [InjectAttribute("HeadTrainer")]
        public virtual HeadTrainerViewModel HeadTrainer {
            get {
                if (this._HeadTrainer == null) {
                    this._HeadTrainer = CreateInstanceViewModel<HeadTrainerViewModel>( "HeadTrainer");
                }
                return _HeadTrainer;
            }
            set {
            }
        }
        
        [InjectAttribute()]
        public virtual HeadTrainerController HeadTrainerController {
            get {
                if (_HeadTrainerController==null) {
                    _HeadTrainerController = Container.CreateInstance(typeof(HeadTrainerController)) as HeadTrainerController;;
                }
                return _HeadTrainerController;
            }
            set {
                _HeadTrainerController = value;
            }
        }
        
        public override void Setup() {
            Container.RegisterViewModel<HeadTrainerViewModel>(HeadTrainer, "HeadTrainer");
            Container.RegisterViewModelManager<HeadTrainerViewModel>(new ViewModelManager<HeadTrainerViewModel>());
            Container.RegisterController<HeadTrainerController>(HeadTrainerController);
            Container.InjectAll();
        }
        
        // This method is called right after setup is invoked.
        public override void Initialize() {
            base.Initialize();
            Publish(new ViewModelCreatedEvent() { ViewModel = HeadTrainer });;
        }
    }
    
    [System.SerializableAttribute()]
    public class DemoSceneSettingsBase : object {
        
        public string[] _Scenes;
    }
    
    public class MainSceneBase : SceneManager {
        
        private GameContextController _GameContextController;
        
        public MainSceneSettings _MainSceneSettings = new MainSceneSettings();
        [InjectAttribute()]
        public virtual GameContextController GameContextController {
            get {
                if (_GameContextController==null) {
                    _GameContextController = Container.CreateInstance(typeof(GameContextController)) as GameContextController;;
                }
                return _GameContextController;
            }
            set {
                _GameContextController = value;
            }
        }
        
        public override void Setup() {
            Container.RegisterViewModelManager<GameContextViewModel>(new ViewModelManager<GameContextViewModel>());
            Container.RegisterController<GameContextController>(GameContextController);
            Container.InjectAll();
        }
        
        // This method is called right after setup is invoked.
        public override void Initialize() {
            base.Initialize();
        }
    }
    
    [System.SerializableAttribute()]
    public class MainSceneSettingsBase : object {
        
        public string[] _Scenes;
    }
}
