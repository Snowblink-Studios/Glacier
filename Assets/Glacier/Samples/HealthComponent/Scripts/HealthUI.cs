#if GLACIER_UNITY
using UnityEngine;
using TMPro;
using Glacier.Core;

namespace Glacier.Samples.HealthComponent {
    public class HealthUI : MonoBehaviour {
        [SerializeField]
        private VariableReference value;
        [SerializeField]
        private TextMeshProUGUI text;

        private void Update() {
            text.text = value.Variable.ToString();
        }
    }
}
#endif
