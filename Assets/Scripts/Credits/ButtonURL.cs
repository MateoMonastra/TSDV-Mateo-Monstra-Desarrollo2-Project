using UnityEngine;

namespace Credits
{
    public class ButtonURL : MonoBehaviour
    {
        [SerializeField] private string url;
    
        public void AbrirURL()
        {
            Application.OpenURL(url);
        }
    }
}
