using System.Collections.Generic;
using UnityEngine;

namespace HighScore
{
    [CreateAssetMenu(fileName = "HighScoreData", menuName = "Models/HighScore/HighScoreData")]
    public class HighScoreData : ScriptableObject
    {
        [SerializeField] public List<float> highScores;

        private void SortHighScores()
        {
            highScores.Sort();
        }

        public void AddNewHighScore(float newTime)
        {
            highScores.Add(newTime);
            SortHighScores();
        }
    }
}
