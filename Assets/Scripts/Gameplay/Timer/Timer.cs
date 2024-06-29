using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LevelManager
{
    public class Timer : MonoBehaviour
    {
        [Header("Alpha fade out effect")] 
        [SerializeField] private Color newColor;
        [SerializeField] private Color transparentColor;

        [SerializeField] private float animFadeDuration;
        [SerializeField] private float animOutDuration;

        public TextMeshProUGUI textTimer;
        public TextMeshProUGUI addTimeText;

        private bool fading;
        
        private float _timer;
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

        private IEnumerator FadeInOut()
        {
            float startTime = Time.time;
            float timer = 0;
            
            while (timer < animOutDuration && !fading)
            {
                timer = Time.time - startTime;
                
                addTimeText.color = Color.Lerp(addTimeText.color, newColor, timer/animOutDuration);
                
                yield return null;
            }
            
            startTime = Time.time;
            timer = 0;
            fading = true;
            
            while (timer < animFadeDuration)
            {
                timer = Time.time - startTime;
                addTimeText.color = Color.Lerp(addTimeText.color, transparentColor, timer/animOutDuration);
                yield return null;
            }

        }
        

        public void AddTime(float timeToAdd)
        {
            _timer += timeToAdd;
            fading = false;
            StartCoroutine(FadeInOut());
        }
    }
}