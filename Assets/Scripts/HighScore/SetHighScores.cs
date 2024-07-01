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
        [Tooltip("Reference to the high score data container.")]
        [SerializeField] private HighScoreData highScoreData;
        
        [Tooltip("Text to display before the high score value.")]
        [SerializeField] private string positionText;
        
        [Tooltip("Position of the high score to display.")]
        [SerializeField] private int highScorePosition;

        public TextMeshProUGUI highScoreText;

        /// <summary>
        /// Sets the text of the high score based on the provided time.
        /// </summary>
        /// <param name="time">Time value to format as high score text.</param>
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

        /// <summary>
        /// Sets the high score text based on the configured position.
        /// </summary>
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