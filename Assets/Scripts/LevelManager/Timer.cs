using UnityEngine;
using UnityEngine.UI;

namespace LevelManager
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float timerTime;
        private float _timer;

        public Text textTimer;

        private void Start()
        {
            _timer = timerTime;
        }
        private void Update()
        {
            _timer -= Time.deltaTime;
            
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

        public bool TimerFinished() 
        {
            return _timer <= 0;
        }
    }
}
