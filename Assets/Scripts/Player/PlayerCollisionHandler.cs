using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Player), typeof(BoxCollider2D))]
    public class PlayerCollisionHandler : MonoBehaviour
    {        
        public event Action CollisionDetected;

        private void OnValidate()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out IInteractable component))
                CollisionDetected?.Invoke();
        }
    }
}