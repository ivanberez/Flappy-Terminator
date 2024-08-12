using Assets.Scripts.Boolets;
using Assets.Scripts.InteractableObjects.InteractableObjectPool;
using System;
using UnityEngine;

namespace Assets.Scripts.Shooters
{
    public class PlayerShooter : Shooter
    {
        [SerializeField] private CallbackBulletBool _bulletPool;

        protected override InteractableObjectPool<Bullet> BulletPool => _bulletPool;

        public event Action<Collider2D> BulletHitted;

        private void Awake()
        {
            if (_bulletPool)
                _bulletPool.BulletHitted += InvokeBulletHitted;
        }

        private void OnDestroy()
        {
            _bulletPool.BulletHitted -= InvokeBulletHitted;
        }
        private void InvokeBulletHitted(Collider2D collider2D)
        {
            BulletHitted?.Invoke(collider2D);
        }
    }
}