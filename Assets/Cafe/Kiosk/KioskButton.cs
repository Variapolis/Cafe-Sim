using System;
using Cafe.CookingSystem;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

[RequireComponent(typeof(Button))]
public class KioskButton : MonoBehaviour
{
    public FoodMenuItem Item;
    public string Name;

    public Button Button;
    [SerializeField] private TMP_Text text;

    private void Reset()
    {
        Button = GetComponent<Button>();
        text = GetComponentInChildren<TMP_Text>();
    }

    public void SetColor(Color color) => Button.image.color = color;

    public void SetName(string name) => text.text = name;
}