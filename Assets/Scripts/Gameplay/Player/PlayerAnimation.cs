using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [Tooltip("Name of the grappling animation parameter.")] 
        [SerializeField] private string grapplerAnimationName;

        [Tooltip("Name of the swing animation trigger.")] 
        [SerializeField] private string swingAnimationName;

        private void PlayGrapplingAnimation()
        {
            animator.SetBool(grapplerAnimationName, true);
        }

        private void StopGrapplingAnimation()
        {
            animator.SetBool(grapplerAnimationName, false);
        }

        private void PlaySwingAnimation()
        {
            animator.SetBool(swingAnimationName, true);
        }

        private void StopSwingAnimation()
        {
            animator.SetBool(swingAnimationName, false);
        }
    
    }
}