using Assets.Scripts.InteractableObjects.InteractableObjectPool;
using Assets.Scripts.Shooters;
using UnityEngine;

namespace Assets.Scripts.Enemys
{
    [RequireComponent(typeof(EnemyShooter))]
    public class GunEnemy : Enemy
    {
        private EnemyShooter _shooter;

        protected override void Awake()
        {
            base.Awake();
            _shooter = GetComponent<EnemyShooter>();
        }
        protected override void Attack()
        {
            _shooter.Shoot();
        }

        public void Init(BulletPool bulletPool)
        {
            _shooter.Init(bulletPool);
        }
    }
}