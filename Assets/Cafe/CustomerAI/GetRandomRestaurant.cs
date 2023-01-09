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
        var restaurant = restaurants[Random.Range(0, restaurants.Count)];
        if (!restaurant.IsOpen || !restaurant.HasFreeTables(out var table, out var tableNumber)) return State.Failure;
        context.gameObject.GetComponent<SpeechBubbleController>().TableNumber = tableNumber;
        blackboard.Restaurant = restaurant;
        blackboard.Table = table;
        var kiosk = restaurant.OpenKiosks[Random.Range(0, restaurant.OpenKiosks.Count)];
        blackboard.Kiosk = kiosk;
        foreach (var queuePoint in kiosk.queuePoints)
            if (!queuePoint.IsOccupied)
            {
                context.agent.destination = queuePoint.transform.position;
                blackboard.QueuePoint = queuePoint;
                blackboard.QueuePoint.IsOccupied = true;
                table.IsOccupied = true;
                return State.Success;
            }
        return State.Failure;
    }
}
