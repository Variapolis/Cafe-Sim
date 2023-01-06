using System.Collections.Generic;
using Cafe.CookingSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KioskOrderDisplay : MonoBehaviour
{
    private readonly List<FoodMenuItem> _order = new();
    [SerializeField] private RectTransform orderContent;
    [SerializeField] private TMP_Text textPrefab;
    [SerializeField] private Button sendOrderButton;

    private void Awake() => sendOrderButton.onClick.AddListener(() => {});

    public void AddFoodItem(FoodMenuItem item)
    {
        _order.Add(item);
        var text = Instantiate(textPrefab, orderContent);
        text.text = item.Name;
    }
}