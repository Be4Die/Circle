using UnityEngine;

namespace Framework.Units.Enemies
{
    public interface IEnemy : IUnit { }

    public class Enemy : MonoBehaviour, IEnemy
    {
        
    }
}