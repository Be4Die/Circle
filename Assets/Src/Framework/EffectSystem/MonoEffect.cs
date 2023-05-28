using UnityEngine;
using UniRx;
using System;

namespace Framework.EffectSystem
{
    public abstract class MonoEffect : MonoBehaviour, IEffect
    {
        protected bool m_isPause;
        private CompositeDisposable m_pauseDisposable = new CompositeDisposable();

        private void Awake()
        {
            Init();
        }

        public virtual void Pause() => m_isPause = true;

        public virtual void Pause(float duration)
        {
            if (m_isPause)
                return;

            Observable
                .Timer(TimeSpan.FromSeconds(duration))
                .Subscribe(_ =>
                {
                    Unpause();
                    m_pauseDisposable.Clear();
                })
                .AddTo(m_pauseDisposable);
            m_isPause = true;
        }

        public virtual void Unpause() => m_isPause = false;

        public abstract void Restore();
        protected abstract void Init();
    }
}
