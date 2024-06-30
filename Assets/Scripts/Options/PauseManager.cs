using System;
using Gameplay.FSM;
using UnityEngine;
using UnityEngine.Serialization;

namespace Options
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField]private InputReaderFsm inputReader;
        
        private PauseUI _pauseUI;

        

        private void Start()
        {
            _pauseUI = GetComponent<PauseUI>();
            
            inputReader.onPause += _pauseUI.InitPauseMenu;
        }

    
    }
}
