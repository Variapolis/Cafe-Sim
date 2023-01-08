using System.Collections.Generic;
using Cafe.CookingSystem;
using TMPro;
using UnityEngine;

public class SpeechBubbleController : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _remaningText;
    public List<FoodMenuItem> Order;
    public int TableNumber;
    public bool IsFinished { get; private set; }
    private int _count = 0;

    public void Enable()
    {
        IsFinished = false;
        _count = 1;
        speechBubble.SetActive(true);
        _text.text = $"Hello, Can I get a {Order[0].Name}";
        _remaningText.text = $"1/{Order.Count+1}";
    }

    public bool Interact()
    {
        if (_count > Order.Count)
        {
            speechBubble.SetActive(false);
            return IsFinished = true;
        }
        _remaningText.text = $"{_count+1}/{Order.Count+1}";
        _text.text = _count == Order.Count ? $"I'll be at Table {TableNumber}" : $"I would also like a {Order[_count].Name}";
        _count++;
        return true;
    }
}