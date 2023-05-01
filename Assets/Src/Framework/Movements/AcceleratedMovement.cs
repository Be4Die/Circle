using UnityEngine;
using UniRx;
using System;

namespace Framework.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AcceleratedMovement : MonoBehaviour, IMoveable
    {
        private CompositeDisposable m_movmentDisposable = new CompositeDisposable();
        private bool m_isInit = false;
        private Vector2 m_direction;
        private Rigidbody2D m_rigidbody;
        private float m_acceleration;
        [SerializeField]private float m_speed = 0;

        public void Init(Vector2 direction, float startSpeed, float acceleration)
        {
            m_direction = direction;
            m_speed = startSpeed;
            m_acceleration = acceleration;
            m_rigidbody = GetComponent<Rigidbody2D>();
            m_isInit = true;
        }
        public void StartMove() 
        {
            Observable.EveryFixedUpdate().Subscribe(_ => Move()).AddTo(m_movmentDisposable);
        }
        public void StopMoving()
        {
            m_movmentDisposable.Clear();
        }

        public void Move() 
        {
            if (m_isInit)
            {
                m_speed += m_acceleration * Time.fixedDeltaTime;
                var newPosition =  m_rigidbody.position + m_direction.normalized * Time.fixedDeltaTime * m_speed;
                m_rigidbody.MovePosition(newPosition);
            }
            else throw new Exception($"{this.GetType()} Error, init class before use");
        } 
    }
}
