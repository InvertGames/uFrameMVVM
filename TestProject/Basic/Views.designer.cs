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
    using UnityEngine;
    
    
    public class HeadTrainerViewBase : ViewBase {
        
        [UnityEngine.SerializeField()]
        [UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public String _FirstName;
        
        [UnityEngine.SerializeField()]
        [UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public String _LastName;
        
        [UFToggleGroup("FirstName")]
        [UnityEngine.HideInInspector()]
        public bool _BindFirstName = true;
        
        [UFGroup("FirstName")]
        [UnityEngine.SerializeField()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_FirstNameinput")]
        private UnityEngine.UI.InputField _FirstNameInput;
        
        [UFToggleGroup("Login")]
        [UnityEngine.HideInInspector()]
        public bool _BindLogin = true;
        
        [UFGroup("Login")]
        [UnityEngine.SerializeField()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_Loginbutton")]
        private UnityEngine.UI.Button _LoginButton;
        
        [UFToggleGroup("LastName")]
        [UnityEngine.HideInInspector()]
        public bool _BindLastName = true;
        
        [UFGroup("LastName")]
        [UnityEngine.SerializeField()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_LastNameinput")]
        private UnityEngine.UI.InputField _LastNameInput;
        
        public override string DefaultIdentifier {
            get {
                return "HeadTrainer";
            }
        }
        
        public override System.Type ViewModelType {
            get {
                return typeof(HeadTrainerViewModel);
            }
        }
        
        public HeadTrainerViewModel HeadTrainer {
            get {
                return (HeadTrainerViewModel)ViewModelObject;
            }
        }
        
        public override ViewModel CreateModel() {
            return this.RequestViewModel();
        }
        
        protected override void InitializeViewModel(ViewModel model) {
            base.InitializeViewModel(model);
            var headtrainerview = ((HeadTrainerViewModel)model);
            headtrainerview.FirstName = this._FirstName;
            headtrainerview.LastName = this._LastName;
        }
        
        public override void Bind() {
            base.Bind();
            if (_BindFirstName) {
                this.BindInputFieldToProperty(_FirstNameInput, this.HeadTrainer.FirstNameProperty);
            }
            if (_BindLogin) {
                this.BindButtonToCommand(_LoginButton, this.HeadTrainer.Login);
            }
            if (_BindLastName) {
                this.BindInputFieldToProperty(_LastNameInput, this.HeadTrainer.LastNameProperty);
            }
        }
        
        public virtual void ExecuteLogin(LoginCommand command) {
            command.Sender = HeadTrainer;
            HeadTrainer.Login.OnNext(command);
        }
        
        public virtual void Executefdsa(fdsaCommand command) {
            command.Sender = HeadTrainer;
            HeadTrainer.fdsa.OnNext(command);
        }
        
        public virtual void Executefdsa(Single arg) {
            HeadTrainer.fdsa.OnNext(new fdsaCommand() { Sender = HeadTrainer, Argument = arg });
        }
    }
}
