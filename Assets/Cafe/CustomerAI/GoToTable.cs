using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class GoToTable : ActionNode
{
    protected override void OnStart()
    {
        blackboard.Chair = blackboard.Table.Chairs[Random.Range(0, blackboard.Table.Chairs.Length)];
        context.agent.destination = blackboard.Chair.WalkToPosition;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (Vector3.Distance(context.agent.destination, context.transform.position) < context.agent.stoppingDistance)
        {
            SitDown();
            return State.Success;
        }

        return State.Running;
    }

    private void SitDown()
    {
        context.physics.isKinematic = true;
        context.physics.detectCollisions = false;
        context.agent.enabled = false;
        context.gameObject.GetComponentInChildren<Animator>().SetTrigger("Sit");
        var transform = context.transform;
        transform.position = blackboard.Chair.SitPosition;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, blackboard.Chair.SitRotation.eulerAngles.y , transform.eulerAngles.z);
    }
}