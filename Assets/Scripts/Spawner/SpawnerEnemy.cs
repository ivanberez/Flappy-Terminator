using UnityEngine;
using Assets.Scripts.Enemys;
using System.Collections;

namespace Assets.Scripts.Spawner
{    
    public abstract class SpawnerEnemy<T> : MonoBehaviour where T : Enemy
    {
        [SerializeField] protected InteractableObjectPool<T> PoolEnemy;
        [SerializeField] protected float OffSetYSpawnPosition = 1;        
        [SerializeField] protected float Delay = 2;

        private Coroutine _spawning;

        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(transform.position, new Vector3(0.5f, OffSetYSpawnPosition * 2));
        }

        public void Restart()
        {
            if (_spawning != null)
            {
                StopCoroutine(_spawning);
            }
            
            PoolEnemy.ReturnActiveObjects();            

            _spawning = StartCoroutine(SpawnRoutine());
        }

        private Vector3 GetStartPosition()
        {
            Vector3 startPosition = transform.position;            
            startPosition.y += Random.Range(-OffSetYSpawnPosition, OffSetYSpawnPosition);             
            
            return startPosition;
        }

        private void Spawn()
        {
            PoolEnemy.Get().transform.position = GetStartPosition();
        }                

        private IEnumerator SpawnRoutine()
        {
            WaitForSeconds delay = new WaitForSeconds(Delay);

            while (enabled)
            {
                Spawn();
                yield return delay;
            }
        }
    }
}