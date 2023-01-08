using System.Collections;
using System.Collections.Generic;
using Cafe.CookingSystem;
using UnityEngine;

public class OrdersScreen : MonoBehaviour
{
    [SerializeField] private TableOrder _order;
    [SerializeField] private RectTransform orderContent;

    public void AddOrder(string tableNumber, List<FoodMenuItem> foodItems)
    {
        var order = Instantiate(_order, orderContent);
        order.GetComponent<TableOrder>().SetOrder(tableNumber, foodItems);
    }
}
