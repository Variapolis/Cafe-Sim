using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class GetRandomPointOfInterest : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        var pois = AILocationsManager.Instance.PointsOfInterest;
        if (pois.Length == 0) return State.Failure;
        var poi = pois[Random.Range(0, pois.Length - 1)];
        blackboard.moveToPosition = poi.position;
        return State.Success;
    }
}