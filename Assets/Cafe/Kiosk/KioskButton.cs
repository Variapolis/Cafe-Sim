using System;
using Cafe.CookingSystem;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

[RequireComponent(typeof(Button))]
public class KioskButton : MonoBehaviour
{
    private FoodMenuItem _item;
    public string Name;

    public Button Button;
    [SerializeField] private TMP_Text text;

    private void Reset()
    {
        Button = GetComponent<Button>();
        text = GetComponentInChildren<TMP_Text>();
    }

    private void Awake()
    {
        // Button.onClick.AddListener(() => Instantiate(BasketItemPrefab, BasketContent.transform).GetComponent<TMP_Text>().text = $" - {button.Name}\n    $5.99");
    }

    public void SetItem(FoodMenuItem item) => _item = item;

    public void SetColor(Color color) => Button.image.color = color;

    public void SetName(string name) => text.text = name;
}