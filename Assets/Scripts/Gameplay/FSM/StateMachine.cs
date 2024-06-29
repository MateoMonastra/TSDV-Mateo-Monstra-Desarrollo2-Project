using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.Serialization;
using State = FSM.States.State;

namespace FSM
{
    public class StateMachine : MonoBehaviour
    {
        public State currentState;
    }
}
