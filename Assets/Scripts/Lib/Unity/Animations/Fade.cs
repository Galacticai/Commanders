using Commanders.Assets.Scripts.Lib.Math.Numerics;
using UnityEngine;

namespace Commanders.Assets.Scripts.Lib.Unity.Animations {

    public class Fade : MonoBehaviour {
        [SerializeField] private Function.FunctionName FunctionName;
        private float _CurrentAnimationStep;
        [SerializeField] private float _FadeIn_Multiplier = 3, _FadeOut_Multiplier = 4;
        [SerializeField] private CanvasGroup _CanvasGroup;
        [SerializeField] private bool _FadeIn, _FadeOut;

        public bool Visible { get; private set; }
        public void ShowOnce() {
            if (Visible) return;
            Visible = true;
            Show();
        }
        public void ResetShown()
            => Visible = false;

        public void Show() {
            _CanvasGroup.interactable = true;
            _FadeIn = true;
        }
        public void Hide() {
            _CanvasGroup.interactable = false;
            _FadeOut = true;
        }

        private void Start() {
            _CurrentAnimationStep = _CanvasGroup.alpha;
        }
        private void Update() {
            if (_FadeIn && _CurrentAnimationStep < 1) {
                _CurrentAnimationStep += Time.deltaTime * _FadeIn_Multiplier;
                _CanvasGroup.alpha = (float)Function.Fx(FunctionName, _CurrentAnimationStep, 0, 1);
                if (_CurrentAnimationStep >= 1)
                    _FadeIn = false;
            }
            if (_FadeOut && _CurrentAnimationStep >= 0) {
                _CurrentAnimationStep -= Time.deltaTime * _FadeIn_Multiplier;
                _CanvasGroup.alpha = (float)Function.Fx(FunctionName, _CurrentAnimationStep, 0, 1);
                if (_CurrentAnimationStep <= 0)
                    _FadeOut = false;
            }
        }
    }
}

