using Cafe.CookingSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedMenuItemDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button button;
    [SerializeField] private KioskOrderDisplay kioskOrderDisplay;
    private FoodMenuItem _selectedItem;
    public FoodMenuItem SelectedItem
    {
        get => _selectedItem;
        set => text.text = ItemToString(_selectedItem = value);
    }

    private void Awake() => button.onClick.AddListener(() => kioskOrderDisplay.AddFoodItem(_selectedItem));

    private string ItemToString(FoodMenuItem item)
    {
        string text = $"{item.Name}\n";
        return text;
    }
}