using UnityEngine;
using Framework.Utils;

namespace Framework.EffectSystem
{
    public interface IPulseEffect : IEffect
    {
        public float Speed { get; set; }
    }

    [RequireComponent(typeof(SpriteRenderer))]
    public class PulseEffect : MonoEffect, IPulseEffect
    {
        public float Speed
        {
            get => m_speed;
            set
            {
                m_speed = value;
            }
        }
        [SerializeField] private float m_speed;

        private SpriteRenderer m_spriteRenderer;
        private HSVColor m_startColor;
        private float m_speedScale = .1f;

        private void Update() => ChangeColor();

        protected override void Init()
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
            m_startColor = new HSVColor(m_spriteRenderer.material.color);
        }
        public override void Restore() => m_spriteRenderer.material.color = m_startColor.ToColor();

        private void ChangeColor()
        {
            if (m_isPause)
                return;

            var currentColor = new HSVColor(m_spriteRenderer.color);
            var newV = 1 - Mathf.PingPong(Time.time * Speed * m_speedScale, .5f);
            m_spriteRenderer.color = UnityEngine.Color.HSVToRGB(currentColor.H, currentColor.S, newV);
        }

    }
}
