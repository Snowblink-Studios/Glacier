#if GLACIER_UNITY
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Glacier.Game {
    public abstract class Health : MonoBehaviour, IHealth {

        protected enum Movement {
            Increase,
            Decrease
        }

        [SerializeField]
        protected int starting = 100;
        [SerializeField]
        protected int max = 100;
        [SerializeField]
        protected UnityEvent<int> onTakeDamage = new();
        [SerializeField]
        protected UnityEvent<int> onHeal = new();
        [SerializeField]
        protected UnityEvent<int> onHealthValueChanged = new UnityEvent<int>();
        [SerializeField]
        protected UnityEvent onFullyHealed = new();
        [SerializeField]
        protected UnityEvent onDeath = new();

        public int Current => _current;
        public int Max => max;
        public UnityEvent<int> OnTakeDamage => onTakeDamage;
        public UnityEvent<int> OnHeal => onHeal;
        public UnityEvent<int> OnHealthValueChanged => onHealthValueChanged;
        public UnityEvent OnFullyHealed => onFullyHealed;
        public UnityEvent OnDeath => onDeath;

        protected int _current;

        public virtual void TakeDamage(int amount) {
            _current = Move(_current, amount, Movement.Decrease, out bool didChanged);
            onTakeDamage?.Invoke(amount);
            if (didChanged) {
                onHealthValueChanged?.Invoke(_current);
            }
            InvokeOnEqual(_current, 0, () => onDeath?.Invoke());
        }

        public virtual void Heal(int amount) {
            _current = Move(_current, amount, Movement.Increase, out bool didChanged);
            onHeal?.Invoke(amount);
            if (didChanged) {
                onHealthValueChanged?.Invoke(_current);
            }
            InvokeOnEqual(_current, max, () => onFullyHealed?.Invoke());
        }

        public virtual void SetCurrent(int value) {
            _current = Math.Min(Math.Max(value, 0), max);
        }

        public virtual void SetMax(int value) {
            max = Math.Max(value, 1);
            _current = Math.Min(_current, max);
        }

        protected int Move(int value, int amount, Movement movement, out bool didMoved) {
            var prevCurrent = value;
            if (movement == Movement.Increase) {
                value = Math.Min(value + amount, max);
            }
            else if (movement == Movement.Decrease) {
                value = Math.Max(value - amount, 0);
            }
            didMoved = prevCurrent != value;
            return value;
        }

        protected void InvokeOnEqual(int value, int comparison, Action onInvoke) {
            if (value == comparison) {
                onInvoke?.Invoke();
            }
        }

        protected virtual void Start() {
            if (starting > max) {
                starting = max;
                Debug.LogError("Starting health value is more than max value.");
            }
            _current = starting;
            onHealthValueChanged?.Invoke(_current);
            //Debug.Log("Health (Abstract) Start() called.");
        }
    }
}
#endif
