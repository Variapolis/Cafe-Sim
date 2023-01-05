using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class GetRandomRestaurant : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        var restaurants = AILocationsManager.Instance.Restaurants;
        if (restaurants.Count == 0) return State.Failure;
        var restaurant = restaurants[Random.Range(0, restaurants.Count - 1)];
        if (!restaurant.IsOpen) return State.Failure;
        blackboard.Restaurant = restaurant;
        var kiosk = restaurant.OpenKiosks[Random.Range(0, restaurant.OpenKiosks.Count - 1)];
        blackboard.Kiosk = kiosk;
        foreach (var queuePoint in kiosk.queuePoints)
            if (!queuePoint.IsOccupied)
            {
                context.agent.destination = queuePoint.transform.position;
                blackboard.QueuePoint = queuePoint;
                Debug.Log("Update");
                blackboard.QueuePoint.IsOccupied = true;
                return State.Success;
            }
        return State.Failure;
    }
}
