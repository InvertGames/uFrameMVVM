using System.Diagnostics;
using Invert.StateMachine;

namespace Invert.MVVMTest {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    using Invert.MVVMTest;
    using UnityEngine;
    
    public class HeadTrainerView : HeadTrainerViewBase {
        public override void Bind() {
            base.Bind();
            this.BindProperty(HeadTrainer.CurrentScreenProperty, CurrentScreenChanged);
        }

        private void CurrentScreenChanged(ScreenViewModel obj)
        {
            if (obj == null) return;
            if (CurrentScreen != null)
            {
                Destroy(CurrentScreen.gameObject);
            }
            CurrentScreen = InstantiateView(obj);
            CurrentScreen.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }

        public ViewBase CurrentScreen { get; set; }

  
    }
}
