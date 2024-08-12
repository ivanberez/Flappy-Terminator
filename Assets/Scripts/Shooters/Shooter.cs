using Assets.Scripts.Boolets;
using UnityEngine;

namespace Assets.Scripts.Shooters
{
    public abstract class Shooter : MonoBehaviour
    {        
        [SerializeField, Min(0.1f)] private float _delayShoot = 0.5f;
        [SerializeField, Min(0.1f)] private float _speedBullet = 2;

        [SerializeField] private Transform _startPointBullet;
        [SerializeField] private Transform _exitPointBullet;        

        private float _rechargeTime = 0;

        protected abstract InteractableObjectPool<Bullet> BulletPool { get; }
        
        private bool _isRecharge => _rechargeTime > 0;
        private Vector3 _shootDirection => _exitPointBullet.position - _startPointBullet.position;        

        private void Update()
        {
            if (_isRecharge)
                _rechargeTime -= Time.deltaTime;
        }

        public void Shoot()
        {
            if (_isRecharge == false)
            {
                _rechargeTime = _delayShoot;
                BulletPool.Get().SetParams(_exitPointBullet.position, _shootDirection, transform.eulerAngles, _speedBullet);
            }
        }           
    }
}