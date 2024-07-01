using Gameplay.Player.FSM.States;

namespace Gameplay.Player.FSM.Behaviours
{
    public interface IBehaviour
    {
        /// <summary>
        /// Checks if transitioning to a new behavior is approved.
        /// </summary>
        /// <param name="newBehaviour">New behavior to transition to.</param>
        bool CheckTransitionIsApproved(IBehaviour newBehaviour);
        /// <summary>
        /// Enters the behavior.
        /// </summary>
        void Enter();
        /// <summary>
        /// Updates the behavior.
        /// </summary>
        void OnBehaviourUpdate();
        /// <summary>
        /// Fixed update for behavior.
        /// </summary>
        void OnBehaviourFixedUpdate();
        /// <summary>
        /// Late update for behaviour.
        /// </summary>
        void OnBehaviourLateUpdate();
        /// <summary>
        /// Exits the behavior.
        /// </summary>
        void Exit();
        /// <summary>
        /// Retrieves the current state of the behavior.
        /// </summary>
        State GetBehaviourState();
    }
}
