#if GLACIER_UNITY
using UnityEngine;
using UnityEngine.Events;

namespace Glacier.Core.Events {
    public class EventChannelListener<T1> : MonoBehaviour {

        [SerializeField]
        private EventChannelSO<T1> eventChannel;
        [SerializeField]
        private UnityEvent<T1> onEventRaised = new();

        public virtual void OnEventRaised(T1 param1) => onEventRaised?.Invoke(param1);
        public void SetEventChannel(EventChannelSO<T1> eventChannel) => this.eventChannel = eventChannel;
        public void AddUnityEventListener(UnityAction<T1> listener) => onEventRaised.AddListener(listener);

        private void OnEnable() => eventChannel?.AddListener(this);
        private void OnDisable() => eventChannel?.RemoveListener(this);
    }
}
#endif
