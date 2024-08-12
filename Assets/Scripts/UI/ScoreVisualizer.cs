using Assets.Scripts.Player;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ScoreVisualizer : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _counter;
        [SerializeField] private TextMeshProUGUI _text;

        private void OnEnable()
        {
            _counter.ScoreChanged += Refresh;
            Refresh(_counter.Score);
        }

        private void OnDisable()
        {
            _counter.ScoreChanged -= Refresh;
        }

        private void Refresh(int score)
        {
            _text.text = score.ToString();
        }
    }
}