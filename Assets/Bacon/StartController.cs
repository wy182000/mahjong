﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maria;
using UnityEngine;

namespace Bacon {
    class StartController : Controller {
        private StartActor _startActor = null;

        public StartController(Context ctx) : base(ctx) {
            _startActor = new StartActor(ctx, this);
        }

        public override void OnEnter() {
            base.OnEnter();
            // 一般是加载场景在这里
        }

        public override void OnExit() {
            base.OnExit();
        }
    }
}
