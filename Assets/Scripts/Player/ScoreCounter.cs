using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class ScoreCounter : MonoBehaviour
    {       
        private int _score;

        public event Action<int> ScoreChanged;

        public int Score
        {
            get => _score; 
            set 
            {
                _score = value;
                ScoreChanged?.Invoke(value);
            }
        }

        public void UpCounter()
        {
            Score++;            
        }

        public void ResetScore()
        {
            Score = 0;
        }
    }
}