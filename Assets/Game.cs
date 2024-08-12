using Assets.Scripts.InteractableObjects.InteractableObjectPool;
using Assets.Scripts.Player;
using Assets.Scripts.Spawner;
using Assets.Scripts.UI.Windows;
using UnityEngine;

namespace Assets
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private SpawnerGunEnemy _spawnerGunEnemy;
        [SerializeField] private SpawnerKnife _spawnerKnife;
        [SerializeField] private BulletPool[] _bulletPools;

        [SerializeField] private StartGameScreen _startGameScreen;
        [SerializeField] private EndGameScreen _endGameScreen;

        private void OnEnable()
        {
            _player.PlayerOver += EndGame;
            _startGameScreen.PlayButtonClicked += OnPlayButtonClick;
            _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        }

        private void Start()
        {
            Time.timeScale = 0.0f;
            _startGameScreen.Open();
            _endGameScreen.Close();
        }

        private void OnRestartButtonClick()
        {
            _endGameScreen.Close();
            StartGame();
        }

        private void OnPlayButtonClick()
        {
            _startGameScreen.Close();
            _endGameScreen.WindowGroup.blocksRaycasts = true;
            StartGame();
        }

        private void StartGame()
        {
            Time.timeScale = 1.0f;
            _player.Reset();
            _spawnerGunEnemy.Restart();
            _spawnerKnife.Restart();
            
            foreach (BulletPool pool in _bulletPools)
                pool.ReturnActiveObjects();
        }

        private void EndGame()
        {
            Time.timeScale = 0.0f;
            _endGameScreen.Open();
        }
    }
}