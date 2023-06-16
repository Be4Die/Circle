using System;
using UnityEngine;

namespace Framework.EffectSystem
{
    public static class AvalibleEffectsExtension
    {
        public static Type AvalibleEffectToType(AvalibleEffects avalibleEffect)
        {
            switch (avalibleEffect)
            {
                case AvalibleEffects.Rainbow: return typeof(RainbowEffect);
                case AvalibleEffects.Pulse: return typeof(PulseEffect);
                default: throw new NotImplementedException();
            }
        }
    }

    public enum AvalibleEffects
    {
        Rainbow,
        Pulse
    }

    [CreateAssetMenu(fileName = "new EffectSystemConfig", menuName = "Circle/Create Effect System Config")]
    public class EffectSystemConfig : ScriptableObject
    {
        public float RainbowSpeed { get => m_rainbowSpeed; }
        [Header("Rainbow")]
        [SerializeField] private float m_rainbowSpeed;

        public float PulseSpeed { get => m_pulseSpeed; }
        [Header("Pulse")]
        [SerializeField] private float m_pulseSpeed;
    }
}
