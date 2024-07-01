using System.Collections.Generic;
using Gameplay.FSM.States;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.FSM.Behaviours
{
    public interface IBehaviour
    {
        bool CheckTransitionIsApproved(IBehaviour newBehaviour);
        void Enter();
        void OnBehaviourUpdate();
        void OnBehaviourFixedUpdate();
        void OnBehaviourLateUpdate();
        void Exit();
        State GetBehaviourState();
    }
}
