using System.Collections.Generic;
using UnityEngine;

namespace HighScore
{
    [CreateAssetMenu(fileName = "HighScoreData", menuName = "Models/HighScore/HighScoreData")]
    public class HighScoreData : ScriptableObject
    {
        [Tooltip("List of high scores stored as float values (time in seconds).")]
        [SerializeField] public List<float> highScores;

        /// <summary>
        /// Sorts the list of high scores in ascending order.
        /// </summary>
        private void SortHighScores()
        {
            highScores.Sort();
        }

        /// <summary>
        /// Adds a new high score to the list and sorts it.
        /// </summary>
        /// <param name="newTime">New high score to add (time in seconds).</param>
        public void AddNewHighScore(float newTime)
        {
            highScores.Add(newTime);
            SortHighScores();
        }
    }
}
