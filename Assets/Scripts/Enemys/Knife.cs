using UnityEngine;

namespace Assets.Scripts.Enemys
{
    public class Knife : Enemy
    {
        [SerializeField, Min(1f)] private float _minSpeed = 1.0f;
        [SerializeField, Min(1.1f)] private float _maxSpeed = 1.1f;

        private float _speed = 1;

        private void OnValidate()
        {
            if(_maxSpeed <  _minSpeed)
                _maxSpeed = _minSpeed;
        }

        private void OnEnable()
        {
             _speed = Random.Range(_minSpeed, _maxSpeed);   
        }

        protected override void Attack()
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left, _speed * Time.deltaTime);
        }
    }
}