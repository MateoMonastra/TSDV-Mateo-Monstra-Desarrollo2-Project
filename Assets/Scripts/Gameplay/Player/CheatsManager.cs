using Gameplay.Player.FSM;
using Gameplay.Player.Jump;
using Gameplay.Player.Running;
using Managers;
using UnityEngine;

namespace Gameplay.Player
{
    public class CheatsManager : MonoBehaviour
    {
        [Header("Running Cheat")]
        [Tooltip("The running model with cheat parameters.")]
        [SerializeField] private RunningModel runCheated;
    
        [Tooltip("The default running model.")]
        [SerializeField] private RunningModel runModel;
    
        [Header("Jumper Cheat")]
        [Tooltip("The jump model with cheat parameters.")]
        [SerializeField] private JumpModel jumpCheated;
    
        [Tooltip("The default jump model.")]
        [SerializeField] private JumpModel jumpModel;
        
        [Tooltip("Input reader for detecting cheat activations.")]
        [SerializeField] private InputReaderFsm inputReaderFsm;

        private LevelManager _levelManager;
        private float _auxSpeed;
        private float _auxJumpForce;
        private void Start()
        {
            _auxSpeed = runModel.speed;
            _auxJumpForce = jumpModel.jumpForce;
            
            _levelManager = FindObjectOfType<LevelManager>();
            
            inputReaderFsm.OnSpeedCheat += ChangeSpeed;
            inputReaderFsm.OnJumperCheat += ChangeJumpForce;
            inputReaderFsm.OnPassLevelCheat += PassLevel;
        }

        /// <summary>
        /// Toggles the speed between normal and cheated values.
        /// </summary>
        private void ChangeSpeed()
        {
            runModel.speed = Mathf.Approximately(runModel.speed, _auxSpeed) ? runCheated.speed : _auxSpeed;
        }

        /// <summary>
        /// Toggles the jump force between normal and cheated values.
        /// </summary>
        private void ChangeJumpForce()
        {
            jumpModel.jumpForce = Mathf.Approximately(jumpModel.jumpForce, _auxJumpForce) ? jumpCheated.jumpForce : _auxJumpForce;
        }

        /// <summary>
        /// Sets the level to be passed.
        /// </summary>
        private void PassLevel()
        {
            _levelManager.passLevel = true;
        }
    }
}
