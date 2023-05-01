namespace Framework.Units.Enemies
{
    using UnityEngine;

    public class EnemySpawner : MonoBehaviour
    {
        private IEnemyFactory m_factory;

        private void Awake()
        {
            m_factory = new EnemyFactory();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                m_factory.Create();

            }
        }
    }
}
