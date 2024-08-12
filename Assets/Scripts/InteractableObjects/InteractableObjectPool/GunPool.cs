using Assets.Scripts.Enemys;
using UnityEngine;

namespace Assets.Scripts.InteractableObjects.InteractableObjectPool
{
    public class GunPool : InteractableObjectPool<GunEnemy>
    {
        [SerializeField] private BulletPool _bulletPool;        

        protected override GunEnemy CreateFunc()
        {
            var creating = base.CreateFunc();
            creating.Init(_bulletPool);            
            return creating;
        } 
    }
}