using System;
using Gameplay.Player.FSM;
using Gameplay.Player.Jump;
using Gameplay.Player.Running;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Player
{
    public class CheatsManager : MonoBehaviour
    {
        [Header("Running Cheat")]
        [Tooltip("The running model with cheat parameters.")]
        [SerializeField] private RunningModel cheatRunModel;
        
        [Tooltip("The default running model.")]
        [SerializeField] private RunningModel normalRunModel;
        
        [Header("Jumper Cheat")]
        [Tooltip("The jump model with cheat parameters.")]
        [SerializeField] private JumpModel cheatJumpModel;
        
        [Tooltip("The default jump model.")]
        [SerializeField] private JumpModel normalJumpModel;
        
        [Tooltip("Input reader for detecting cheat activations.")]
        [SerializeField] private InputReader inputReader;

        private LevelManager _levelManager;
        
        private float _auxSpeed;
        private float _auxJumpForce;
        
        private void OnEnable()
        {
            _auxSpeed = normalRunModel.speed;
            _auxJumpForce = normalJumpModel.jumpForce;
            
            _levelManager = FindObjectOfType<LevelManager>();
            
            inputReader.OnSpeedCheat += ChangeSpeed;
            inputReader.OnJumperCheat += ChangeJumpForce;
            inputReader.OnPassLevelCheat += PassLevel;
        }

        private void OnDisable()
        {
            inputReader.OnSpeedCheat -= ChangeSpeed;
            inputReader.OnJumperCheat -= ChangeJumpForce;
            inputReader.OnPassLevelCheat -= PassLevel;
        }

        /// <summary>
        /// Toggles the speed between normal and cheated values.
        /// </summary>
        private void ChangeSpeed()
        {
            normalRunModel.speed = Mathf.Approximately(normalRunModel.speed, _auxSpeed) ? cheatRunModel.speed : _auxSpeed;
        }

        /// <summary>
        /// Toggles the jump force between normal and cheated values.
        /// </summary>
        private void ChangeJumpForce()
        {
            normalJumpModel.jumpForce = Mathf.Approximately(normalJumpModel.jumpForce, _auxJumpForce) ? cheatJumpModel.jumpForce : _auxJumpForce;
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
