using System.Collections.Generic;
using UnityEngine;

public class AILocationsManager : MonoBehaviour
{
    public static AILocationsManager Instance;
    public List<Restaurant> Restaurants = new();
    public Transform[] PointsOfInterest;
    public Transform[] Exits;
    
    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }
}