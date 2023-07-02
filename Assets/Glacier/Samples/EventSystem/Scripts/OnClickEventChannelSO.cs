#if GLACIER_UNITY
using UnityEngine;
using Glacier.Core.Events;

namespace Glacier.Samples.EventSystem {
    [CreateAssetMenu(menuName="Game/Events/OnClick", fileName="OnClick_EventChannelSO")]
    public class OnClickEventChannelSO : EventChannelSO<string> {
    }
}
#endif
