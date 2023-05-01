using Framework.Movements;
using UnityEngine;

namespace Framework.Units.Enemies
{
    public interface IEnemy : IUnit { }

    public class Enemy : MonoBehaviour, IEnemy
    {
        private EnemyStats m_stats;
        private AcceleratedMovement m_movement;

        public void SetStats(EnemyStats stats) 
        {
            m_stats = stats;
        }

        private void Start() 
        {
            m_movement = gameObject.AddComponent<AcceleratedMovement>();
            m_movement.Init(m_stats.Direction, m_stats.StartSpeed, m_stats.Acceleration);
            m_movement.StartMove();
        }
    }
}