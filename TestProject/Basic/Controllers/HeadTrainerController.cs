using System.Diagnostics;
using Invert.StateMachine;
using UniRx;

namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class HeadTrainerController : HeadTrainerControllerBase {
        
        public override void InitializeHeadTrainer(HeadTrainerViewModel viewModel) {
            base.InitializeHeadTrainer(viewModel);

            viewModel.LoginFlowProperty.Subscribe(
                delegate(State _)
            {
                var name = _.GetType().Name.Replace("State", "Screen");
               
                var controller = GameManager.Container.Resolve<Controller>(string.Format("{0}Controller", name));
                if (controller != null)
                {
                   
                    var vm = controller.Create();
                    viewModel.CurrentScreen = vm as ScreenViewModel;
                }
            });
        }

        public override void BeginLogin(HeadTrainerViewModel viewModel)
        {
            base.BeginLogin(viewModel);
            viewModel.LoginFlowProperty.Transition("MiniCamp");
            
        }
        
    }
}
