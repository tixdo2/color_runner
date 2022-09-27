using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;

        private int _currentPoints;
        
        public void UpdatePoints(int points)
        {
            _currentPoints = points;
            UpdateUI();
        }

        private void UpdateUI()
        {
            scoreText.text = _currentPoints.ToString();
        }
    }
}