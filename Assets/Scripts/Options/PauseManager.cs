using Gameplay.Player.FSM;
using UnityEngine;

namespace Options
{
    public class PauseManager : MonoBehaviour
    {
        [Tooltip("Reference to the input reader")]
        [SerializeField]private InputReaderFsm inputReader;
        
        private PauseUI _pauseUI;

        

        private void Start()
        {
            _pauseUI = GetComponent<PauseUI>();
            
            inputReader.OnPause += _pauseUI.InitPauseMenu;
        }

    
    }
}
