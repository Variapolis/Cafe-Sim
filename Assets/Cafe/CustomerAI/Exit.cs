using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.AI;

[System.Serializable]
public class Exit : ActionNode
{
    protected override void OnStart()
    {
        var exits = AILocationsManager.Instance.Exits;
        context.agent.destination = exits[Random.Range(0, exits.Length)].position;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (Vector3.Distance(context.transform.position, context.agent.destination) < context.agent.stoppingDistance)
        {
            Object.Destroy(context.gameObject);
            return State.Success;
        }
        return State.Running;
    }
}