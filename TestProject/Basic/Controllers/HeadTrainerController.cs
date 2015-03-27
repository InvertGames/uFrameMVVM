using System.Diagnostics;

namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;


    public class HeadTrainerController : HeadTrainerControllerBase {
        public override void Setup()
        {
            base.Setup();
           
        }

        public override void InitializeHeadTrainer(HeadTrainerViewModel viewModel) {
            base.InitializeHeadTrainer(viewModel);
            viewModel.FirstName = "BLABLABLABLA";
            UnityEngine.Debug.Log("YOYOYO");
            // This is called when a HeadTrainerViewModel is created
        }
        
        public override void Login(HeadTrainerViewModel viewModel, LoginCommand loginCommand) {
            base.Login(viewModel,loginCommand);
            viewModel.FirstName = "YUPYUPYUP";
        }
        
        public override void LoginHandler(LoginCommand command) {
            base.LoginHandler(command);
        }
    }
}
