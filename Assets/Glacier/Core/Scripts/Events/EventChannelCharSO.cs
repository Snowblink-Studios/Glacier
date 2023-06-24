#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core.Events {
    [CreateAssetMenu(menuName="Glacier/Core/Events/EventChannel(Char)", fileName="Name_Char_EventChannel")]
    public class EventChannelCharSO : EventChannelSO<char> {
    }
}
#endif
