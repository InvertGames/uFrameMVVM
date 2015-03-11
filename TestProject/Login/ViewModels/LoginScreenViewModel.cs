namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class LoginScreenViewModel : LoginScreenViewModelBase {

        public LoginScreenViewModel(LoginScreenControllerBase controller, bool initialize = true) : 
                base(controller, initialize) {
        }
        
        public override void Bind() {
            base.Bind();
            
        }
        
        public override string ComputeErrorMessage()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                return "This is not a valid form.";
            }
            return string.Empty;
        }
    }
}
