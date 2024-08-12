using System;
using UnityEngine;

namespace Assets.Scripts.InteractableObjects
{
    [RequireComponent(typeof(Collider2D), typeof(CollisionHandler))]
    public abstract class InteractableObject : MonoBehaviour, IInteractable
    {
        public CollisionHandler CollisionHandler { get; private set; }

        public event Action<InteractableObject> ReadyOnReleasing;

        protected virtual void Awake()
        {
            CollisionHandler = GetComponent<CollisionHandler>();
            CollisionHandler.Collision += DefineRemoveZoneCollision;
        }

        protected virtual void OnDestroy() => CollisionHandler.Collision -= DefineRemoveZoneCollision;

        protected void ReportAboutReadyReleasing()
        {
            ReadyOnReleasing?.Invoke(this);
        }

        private void DefineRemoveZoneCollision(Collider2D collider2D)
        {
            if (collider2D.TryGetComponent(out RemoveZone component))
                ReportAboutReadyReleasing();                
        }
    }
}