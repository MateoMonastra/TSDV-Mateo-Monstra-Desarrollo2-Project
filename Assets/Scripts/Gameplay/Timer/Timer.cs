using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManager
{
    public class Timer : MonoBehaviour
    {
        private float _timer;

        public TextMeshProUGUI textTimer;

        public float TotalTime => _timer;
        
        private void Start()
        {
            _timer = 0;
        }
        private void Update()
        {
            _timer += Time.deltaTime;
            
            int minutes = (int)_timer / 60;
            int seconds = (int)_timer % 60;

            if (seconds >= 10)
            {
                textTimer.text = minutes + ":" + seconds;
            }
            else
            {
                textTimer.text = minutes + ":0" + seconds;
            }
        }

        public void AddTime(float timeToAdd)
        {
            _timer += timeToAdd;
        }
    }
}
