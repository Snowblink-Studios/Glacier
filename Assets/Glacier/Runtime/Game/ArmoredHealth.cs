#if GLACIER_UNITY
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Glacier.Game {
    public class ArmoredHealth : Health {

        [Header("Armor")]
        [SerializeField]
        protected int startingArmor = 100;
        [SerializeField]
        protected int maxArmor = 100;
        [SerializeField]
        protected UnityEvent<int> onDamageArmor = new();
        [SerializeField]
        protected UnityEvent<int> onHealArmor = new();
        [SerializeField]
        protected UnityEvent<int> onArmorValueChanged = new();
        [SerializeField]
        protected UnityEvent onFullyHealedArmor = new();
        [SerializeField]
        protected UnityEvent onArmorDepleted = new();

        public int CurrentArmor => _currentArmor;
        public int MaxArmor => maxArmor;
        public UnityEvent<int> OnDamageArmor => onDamageArmor;
        public UnityEvent<int> OnHealArmor => onHealArmor;
        public UnityEvent<int> OnArmorValueChanged => onArmorValueChanged;
        public UnityEvent OnFullyHealedArmor => onFullyHealedArmor;
        public UnityEvent OnArmorDepleted => onArmorDepleted;

        protected int _currentArmor;

        public override void TakeDamage(int amount) {
            var excessAmount = Math.Max(amount - _currentArmor, 0);
            _currentArmor = Move(_currentArmor, amount, Movement.Decrease, out bool didChanged);
            onDamageArmor?.Invoke(amount);
            if (didChanged) {
                onArmorValueChanged?.Invoke(_currentArmor);
            }
            InvokeOnEqual(_currentArmor, 0, () => onArmorDepleted?.Invoke());
            base.TakeDamage(excessAmount);
        }

        public virtual void HealArmor(int amount) {
            _currentArmor = Move(_currentArmor, amount, Movement.Increase, out bool didChanged);
            onHealArmor?.Invoke(amount);
            if (didChanged) {
                onArmorValueChanged?.Invoke(_currentArmor);
            }
            InvokeOnEqual(_currentArmor, maxArmor, () => onFullyHealedArmor?.Invoke());
        }

        public virtual void SetCurrentArmor(int value) {
            _currentArmor = Math.Min(Math.Max(value, 0), maxArmor);
        }

        public virtual void SetMaxArmor(int value) {
            maxArmor = Math.Max(value, 0);
            _currentArmor = Math.Min(_currentArmor, maxArmor);
        }

        protected override void Start() {
            base.Start();
            if (startingArmor > maxArmor) {
                startingArmor = maxArmor;
                Debug.LogError("Starting armor value is more than maxArmor value.");
            }
            _currentArmor = startingArmor;
            onArmorValueChanged?.Invoke(_currentArmor);
            //Debug.Log("ArmoredHealth Start() called.");
        }
    }
}
#endif
