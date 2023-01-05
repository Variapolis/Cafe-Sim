using System.Collections.Generic;
using Cafe.CookingSystem;
using TMPro;
using UnityEngine;

public class SpeechBubbleController : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private TMP_Text _text;
    public List<FoodMenuItem> Order;
    public bool IsFinished { get; private set; }
    private int _count = 0;

    public void Enable()
    {
        IsFinished = false;
        _count = 1;
        speechBubble.SetActive(true);
        _text.text = $"Hello, Can I get a {Order[0].Name}";
    }

    public bool Interact()
    {
        if (_count >= Order.Count)
        {
            speechBubble.SetActive(false);
            return IsFinished = true;
        }
        _text.text = $"I would also like a {Order[_count].Name}";
        _count++;
        return true;
    }
}