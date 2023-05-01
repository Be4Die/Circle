using UnityEngine;

namespace Framework.Units.Player
{
    public interface IPlayerFactory : IUnitFactory
    {
        public new IPlayer Create();
    }

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer Create()
        {
            var gameObject = new GameObject("New Player");
            var player = gameObject.AddComponent<Player>();
            return player;
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