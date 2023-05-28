using UnityEngine;
using Framework.Utils;
using UniRx;
using System;

namespace Framework.EffectSystem
{
    public interface IRainbowEffect : IEffect
    {
        public float Speed { get; set; }
    }

    [RequireComponent(typeof(SpriteRenderer))]
    public class RainbowEffect : MonoEffect, IRainbowEffect
    {
        public float Speed { 
            get => m_speed; 
            set
            {
                m_speed = value;
            } 
        }
        [SerializeField] private float m_speed;

        private float m_speedScale = .1f;
        private HSVColor m_startColor;

        private SpriteRenderer m_spriteRenderer;
        

        protected override void Init()
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
            m_startColor = new HSVColor(m_spriteRenderer.material.color);
        }

        private void Update() => ChangeColor();

        public override void Restore() => m_spriteRenderer.color = m_startColor.ToColor();

        private void ChangeColor()
        {
            if (m_isPause)
                return;

            var currentColor = new HSVColor(m_spriteRenderer.color);
            var newH = Mathf.PingPong(Time.time * Speed * m_speedScale, 1);
            m_spriteRenderer.color = Color.HSVToRGB(newH, currentColor.S, currentColor.V);
        }
    }
}
