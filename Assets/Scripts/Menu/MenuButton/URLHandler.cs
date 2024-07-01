using UnityEngine;

namespace Menu.MenuButton
{
    [CreateAssetMenu(fileName = "URLHandler", menuName = "Models/ButtonHandler/URLHandler")]
    public class URLHandler : ButtonHandler
    {
        [Tooltip("The URL to be opened.")]
        [SerializeField] private string url = "null";
        
        /// <summary>
        /// Handles the action of opening the specified URL.
        /// </summary>
        /// <param name="args">Optional arguments for the URL handler.</param>
        public override void Handle(params object[] args) 
        {
            if (url == "null") return;

            Application.OpenURL(url);
        }
    }
}
