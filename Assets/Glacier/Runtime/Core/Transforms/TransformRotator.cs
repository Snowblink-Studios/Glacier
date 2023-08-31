using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace Glacier.Core.Transforms {
    public class TransformRotator : MonoBehaviour {

        [SerializeField]
        private bool runOnStartup;
        [SerializeField]
        private bool applyOnLocalSpace = false;

        [SerializeField]
        private bool specifyInitialRotation = false;
        [SerializeField]
        private Vector3 initialRotation;

        [SerializeField]
        private bool specifyTargetRotation = true;
        [SerializeField]
        private Vector3 targetRotation;
        [SerializeField]
        private Vector3 rotationStep;

        [SerializeField]
        private bool fixedDuration = false;
        [SerializeField]
        private float duration;
        [SerializeField]
        private Ease easeType = Ease.Linear;

        [SerializeField]
        private bool targetSelf = true;
        [SerializeField]
        private Transform targetObject;

        [SerializeField]
        private UnityEvent onFinished = new UnityEvent();

        public UnityEvent OnFinished => onFinished;

        private Transform _targetObject;
        private Vector3 _rotation;
        private float _time;
        private bool _isRunning = false;
        private Tween _tween;

        public void SetFixedDuration(float duration, Ease easeType=Ease.Linear) {
            fixedDuration = true;
            this.duration = duration;
            this.easeType = easeType;
        }

        public void DisableFixedDuration() {
            fixedDuration = false;
        }

        public void SetEaseType(Ease easeType) {
            this.easeType = easeType;
        }

        public void Stop() {
            _isRunning = false;
            StopAllCoroutines();
            _tween?.Kill();
        }

        public void Rotate(Vector3 from, Vector3 to) {
            if (!enabled) {
                return;
            }
            CheckTargetObject();

            if (applyOnLocalSpace) {
                _targetObject.localRotation = Quaternion.Euler(from);
            }
            else {
                _targetObject.rotation = Quaternion.Euler(from);
            }
            StartCoroutine(DoRotate(_targetObject, to, duration));
        }

        public void Rotate() {
            if (!enabled) {
                return;
            }
            CheckTargetObject();

            if (specifyInitialRotation) {
                _rotation = initialRotation;
                if (applyOnLocalSpace) {
                    _targetObject.localRotation = Quaternion.Euler(_rotation);
                }
                else {
                    _targetObject.rotation = Quaternion.Euler(_rotation);
                }
            }

            if (specifyTargetRotation) {
                StartCoroutine(DoRotate(_targetObject, targetRotation, duration));
            }
            else {
                _isRunning = true;
                _time = duration;
            }
        }

        private void Start() {
            if (!enabled) {
                return;
            }

            _targetObject = targetSelf ? transform : targetObject;
            _rotation = _targetObject.rotation.eulerAngles;

            if (runOnStartup) {
                Rotate();
            }
        }

        private void Update() {
            if (!enabled) {
                return;
            }

            if (_isRunning) {
                CheckTargetObject();

                _rotation += (rotationStep * Mathf.Min(Time.deltaTime, 1f / 30f));
                if (applyOnLocalSpace) {
                    _targetObject.localRotation = Quaternion.Euler(_rotation);
                }
                else {
                    _targetObject.rotation = Quaternion.Euler(_rotation);
                }

                _rotation = ClampTo360(_rotation);

                if (fixedDuration) {
                    _time = Mathf.Max(_time - Time.deltaTime, 0f);
                    if (_time.Equals(0f)) {
                        _isRunning = false;
                        onFinished?.Invoke();
                    }
                }
            }
        }

        private void CheckTargetObject() {
            if (_targetObject == null) {
                _targetObject = targetSelf ? transform : targetObject;
            }
        }

        private IEnumerator DoRotate(Transform transform, Vector3 rotation, float duration) {
            if (applyOnLocalSpace) {
                _tween = transform.DOLocalRotate(rotation, duration).SetEase(easeType);
            }
            else {
                _tween = transform.DORotate(rotation, duration).SetEase(easeType);
            }
            yield return new WaitForSeconds(duration);
            onFinished?.Invoke();
        }

        private Vector3 ClampTo360(Vector3 toBeClamped) {
            while (toBeClamped.x > 360f) { toBeClamped.x -= 360f; }
            while (toBeClamped.x < 0f) { toBeClamped.x += 360f; }
            while (toBeClamped.y > 360f) { toBeClamped.y -= 360f; }
            while (toBeClamped.y < 0f) { toBeClamped.y += 360f; }
            while (toBeClamped.z > 360f) { toBeClamped.z -= 360f; }
            while (toBeClamped.z < 0f) { toBeClamped.z += 360f; }
            return toBeClamped;
        }
    }
}
