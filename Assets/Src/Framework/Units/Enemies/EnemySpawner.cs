using UnityEngine;
using System.Collections.Generic;

namespace Framework.Units.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        private IEnemyFactory m_factory;
        [SerializeField] private List<Transform> m_spawnPos;
        [SerializeField] private float m_startSpeed;
        [SerializeField] private float m_acceleration;

        private void Awake()
        {
            m_factory = new EnemyFactory();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                var nextSpawnPos = m_spawnPos[Random.Range(0, m_spawnPos.Count - 1)];
                var direction = nextSpawnPos.position - transform.position;
                var stats = new EnemyStats(-direction.normalized, m_startSpeed, m_acceleration);
                m_factory.Create(stats, nextSpawnPos.position);
            }
        }
    }
}
