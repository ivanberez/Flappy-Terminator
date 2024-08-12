using Assets.Scripts.Boolets;
using Assets.Scripts.InteractableObjects.InteractableObjectPool;
using UnityEngine;

namespace Assets.Scripts.Shooters
{
    public class EnemyShooter : Shooter
    {
        [SerializeField] private BulletPool _bulletPool;

        protected override InteractableObjectPool<Bullet> BulletPool => _bulletPool;
        
        public void Init(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }
    }
}