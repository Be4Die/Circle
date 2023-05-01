using UnityEngine;

namespace Framework.Units.Enemies
{
    public interface IEnemyFactory: IUnitFactory
    {
        public new IEnemy Create();
    }

    public class EnemyFactory : IEnemyFactory
    {
        public IEnemy Create()
        {
            var gameObject = new GameObject("New Enemy");
            var enemy = gameObject.AddComponent<Enemy>();
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