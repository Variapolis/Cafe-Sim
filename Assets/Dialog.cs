using TMPro;
using UnityEngine;

public sealed class Dialog : MonoBehaviour, IInteractable
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private string[] responses;
    private int index;
    public void Interact()
    {
        if (index < responses.Length) text.text = responses[index++];
    }
}