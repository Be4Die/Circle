using UnityEngine;
using System.Runtime;
using System;

namespace Framework.Units.Enemies
{
    [Serializable]
    public struct EnemyStats
    {
        public Vector2 Direction { get => m_direction; }
        [SerializeField] private Vector2 m_direction;

        public float StartSpeed { get => m_startSpeed; }
        [SerializeField] private float m_startSpeed;

        public float Acceleration { get => m_acceleration; }
        [SerializeField] private float m_acceleration;

        public EnemyStats(Vector2 direction, float startSpeed, float acceleration)
        {
            m_direction = direction;
            m_startSpeed = startSpeed;
            m_acceleration = acceleration;
        }
    }
}