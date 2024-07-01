using System.Collections;
using System.Collections.Generic;
using Gameplay.FSM;
using Player.Jump;
using Player.Running;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Player
{
    public class CheatsManager : MonoBehaviour
    {
        [Header("Running Cheat")]
        [SerializeField] private RunningModel runCheated;
        [SerializeField] private RunningModel runModel;
        
        [Header("Jumper Cheat")]
        [SerializeField] private JumpModel jumpCheated;
        [SerializeField] private JumpModel jumpModel;
            
        [SerializeField] private InputReaderFsm inputReaderFsm;

        private LevelManager.LevelManager _levelManager;
        private float auxSpeed;
        private float auxJumpForce;
        private void Start()
        {
            auxSpeed = runModel.speed;
            auxJumpForce = jumpModel.jumpForce;
            
            _levelManager = FindObjectOfType<LevelManager.LevelManager>();
            
            inputReaderFsm.onSpeedCheat += ChangeSpeed;
            inputReaderFsm.onJumperCheat += ChangeJumpForce;
            inputReaderFsm.onPassLevelCheat += PassLevel;
        }

        private void ChangeSpeed()
        {
            runModel.speed = Mathf.Approximately(runModel.speed, auxSpeed) ? runCheated.speed : auxSpeed;
        }

        private void ChangeJumpForce()
        {
            jumpModel.jumpForce = Mathf.Approximately(jumpModel.jumpForce, auxJumpForce) ? jumpCheated.jumpForce : auxJumpForce;
        }

        private void PassLevel()
        {
            _levelManager.passLevel = true;
        }
    }
}
