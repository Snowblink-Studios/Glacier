#if GLACIER_UNITY
using UnityEngine;
using TMPro;
using Glacier.Game;

namespace Glacier.Samples.HealthComponent {
    public class UnitStats : MonoBehaviour {

        [SerializeField]
        private int maxHealth;
        [SerializeField]
        private Health health;
        [SerializeField]
        private TextMeshProUGUI healthText;
        [SerializeField]
        private TextMeshProUGUI armorText;

        public Health Health => health;

        public void ModifyVar() {
            maxHealth = 220;
        }

        public void TakeDamage(int amount) {
            health.TakeDamage(amount);
        }

        public void DisplayHealth(int value) {
            healthText.text = value.ToString();
        }

        public void DisplayArmor(int value) {
            armorText.text = value.ToString();
        }
    }
}
#endif
