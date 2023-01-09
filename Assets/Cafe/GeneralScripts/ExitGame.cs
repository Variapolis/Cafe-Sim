using UnityEngine;

public class ExitGame : MonoBehaviour, IInteractable
{
    public bool Interact()
    {
        Application.Quit();
        return true;
    }
}
