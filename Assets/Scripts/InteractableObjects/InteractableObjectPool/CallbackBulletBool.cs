using Assets.Scripts.Boolets;
using System;
using UnityEngine;

namespace Assets.Scripts.InteractableObjects.InteractableObjectPool
{
    public class CallbackBulletBool : BulletPool
    {
        public event Action<Collider2D> BulletHitted;        
        protected override Bullet CreateFunc()
        {
            var creating = base.CreateFunc();
            creating.CollisionHandler.Collision += BulletHitted.Invoke;
            return creating;
        }

        protected override void ActionOnDestroy(Bullet obj)
        {
            obj.CollisionHandler.Collision -= BulletHitted.Invoke;
            base.ActionOnDestroy(obj);
        }
    }
}