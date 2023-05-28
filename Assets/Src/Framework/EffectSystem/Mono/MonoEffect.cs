using Framework.EffectSystem.Core;
using System;
using UnityEngine;

namespace Framework.EffectSystem.Mono
{
    public abstract class MonoEffect<T> : MonoBehaviour, IEffect where T : IEffect, IDisposable
    {
        protected T m_effect;

        protected virtual void Awake()
        {
            m_effect = CreateEffect();
        }

        protected virtual void OnEnable() => Unpause();
        protected virtual void OnDisable() => Pause();

        protected virtual void OnDestroy()
        {
            m_effect.Restore();
            m_effect.Dispose();
        }

        protected abstract T CreateEffect();
        public virtual void Pause() => m_effect.Pause();
        public virtual void Pause(float duration) => m_effect.Pause(duration);
        public virtual void Restore() => m_effect.Restore();
        public virtual void Unpause() => m_effect.Unpause();
    }
}
