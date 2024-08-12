using Assets.Scripts.InteractableObjects;
using UnityEngine;

namespace Assets.Scripts.Boolets
{    
    public class Bullet : InteractableObject
    {
        private Vector3 _direction;        
        private float _speed;
        private float _startZAgle;

        protected override void Awake()
        {
            base.Awake();
            _startZAgle = transform.eulerAngles.z;            
        }

        public void SetParams(Vector3 position, Vector3 direction, Vector3 rotation, float speed)
        {
            rotation.z += _startZAgle;

            transform.rotation = Quaternion.Euler(rotation);            
            transform.position = position;
            _direction = direction.normalized;            
            
            _speed = speed;
        }

        private void Update()
        {            
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
        }        
    }
}