using System.Collections.Generic;
using Cafe.CookingSystem;
using TMPro;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;

    private int _tableNumber;
    public int TableNumber
    {
        get => _tableNumber;
        set
        {
            _tableNumber = value;
            tmpText.text = $"Table {value}";
        }
    }
    public FoodTray FoodTray;
    public Chair[] Chairs;
    public bool IsOccupied;
}