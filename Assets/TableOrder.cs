using System.Collections.Generic;
using Cafe.CookingSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableOrder : MonoBehaviour
{
    [SerializeField] private Button removeButton;
    [SerializeField] private TMP_Text tableNumText;
    [SerializeField] private TMP_Text orderText;
    void Start() => removeButton.onClick.AddListener(() => Destroy(gameObject));

    public void SetOrder(string tableNumber, List<FoodMenuItem> food)
    {
        tableNumText.text = tableNumber;
        string foodList = $"Order: {food[0].Name}";
        for (int i = 1; i < food.Count; i++) foodList += $", {food[i].Name}";
        orderText.text = foodList;
    }

    private void OnDestroy() => removeButton.onClick.RemoveAllListeners();
}
