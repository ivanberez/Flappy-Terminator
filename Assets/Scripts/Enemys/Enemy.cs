using Assets.Scripts.InteractableObjects;
using UnityEngine;

namespace Assets.Scripts.Enemys
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Enemy : InteractableObject
    {
        protected override void Awake()
        {
            base.Awake();
            GetComponent<Rigidbody2D>().isKinematic = true;
        }

        private void Update()
        {
            Attack();
        }        

        protected abstract void Attack();

        public void Hit()
        {
            ReportAboutReadyReleasing();
        }
    }
}