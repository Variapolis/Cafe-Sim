using UnityEngine;

public class Kiosk : MonoBehaviour
{
    [SerializeField] private Restaurant restaurant;
    [SerializeField] private Transform ButtonContent;
    [SerializeField] private GameObject ButtonPrefab;
    [SerializeField] public QueuePoint[] queuePoints;
    public Restaurant Restaurant => restaurant;
    
    private void Start()
    {
        restaurant.OpenKiosks.Add(this);
        var menu = restaurant.FoodMenu.items;
        foreach (var item in menu)
        {
            var button = Instantiate(ButtonPrefab, ButtonContent).GetComponent<KioskButton>();
            button.SetColor(item.Color); 
            button.SetName(item.name);
            button.SetItem(item);
        }
    }
}