﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Maria {
    public class EventDispatcher {

        protected Context _ctx;
        protected Dictionary<string, EventListenerCustom> _custom;
        protected Dictionary<uint, EventListenerCmd> _cmd;

        public EventDispatcher(Context ctx) {
            _ctx = ctx;
            _custom = new Dictionary<string, EventListenerCustom>();
            _cmd = new Dictionary<uint, EventListenerCmd>();
        }

        public void AddCmdEventListener(EventListenerCmd listener) {
            uint cmd = listener.Cmd;
            _cmd[cmd] = listener;
        }

        public EventListenerCustom AddCustomEventListener(string eventName, EventListenerCustom.OnEventCustomHandler callback, object ud) {
            EventListenerCustom listener = null;
            if (_custom.ContainsKey(eventName)) {
                listener = _custom[eventName];
                if (listener == null) {
                    listener = new EventListenerCustom(eventName, callback);
                    _custom[eventName] = listener;
                }
            } else {
                listener = new EventListenerCustom(eventName, callback);
                _custom[eventName] = listener;
            }

            return listener;
        }

        public void DispatchCmdEvent(Command cmd) {
            try {
                if (_cmd.ContainsKey(cmd.Cmd)) {
                    EventListenerCmd listener = _cmd[cmd.Cmd];
                    if (listener.Enable) {
                        EventCmd e = new EventCmd(cmd.Cmd, cmd.Orgin, cmd.Msg);
                        listener.Handler(e);
                    }
                } else {
                    throw new KeyNotFoundException(string.Format("custom not contains {0}", cmd.Cmd));
                }
            } catch (Exception ex) {
                UnityEngine.Debug.LogException(ex);
            }
        }

        private void DispatchCustomEvent(string eventName, object ud) {
            try {
                if (_custom.ContainsKey(eventName)) {
                    EventListenerCustom listener = _custom[eventName];
                    if (listener.Enable) {
                        EventCustom e = new EventCustom(eventName, ud);
                        listener.Handler(e);
                    }
                } else {
                    throw new KeyNotFoundException(string.Format("custom not contains {0}", eventName));
                }
            } catch (Exception ex) {
                UnityEngine.Debug.LogException(ex);
            }
        }

        public void FireCustomEvent(string eventName, object ud) {
            DispatchCustomEvent(eventName, ud);
        }
    }
}