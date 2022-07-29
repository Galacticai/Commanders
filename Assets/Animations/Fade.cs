using Assets.Scripts.Lib.Math;
using UnityEngine;
using static Assets.Scripts.Lib.Math.Function;

namespace Assets.Animations {

    public class Fade : MonoBehaviour {
        [SerializeField] private FunctionName function;
        private float _currentAnimationStep;
        [SerializeField] private float _fadeIn_Multiplier = 3, _fadeOut_Multiplier = 4;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private bool _fadeIn = false, _fadeOut = false;

        private bool _shown = false;
        public void showOnce() {
            if (this._shown) return;
            this._shown = true;
            this.show();
        }
        public void resetShown()
            => this._shown = false;

        public void show() {
            this._fadeIn = true;
        }
        public void hide() {
            this._fadeOut = true;
        }

        private void Start() {
            this._currentAnimationStep = this._canvasGroup.alpha;
        }
        private void Update() {
            if (this._fadeIn && this._currentAnimationStep < 1) {
                this._currentAnimationStep += Time.deltaTime * this._fadeIn_Multiplier;
                this._canvasGroup.alpha = (float)Function.fx(this._currentAnimationStep, 1, this.function);
                if (this._currentAnimationStep >= 1)
                    this._fadeIn = false;
            }
            if (this._fadeOut && this._currentAnimationStep >= 0) {
                this._currentAnimationStep -= Time.deltaTime * this._fadeIn_Multiplier;
                this._canvasGroup.alpha = (float)Function.fx(this._currentAnimationStep, 1, this.function);
                if (this._currentAnimationStep <= 0)
                    this._fadeOut = false;
            }
        }
    }
}

