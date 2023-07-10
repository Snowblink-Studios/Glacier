#if GLACIER_UNITY
using System.Collections.Generic;

namespace Glacier.Core.Events {
    public class EventChannelSO<T1> : EventChannelBaseSO {

        private List<EventChannelListener<T1>> _listenersT1 = new();

        public void AddListener(EventChannelListener<T1> listener) => AddListener(listener, _listenersT1);
        public void RemoveListener(EventChannelListener<T1> listener) => RemoveListener(listener, _listenersT1);

        public virtual void Raise(T1 param1) {
            Raise(_listenersT1, (l) => l.OnEventRaised(param1));
        }
    }
}
#endif
