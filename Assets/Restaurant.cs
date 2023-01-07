using System.Collections.Generic;
using Cafe.CookingSystem;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    [SerializeField] private FoodMenu foodMenu;
    public bool IsOpen => OpenKiosks.Count > 0;
    public Table[] Tables;
    public int score;
    public List<Kiosk> OpenKiosks = new();

    // public List<Kiosk> ClosedKiosks = new();
    public FoodMenu FoodMenu => foodMenu;

    public bool HasFreeTables(out Table availableTable)
    {
        availableTable = null;
        if (Tables.Length == 0) return false;
        foreach (var table in Tables)
            if (!table.IsOccupied)
            {
                availableTable = table;
                return true;
            }
        return false;
    }

    public void Complain(string reason)
    {
        Debug.Log("Complain");
        score--;
    }

    public void Praise()
    {
        Debug.Log("Praise");
        score++;
    }
    
    private void Start()
    {
        AILocationsManager.Instance.Restaurants.Add(this);
        for (int i = 0; i < Tables.Length; i++) Tables[i].TableNumber = i + 1;
    }
}