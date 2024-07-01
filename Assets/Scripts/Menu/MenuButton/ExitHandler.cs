using UnityEngine;

namespace Menu.MenuButton
{
    [CreateAssetMenu(fileName = "ExitHandler", menuName = "Models/ButtonHandler/ExitHandler")]
    public class ExitHandler : ButtonHandler
    {
        /// <summary>
        /// Handles the action of exiting the application.
        /// </summary>
        /// <param name="args">Optional arguments for the exit handler.</param>
        public override void Handle(params object[] args)
        {
            Application.Quit();
        }
    
    
    }
}
