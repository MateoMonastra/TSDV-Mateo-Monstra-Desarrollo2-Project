using Menu;
using UnityEngine;

public class PreselectMenuUi : MonoBehaviour
{
    [SerializeField] private PreselectButton preselectButton;
    [SerializeField] private GameObject button;

    private void OnEnable()
    {
        preselectButton.SetPreselectedButton(button);
    }
}
