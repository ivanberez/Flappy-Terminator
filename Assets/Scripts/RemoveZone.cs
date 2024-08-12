using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class RemoveZone : MonoBehaviour
    {
        private void OnValidate() => GetComponent<Collider2D>().isTrigger = true;
    }
}