#if GLACIER_UNITY
using UnityEngine;
using TMPro;

namespace Glacier.Samples.HealthComponent {
    public class HealthUI : MonoBehaviour {
        [SerializeField]
        private int value;
        [SerializeField]
        private TextMeshProUGUI text;

        private void Update() {
            text.text = value.ToString();
        }
    }
}
#endif
