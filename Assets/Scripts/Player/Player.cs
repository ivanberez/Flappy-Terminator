using Assets.Scripts.Enemys;
using Assets.Scripts.Shooters;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(PlayerMover), typeof(PlayerCollisionHandler), typeof(ScoreCounter))]
    [RequireComponent(typeof(PlayerShooter))]
    public class Player : MonoBehaviour
    {
        private PlayerCollisionHandler _collisionHandler;
        private ScoreCounter _scoreCounter;
        private PlayerMover _mover;                         
        private PlayerShooter _shooter;

        public event Action PlayerOver;

        private void Awake()
        {            
            _collisionHandler = GetComponent<PlayerCollisionHandler>();
            _scoreCounter = GetComponent<ScoreCounter>();
            _mover = GetComponent<PlayerMover>();
            _shooter = GetComponent<PlayerShooter>();

            _collisionHandler.CollisionDetected += Die;
            _shooter.BulletHitted += DefineHitEnemy;
        }

        private void OnDisable()
        {
            _collisionHandler.CollisionDetected -= Die;
            _shooter.BulletHitted -= DefineHitEnemy;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
                _shooter.Shoot();
        }
        
        public void Reset()
        {
            _scoreCounter.ResetScore();
            _mover.ResetPosition();
        }

        private void DefineHitEnemy(Collider2D collider2D)
        {            
            if(collider2D.TryGetComponent(out Enemy enemy))
            {
                enemy.Hit();
                _scoreCounter.UpCounter();
            }                
        }   
        
        private void Die()
        {
            PlayerOver?.Invoke();
        }
    }
}