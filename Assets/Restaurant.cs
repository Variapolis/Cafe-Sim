using System.Collections.Generic;
using Cafe.CookingSystem;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    [SerializeField] private FoodMenu foodMenu;
    public bool IsOpen => OpenKiosks.Count > 0;
    public List<Kiosk> OpenKiosks = new();
    public List<Kiosk> ClosedKiosks = new();
    public FoodMenu FoodMenu => foodMenu;
    private void Start() => AILocationsManager.Instance.Restaurants.Add(this);
}