#if GLACIER_UNITY
using System.Collections.Generic;

namespace Glacier.Core.Events {
    public class EventChannelSO<T1, T2, T3, T4> : EventChannelBaseSO {

        private List<EventChannelListener<T1, T2, T3, T4>> _listenersT4 = new();

        public void AddListener(EventChannelListener<T1, T2, T3, T4> listener) => AddListener(listener, _listenersT4);
        public void RemoveListener(EventChannelListener<T1, T2, T3, T4> listener) => RemoveListener(listener, _listenersT4);

        public void Raise(T1 param1, T2 param2, T3 param3, T4 param4) {
            Raise(_listenersT4, (l) => l.OnEventRaised(param1, param2, param3, param4));
        }
    }
}
#endif
