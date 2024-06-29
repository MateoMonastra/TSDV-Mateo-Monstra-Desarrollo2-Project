using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HighScore
{
    public class SetHighScores : MonoBehaviour
    {
        [SerializeField] private HighScoreData highScoreData;
        [SerializeField] private string positionText;
        [SerializeField] private int highScorePosition;

        public TextMeshProUGUI highScoreText;

        private void SetText(float time)
        {
            var minutes = (int)time / 60;
            var seconds = (int)time % 60;
            
            if (seconds >= 10)
            {
                highScoreText.text = positionText + minutes + ":" + seconds;
            }
            else
            {
                highScoreText.text = positionText  + minutes + ":0" + seconds;
            }
        }

        private void SetHighScoreText()
        {
            if (highScoreData.highScores.Count == 0) return;
            
            if (highScorePosition < highScoreData.highScores.Count)
                    SetText(highScoreData.highScores[highScorePosition]);
        }

        private void OnEnable()
        {
            SetHighScoreText();
        }
    }
}