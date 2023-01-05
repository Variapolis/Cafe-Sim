using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

[System.Serializable]
public class WaitInLine : ActionNode
{
    private int? queuePosition;

    protected override void OnStart()
    {
        var queuePoints = blackboard.Kiosk.queuePoints;

        for (int i = 0; i < queuePoints.Length; i++)
            if (queuePoints[i].GetInstanceID() == blackboard.QueuePoint.GetInstanceID())
            {
                queuePosition = i;
                return;
            }
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        switch (queuePosition)
        {
            case null:
                return State.Failure;
            case 0:
                if (Vector3.Distance(context.transform.position, blackboard.QueuePoint.transform.position) > context.agent.stoppingDistance &&
                    context.agent.pathStatus == NavMeshPathStatus.PathComplete)
                    return State.Running;
                return State.Success;
            default:
                var nextPosition = blackboard.Kiosk.queuePoints[queuePosition.Value - 1];
                if (!nextPosition.IsOccupied)
                {
                    blackboard.QueuePoint.IsOccupied = false;
                    blackboard.QueuePoint = nextPosition;
                    blackboard.QueuePoint.IsOccupied = true;
                    context.agent.destination = nextPosition.transform.position;
                }
                return State.Running;
        }
    }
}