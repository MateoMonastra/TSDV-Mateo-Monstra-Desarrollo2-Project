using UnityEngine;

namespace MenuButton
{
    [CreateAssetMenu(fileName = "ExitHandler", menuName = "Models/ButtonHandler/ExitHandler")]
    public class ExitHandler : ButtonHandler
    {
        public override void Handle(params object[] args)
        {
            Application.Quit();
        }
    
    
    }
}
