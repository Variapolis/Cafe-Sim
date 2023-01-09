using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class GetRandomPointOfInterest : ActionNode
{
    protected override void OnStart()
    {
        var pois = AILocationsManager.Instance.PointsOfInterest;
        var poi = pois[Random.Range(0, pois.Length)];
        context.agent.destination = poi.position;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate() => Vector3.Distance(context.transform.position, context.agent.destination) > context.agent.stoppingDistance ? State.Running : State.Success;
}