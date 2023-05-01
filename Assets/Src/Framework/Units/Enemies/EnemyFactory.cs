using UnityEngine;

namespace Framework.Units.Enemies
{
    public interface IEnemyFactory: IUnitFactory
    {
        public IEnemy Create(EnemyStats stats, Vector3 position);
    }

    public class EnemyFactory : IEnemyFactory
    {
        public IEnemy Create(EnemyStats stats, Vector3 position)
        {
            var gameObject = new GameObject("New Enemy");
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.AddComponent<CircleCollider2D>();
            gameObject.transform.position = position;
            var enemy = gameObject.AddComponent<Enemy>();
            enemy.SetStats(stats);
            return enemy;
        }

        public void Load()
        {
            throw new System.NotImplementedException();
        }

        IUnit IUnitFactory.Create()
        {
            throw new System.NotImplementedException();
        }
    }
}