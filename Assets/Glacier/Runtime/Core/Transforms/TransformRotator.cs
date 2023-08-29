using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace Glacier.Core.Transforms {
    public class TransformRotator : MonoBehaviour {

        [SerializeField]
        private bool runOnStartup;

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
            StopAllCoroutines();
            _tween?.Kill();
        }

        public void Scale(float from, float to) {
            if (!enabled) {
                return;
            }
            CheckTargetObject();

            _targetObject.localScale = Vector3.one * from;
            StartCoroutine(DoScale(_targetObject, Vector3.one * to, duration));
        }

        public void Scale() {
            if (!enabled) {
                return;
            }
            CheckTargetObject();

            if (specifyInitialRotation) {
                _targetObject.localScale = initialRotation;
            }

            if (specifyTargetRotation) {
                StartCoroutine(DoScale(_targetObject, targetRotation, duration));
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

            if (runOnStartup) {
                Scale();
            }
        }

        private void Update() {
            if (!enabled) {
                return;
            }

            if (_isRunning) {
                CheckTargetObject();

                _targetObject.rotation = Quaternion.Euler(_targetObject.rotation.eulerAngles + (rotationStep * Mathf.Min(Time.deltaTime, 1f / 30f)));
                _time = Mathf.Max(_time - Time.deltaTime, 0f);
                if (_time.Equals(0f)) {
                    _isRunning = false;
                    onFinished?.Invoke();
                }
            }
        }

        private void CheckTargetObject() {
            if (_targetObject == null) {
                _targetObject = targetSelf ? transform : targetObject;
            }
        }

        private IEnumerator DoScale(Transform transform, Vector3 scale, float duration) {
            _tween = transform.DOScale(scale, duration).SetEase(easeType);
            yield return new WaitForSeconds(duration);
            onFinished?.Invoke();
        }
    }
}
