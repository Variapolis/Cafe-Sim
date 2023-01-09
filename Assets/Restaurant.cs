using System.Collections.Generic;
using Cafe.CookingSystem;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    [SerializeField] private FoodMenu foodMenu;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip praiseClip;
    [SerializeField] private AudioClip complainClip;
    public bool IsOpen => OpenKiosks.Count > 0;
    public Table[] Tables;
    public int score;
    public List<Kiosk> OpenKiosks = new();

    // public List<Kiosk> ClosedKiosks = new();
    public FoodMenu FoodMenu => foodMenu;

    public bool HasFreeTables(out Table availableTable, out int tableNumber)
    {
        availableTable = null;
        tableNumber = -1;
        if (Tables.Length == 0) return false;
        for (int i = 0; i < Tables.Length; i++)
            if (!Tables[i].IsOccupied)
            {
                availableTable = Tables[i];
                tableNumber = i + 1;
                return true;
            }
        return false;
    }

    public void Complain(string reason, int orderSize)
    {
        Debug.Log("Complain");
        audioSource.clip = complainClip;
        audioSource.Play();
        score -= orderSize;
    }

    public void Praise(int orderSize)
    {
        Debug.Log("Praise");
        audioSource.clip = praiseClip;
        audioSource.Play();
        score += orderSize;
    }
    
    private void Start()
    {
        AILocationsManager.Instance.Restaurants.Add(this);
        for (int i = 0; i < Tables.Length; i++) Tables[i].TableNumber = i + 1;
    }
}