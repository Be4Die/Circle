using Framework.EffectSystem.Core;
using UnityEngine;

namespace Framework.EffectSystem.Mono
{
    [RequireComponent(typeof(SpriteRenderer))]
    public partial class MonoRainbowEffect : MonoEffect<RainbowEffect>, IRainbowEffect
    {
        public float Speed
        {
            get => m_speed;

            set 
            {
                m_speed = value;
                ApplySpeed(value);
            }
        }

        [SerializeField] private float m_speed = 0;
        private void OnValidate()
        {
            ApplySpeed(m_speed);
        }

        private void ApplySpeed(float value)
        {
            if (m_effect == null)
                return;

            m_effect.Speed = value;
        }

        protected override RainbowEffect CreateEffect() => new RainbowEffect(GetComponent<SpriteRenderer>(), Speed);
    }
}
