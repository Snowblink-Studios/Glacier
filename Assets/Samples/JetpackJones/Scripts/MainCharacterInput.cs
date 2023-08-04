#if GLACIER_UNITY
using UnityEngine;
using UnityEngine.Events;

namespace Glacier.Samples.JetpackJones {
    public class MainCharacterInput : MonoBehaviour {

        [SerializeField]
        private KeyCode fireInput;
        [SerializeField]
        private UnityEvent<bool> onFiringStateChanged;

        private bool _isFiring = false;

        private void Update() {
            var prevFiring = _isFiring;
            if (Input.GetKeyDown(fireInput)) {
                _isFiring = true;
            }
            else if (Input.GetKeyUp(fireInput)) {
                _isFiring = false;
            }

            if (prevFiring != _isFiring) {
                onFiringStateChanged?.Invoke(_isFiring);
            }
        }
    }
}
#endif
