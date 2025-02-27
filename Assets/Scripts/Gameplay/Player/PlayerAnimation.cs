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

        public void PlayGrapplingAnimation()
        {
            animator.SetBool(grapplerAnimationName, true);
        }

        public void StopGrapplingAnimation()
        {
            animator.SetBool(grapplerAnimationName, false);
        }

        public void PlaySwingAnimation()
        {
            animator.SetBool(swingAnimationName, true);
        }

        public void StopSwingAnimation()
        {
            animator.SetBool(swingAnimationName, false);
        }
    
    }
}