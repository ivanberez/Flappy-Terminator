using Assets.Scripts.Enemys;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ScoreZone : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;        

        private void OnValidate()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
                _scoreCounter.UpCounter();
        }
    }
}