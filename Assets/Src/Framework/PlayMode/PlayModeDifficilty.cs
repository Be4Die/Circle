using System;
using UnityEngine;

namespace Framework.PlayMode
{
    [Serializable]
    public struct PlayModeDifficilty
    {
        public string SoundTrackName { get => m_soundTrackName; }

        public float SpeedModifier { get => m_speedModifier; }
        public float MinSpeed { get => m_minSpeed; }
        public float MaxSpeed { get => m_maxSpeed; }

        [SerializeField] private string m_soundTrackName;
        [Header("Speed")]
        [SerializeField] private float m_speedModifier;
        [SerializeField] private float m_minSpeed;
        [SerializeField] private float m_maxSpeed;
    }
}
