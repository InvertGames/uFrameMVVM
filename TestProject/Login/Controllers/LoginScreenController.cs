namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class LoginScreenController : LoginScreenControllerBase {
        [Inject]
        public LoginFlow LoginNavigator { get; set; }

        public override void InitializeLoginScreen(LoginScreenViewModel viewModel) {
            base.InitializeLoginScreen(viewModel);
        }
        
        public override void Login(LoginScreenViewModel viewModel) {
            base.Login(viewModel);

            LoginNavigator.Transition("MiniCamp");
           // viewModel.ErrorMessage = viewModel.Username + " was not correct.";

        }
    }
}
