using System.Collections.Generic;
using System.Linq;
using Cafe.CookingSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KioskOrderDisplay : MonoBehaviour
{
    private readonly List<FoodMenuItem> _order = new();
    [SerializeField] private GameObject chooseTableWindow;
    [SerializeField] private TMP_Text tableSelection;
    [SerializeField] private OrdersScreen ordersScreen;
    [SerializeField] private RectTransform orderContent;
    [SerializeField] private TMP_Text textPrefab;
    [SerializeField] private Button sendOrderButton;
    [SerializeField] private Button chooseTableButton;

    private void Start()
    {
        chooseTableButton.onClick.AddListener(() => chooseTableWindow.SetActive(true));
        sendOrderButton.onClick.AddListener(() =>
        {
            chooseTableWindow.SetActive(false);
            ordersScreen.AddOrder($"Table {tableSelection.text}", _order);
            tableSelection.text = string.Empty;
            _order.Clear();
            foreach (RectTransform order in orderContent) Destroy(order.gameObject);
        });
    }

    public void AddFoodItem(FoodMenuItem item)
    {
        _order.Add(item);
        var text = Instantiate(textPrefab, orderContent);
        text.text = item.Name;
    }
}