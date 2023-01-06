using UnityEngine;

public class Kiosk : MonoBehaviour
{
    [SerializeField] private Restaurant restaurant;
    [SerializeField] private Transform MenuButtonContent;
    [SerializeField] private GameObject ButtonPrefab;
    [SerializeField] private SelectedMenuItemDisplay selectedMenuItemDisplay;
    public QueuePoint[] queuePoints;
    public Restaurant Restaurant => restaurant;

    private void Start()
    {
        restaurant.OpenKiosks.Add(this);
        var menu = restaurant.FoodMenu.items;
        foreach (var item in menu)
        {
            var button = Instantiate(ButtonPrefab, MenuButtonContent).GetComponent<KioskButton>();
            button.SetColor(item.Color);
            button.SetName(item.name);
            button.Item = item;
            button.Button.onClick.AddListener(() => selectedMenuItemDisplay.SelectedItem = button.Item);
        }
    }
}