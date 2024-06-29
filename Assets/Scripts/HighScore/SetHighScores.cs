using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HighScore
{
    public class SetHighScores : MonoBehaviour
    {
        [SerializeField] private HighScoreData highScoreData;
        [SerializeField] private int highScorePosition;
        
        public TextMeshProUGUI highScoreText;
        
        public void SetText(float time)
        {
            int minutes = (int)time / 60;
            int seconds = (int)time % 60;

            if (seconds >= 10)
            {
                highScoreText.text = minutes + ":" + seconds;
            }
            else
            {
                highScoreText.text = minutes + ":0" + seconds;
            }
        }

        public void SetHighScoreText()
        {
            SetText(highScoreData.highScores[highScorePosition]);
        }

        
    }
}
