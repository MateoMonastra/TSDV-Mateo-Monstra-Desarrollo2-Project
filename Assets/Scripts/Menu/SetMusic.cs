using EventSystems.EventSoundManager;
using UnityEngine;

namespace Menu
{
    public class SetMusic : MonoBehaviour
    {
        [SerializeField] private EventChannelSoundManager channel;
        [SerializeField] private AudioClip music;
        private void Start()
        {
            channel.PlayMusic(music);
        }
    }
}
