#if GLACIER_UNITY
using UnityEngine;
using UnityEngine.Events;

namespace Glacier.Core.Events {
    public class EventChannelListener : MonoBehaviour {

        [SerializeField]
        private EventChannelSO eventChannel;
        [SerializeField]
        private UnityEvent onEventRaised = new();

        public virtual void OnEventRaised() => onEventRaised?.Invoke();
        public void SetEventChannel(EventChannelSO eventChannel) => this.eventChannel = eventChannel;
        public void AddUnityEventListener(UnityAction listener) => onEventRaised.AddListener(listener);

        private void OnEnable() => eventChannel?.AddListener(this);
        private void OnDisable() => eventChannel?.RemoveListener(this);
    }
}
#endif
