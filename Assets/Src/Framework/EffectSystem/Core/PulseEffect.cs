using System;
using UniRx;
using UnityEngine;

namespace Framework.EffectSystem.Core
{
    public interface IPulseEffect : IEffect
    {
        public float Speed { get; set; }
    }

    // TODO: Make MonoEffect
    public class PulseEffect : IPulseEffect, IDisposable
    {
        public float Speed { get; set; }

        private bool m_isPause;
        private const float m_speedScale = .1f;
        private HSVColor m_startColor;

        private SpriteRenderer m_spriteRenderer;
        private CompositeDisposable m_colorChangeDisposable = new CompositeDisposable();
        private CompositeDisposable m_pauseDisposable = new CompositeDisposable();
        private bool m_disposedValue;

        public PulseEffect(SpriteRenderer spriteRenderer, float speed)
        {
            m_spriteRenderer = spriteRenderer;
            Speed = speed;
            m_startColor = new HSVColor(m_spriteRenderer.color);
            Observable.EveryUpdate().Subscribe(_ => ChangeColor()).AddTo(m_colorChangeDisposable);
        }
        public void Restore() => m_spriteRenderer.color = m_startColor.ToColor();
        public void ChangeColor()
        {
            if (m_isPause)
                return;

            var currentColor = new HSVColor(m_spriteRenderer.color);
            var newV = 1-Mathf.PingPong(Time.time * Speed * m_speedScale, .5f);
            m_spriteRenderer.color = Color.HSVToRGB(currentColor.H, currentColor.S, newV);
        }

        public void Pause() => m_isPause = true;
        public void Pause(float duration)
        {
            m_isPause = true;
            Observable
                .Timer(TimeSpan.FromSeconds(duration))
                .Subscribe(_ =>
                {
                    Unpause();
                    m_pauseDisposable.Dispose();
                })
                .AddTo(m_pauseDisposable);
        }

        public void Unpause() => m_isPause = false;

        ~PulseEffect()
        {
            Dispose(disposing: false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposedValue)
            {
                if (disposing)
                {
                    m_colorChangeDisposable.Clear();
                    m_pauseDisposable.Clear();
                }
                m_pauseDisposable = null;
                m_colorChangeDisposable = null;
                m_spriteRenderer = null;
                m_disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
