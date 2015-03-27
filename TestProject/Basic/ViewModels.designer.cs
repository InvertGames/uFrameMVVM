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
    using UnityEngine;
    using UniRx;
    
    
    public partial class HeadTrainerViewModelBase : ViewModel {
        
        private P<String> _FirstNameProperty;
        
        private P<String> _LastNameProperty;
        
        private Signal<LoginCommand> _Login;
        
        private Signal<fdsaCommand> _fdsa;
        
        public HeadTrainerViewModelBase(IEventAggregator aggregator) : 
                base(aggregator) {
        }
        
        public virtual P<String> FirstNameProperty {
            get {
                return _FirstNameProperty;
            }
            set {
                _FirstNameProperty = value;
            }
        }
        
        public virtual P<String> LastNameProperty {
            get {
                return _LastNameProperty;
            }
            set {
                _LastNameProperty = value;
            }
        }
        
        public virtual String FirstName {
            get {
                return FirstNameProperty.Value;
            }
            set {
                FirstNameProperty.Value = value;
            }
        }
        
        public virtual String LastName {
            get {
                return LastNameProperty.Value;
            }
            set {
                LastNameProperty.Value = value;
            }
        }
        
        public virtual Signal<LoginCommand> Login {
            get {
                return _Login;
            }
            set {
                _Login = value;
            }
        }
        
        public virtual Signal<fdsaCommand> fdsa {
            get {
                return _fdsa;
            }
            set {
                _fdsa = value;
            }
        }
        
        public override void Bind() {
            base.Bind();
            this.Login = new Signal<LoginCommand>(this, this.Aggregator);
            this.fdsa = new Signal<fdsaCommand>(this, this.Aggregator);
            _FirstNameProperty = new P<String>(this, "FirstName");
            _LastNameProperty = new P<String>(this, "LastName");
        }
        
        public override void Read(ISerializerStream stream) {
            base.Read(stream);
        }
        
        public override void Write(ISerializerStream stream) {
            base.Write(stream);
        }
        
        protected override void FillCommands(System.Collections.Generic.List<ViewModelCommandInfo> list) {
            base.FillCommands(list);
            list.Add(new ViewModelCommandInfo("Login", Login) { ParameterType = typeof(LoginCommand) });
            list.Add(new ViewModelCommandInfo("fdsa", fdsa) { ParameterType = typeof(Single) });
        }
        
        protected override void FillProperties(System.Collections.Generic.List<ViewModelPropertyInfo> list) {
            base.FillProperties(list);
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_FirstNameProperty, false, false, false, false));
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_LastNameProperty, false, false, false, false));
        }
    }
    
    public partial class HeadTrainerViewModel {
        
        public HeadTrainerViewModel(IEventAggregator aggregator) : 
                base(aggregator) {
        }
    }
    
    public partial class GameContextViewModelBase : ViewModel {
        
        private P<String> _FirstNameProperty;
        
        private Signal<ChangeNameCommand> _ChangeName;
        
        public GameContextViewModelBase(IEventAggregator aggregator) : 
                base(aggregator) {
        }
        
        public virtual P<String> FirstNameProperty {
            get {
                return _FirstNameProperty;
            }
            set {
                _FirstNameProperty = value;
            }
        }
        
        public virtual String FirstName {
            get {
                return FirstNameProperty.Value;
            }
            set {
                FirstNameProperty.Value = value;
            }
        }
        
        public virtual Signal<ChangeNameCommand> ChangeName {
            get {
                return _ChangeName;
            }
            set {
                _ChangeName = value;
            }
        }
        
        public override void Bind() {
            base.Bind();
            this.ChangeName = new Signal<ChangeNameCommand>(this, this.Aggregator);
            _FirstNameProperty = new P<String>(this, "FirstName");
        }
        
        public override void Read(ISerializerStream stream) {
            base.Read(stream);
        }
        
        public override void Write(ISerializerStream stream) {
            base.Write(stream);
        }
        
        protected override void FillCommands(System.Collections.Generic.List<ViewModelCommandInfo> list) {
            base.FillCommands(list);
            list.Add(new ViewModelCommandInfo("ChangeName", ChangeName) { ParameterType = typeof(void) });
        }
        
        protected override void FillProperties(System.Collections.Generic.List<ViewModelPropertyInfo> list) {
            base.FillProperties(list);
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_FirstNameProperty, false, false, false, false));
        }
    }
    
    public partial class GameContextViewModel {
        
        public GameContextViewModel(IEventAggregator aggregator) : 
                base(aggregator) {
        }
    }
}
