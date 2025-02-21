using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Timer
{
    public class Timer : MonoBehaviour
    {
        [Header("Alpha fade out effect")] 
        [Tooltip("The objective color for the fade In")] 
        [SerializeField] private Color normalColor;

        [Tooltip("The objective color for the fade Out")] 
        [SerializeField] private Color transparentColor;

        [Tooltip("The Duration of the FadeIn")] 
        [SerializeField] private float animFadeInDuration;

        [Tooltip("The Duration of the FadeOut")] 
        [SerializeField] private float animFadeOutDuration;

        public TextMeshProUGUI textTimer;
        public TextMeshProUGUI addTimeText;
        public float TotalTime => _timer;

        private bool _fading;

        private float _timer;

        private void OnEnable()
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

        /// <summary>
        /// Adds the specified amount of time to the timer and triggers the fade-in/out animation.
        /// </summary>
        /// <param name="timeToAdd">The amount of time to add to the timer</param>
        public void AddTime(float timeToAdd)
        {
            _timer += timeToAdd;
            _fading = false;
            StartCoroutine(FadeInOut());
        }

        /// <summary>
        /// Fades the addTimeText color in and out to provide visual feedback when time is added.
        /// </summary>
        private IEnumerator FadeInOut()
        {
            float startTime = Time.time;
            float timer = 0;

            while (timer < animFadeOutDuration && !_fading)
            {
                timer = Time.time - startTime;

                addTimeText.color = Color.Lerp(addTimeText.color, normalColor, timer / animFadeOutDuration);

                yield return null;
            }

            startTime = Time.time;
            timer = 0;
            _fading = true;

            while (timer < animFadeInDuration)
            {
                timer = Time.time - startTime;
                addTimeText.color = Color.Lerp(addTimeText.color, transparentColor, timer / animFadeOutDuration);
                yield return null;
            }
        }
    }
}