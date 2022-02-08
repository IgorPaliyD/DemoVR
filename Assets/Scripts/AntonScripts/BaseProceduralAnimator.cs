using UnityEngine;

namespace Liquid.Utils
{
    public abstract class BaseProceduralAnimator : MonoBehaviour
    {
        public abstract void Animate();
        public abstract void AnimateReversed();
        public abstract void Stop();
        public abstract void Pause();
        public abstract void Resume();
    }
}