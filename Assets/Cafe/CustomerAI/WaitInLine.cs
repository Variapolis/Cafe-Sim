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
                return Vector3.Distance(context.transform.position, blackboard.QueuePoint.transform.position) > context.agent.stoppingDistance ? State.Running : State.Success;
            default:
                var nextPosition = blackboard.Kiosk.queuePoints[queuePosition.Value - 1];
                if (nextPosition.IsOccupied) return State.Running;
                blackboard.QueuePoint.IsOccupied = false;
                queuePosition--;
                blackboard.QueuePoint = nextPosition;
                blackboard.QueuePoint.IsOccupied = true;
                context.agent.destination = blackboard.QueuePoint.transform.position;
                return State.Running;
        }
    }
}