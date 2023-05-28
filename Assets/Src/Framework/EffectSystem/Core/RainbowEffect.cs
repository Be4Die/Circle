using System;
using UniRx;
using UnityEngine;

namespace Framework.EffectSystem.Core
{
    public interface IRainbowEffect : IEffect
    {
        public float Speed { get; set; }
    }

    public class RainbowEffect : IRainbowEffect, IDisposable
    {
        public float Speed { get; set; }

        private bool m_isPause;
        private const float m_speedScale = .1f;
        private HSVColor m_startColor;

        private SpriteRenderer m_spriteRenderer;
        private CompositeDisposable m_colorChangeDisposable = new CompositeDisposable();
        private CompositeDisposable m_pauseDisposable = new CompositeDisposable();
        private bool m_disposedValue;

        public RainbowEffect(SpriteRenderer spriteRenderer, float speed)
        {
            m_spriteRenderer = spriteRenderer;
            m_startColor = new HSVColor(m_spriteRenderer.color);
            Speed = speed;
            Observable.EveryUpdate().Subscribe(_ => ChangeColor()).AddTo(m_colorChangeDisposable);
        }

        public void Restore() => m_spriteRenderer.color = m_startColor.ToColor();
        public void ChangeColor()
        {
            if (m_isPause)
                return;

            var currentColor = new HSVColor(m_spriteRenderer.color);
            var newH = Mathf.PingPong(Time.time * Speed * m_speedScale, 1);
            m_spriteRenderer.color = Color.HSVToRGB(newH, currentColor.S, currentColor.V);
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

        ~RainbowEffect()
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
